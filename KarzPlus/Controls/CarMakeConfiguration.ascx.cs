using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KarzPlus.Entities;
using KarzPlus.Business;
using KarzPlus.Entities.ExtensionMethods;

namespace KarzPlus.Controls
{
    public partial class CarMakeConfiguration : System.Web.UI.UserControl
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
            CarMake modelToSave = new CarMake();
            if (EditOption)
            {
                modelToSave = CarMakeManager.Load(MakeId);
            }

            modelToSave.Name = txtMakeName.Text;
            modelToSave.Manufacturer = txtManufacturer.Text;

            string errorMessage;
            valid = CarMakeManager.Save(modelToSave, out errorMessage);
            return valid;
        }

        public void ReloadControl()
        {
            if (EditOption)
            {
                LoadOnMakeId(MakeId);
            }
        }

        private void LoadOnMakeId(int makeId)
        {
            CarMake carMake = CarMakeManager.Load(makeId);

            txtMakeName.Text = carMake.Name;
            txtManufacturer.Text = carMake.Manufacturer;
            
        }
    }
}