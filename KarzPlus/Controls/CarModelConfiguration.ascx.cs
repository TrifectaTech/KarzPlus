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

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool SaveControl()
        {
            bool valid = false;
            CarModel modelToSave = new CarModel();
            if (EditOption)
            {
                modelToSave = CarModelManager.Load(ModelId);
            }

            modelToSave.Name = txtModelName.Text;

            int makeId = 0;
            int.TryParse(ddlCarMake.SelectedValue, out makeId);
            modelToSave.MakeId = makeId;
            
            //modelToSave.CarImage =;

            string errorMessage;
            valid = CarModelManager.Save(modelToSave, out errorMessage);
            return valid;
        }

        public void ReloadControl()
        {
            LoadCarMakes();
            if (EditOption)
            {
                LoadOnModelId(ModelId);
            }
        }

        private void LoadOnModelId(int modelId)
        {
            CarModel carModel = CarModelManager.Load(modelId);

            txtModelName.Text = carModel.Name;

            ddlCarMake.SelectedValue = carModel.MakeId.ToString();
        }

        private void LoadCarMakes()
        {
            ddlCarMake.DataSource = CarMakeManager.LoadAll().OrderBy(t => t.Name).ToList();
            ddlCarMake.DataValueField = "MakeId";
            ddlCarMake.DataTextField = "Name";
            ddlCarMake.DataBind();
            ddlCarMake.Items.Insert(0, new RadComboBoxItem("Select One"));
            ddlCarMake.SelectedIndex = 0;
        }
    }
}