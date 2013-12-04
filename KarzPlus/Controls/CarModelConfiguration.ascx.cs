using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KarzPlus.Entities;
using KarzPlus.Business;
using KarzPlus.Entities.ExtensionMethods;
using Telerik.Web.UI;
using System.IO;
using System.Drawing;

namespace KarzPlus.Controls
{
    public partial class CarModelConfiguration : System.Web.UI.UserControl
    {
        public bool EditOption
        {
            get
            {
                if (ViewState["EditOption"] == null)
                {
                    ViewState["EditOption"] = false;
                }
                return (bool)ViewState["EditOption"];
            }
            set { ViewState["EditOption"] = value; }
        }

        public int ModelId
        {
            get
            {
                if (ViewState["ModelId"] == null)
                {
                    ViewState["ModelId"] = 0;
                }
                return (int)ViewState["ModelId"];
            }
            set { ViewState["ModelId"] = value; }
        }

        public int MakeId
        {
            get
            {
                if (ViewState["MakeId"] == null)
                {
                    ViewState["MakeId"] = 0;
                }
                return (int)ViewState["MakeId"];
            }
            set { ViewState["MakeId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool SaveControl()
        {
            bool valid = false;

            CarModel modelToSave = new CarModel();
            modelToSave.MakeId = MakeId;
            modelToSave.CarImage = null;

            if (EditOption)
            {
                modelToSave = CarModelManager.Load(ModelId);
            }

            modelToSave.Name = txtModelName.Text;
            if (RadAsyncUpload1.UploadedFiles.Count > 0)
            {
                UploadedFile file = RadAsyncUpload1.UploadedFiles[0];

                System.Drawing.Image.GetThumbnailImageAbort thumbnailImageAbortDelegate = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);

                using (Bitmap originalImage = new Bitmap(file.InputStream))
                {
                    decimal w1, h1, width2;
                    int expectedWidth = 250;

                    w1 = originalImage.Width;
                    h1 = originalImage.Height;
                    width2 = Calculations(w1, h1, expectedWidth);

                    int height = Convert.ToInt32(width2);
                    using (System.Drawing.Image thumbnail = originalImage.GetThumbnailImage(expectedWidth, height, thumbnailImageAbortDelegate, IntPtr.Zero))
                    {
                        ImageConverter converter = new ImageConverter();
                        byte[] attachedBytes = (byte[])converter.ConvertTo(thumbnail, typeof(byte[]));
                        modelToSave.CarImage = attachedBytes;
                    }
                }   
            }

            string errorMessage;
            valid = CarModelManager.Save(modelToSave, out errorMessage);
            return valid;
        }

        private bool ThumbnailCallback()
        {
            return false;
        }

        private decimal Calculations(decimal w1, decimal h1, decimal expectedWidth)
        {
            decimal height = 0;
            decimal ratio = 0;
            if (expectedWidth < w1)
            {
                ratio = w1 / expectedWidth;
                height = h1 / ratio;
                return height;
            }

            if (w1 < expectedWidth)
            {
                ratio = expectedWidth / w1;
                height = h1 * ratio;
                return height;
            }

            return height;
        }   

        public void ReloadControl()
        {
            if (EditOption)
            {
                LoadOnModelId(ModelId);
            }
        }

        private void LoadOnModelId(int modelId)
        {
            CarModel carModel = CarModelManager.Load(modelId);

            txtModelName.Text = carModel.Name;

        }

    }
}