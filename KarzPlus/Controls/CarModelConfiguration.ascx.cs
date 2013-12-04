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
                        if (EditOption)
            {
                modelToSave = CarModelManager.Load(ModelId);
            }

            modelToSave.Name = txtModelName.Text;
            modelToSave.CarImage = new byte[1];
            string errorMessage;
            valid = CarModelManager.Save(modelToSave, out errorMessage);
            return valid;
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