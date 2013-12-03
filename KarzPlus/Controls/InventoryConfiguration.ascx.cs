using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KarzPlus.Business;
using KarzPlus.Entities;
using KarzPlus.Entities.ExtensionMethods;
using Telerik.Web.UI;

namespace KarzPlus.Controls
{
    public partial class InventoryConfiguration : UserControl
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

        public int InventoryId
        {
            get
            {
                if (ViewState["InventoryId"] == null)
                {
                    ViewState["InventoryId"] = false;
                }
                return (int)ViewState["InventoryId"];
            }
            set { ViewState["InventoryId"] = value; }
        }     

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SaveControl()
        {
            Inventory itemToSave = new Inventory();

            if (EditOption)
            {
                itemToSave = InventoryManager.Load(InventoryId);
            }

            itemToSave.Color = txtColor.Text;
            itemToSave.Price = (decimal)txtprice.Value;
            itemToSave.Quantity = (int)txtqty.Value;
            itemToSave.Year = (int)txtyear.Value;

            int modelId = 0;
            int.TryParse(ddlCarModel.SelectedValue, out modelId);
            itemToSave.ModelId = modelId;

            int locationId = 0;
            int.TryParse(ddlLocation.SelectedValue, out locationId);
            itemToSave.LocationId = locationId;

            string errorMessage;
            InventoryManager.Save(itemToSave, out errorMessage);
        }

        public void ReloadControl()
        {
            LoadDropDowns();
            if (EditOption)
            {
                LoadControlOnLocationId(InventoryId);
            }
        }

        private void LoadControlOnLocationId(int inventoryId)
        {
            CarInventoryView inventoryItem = CarInventoryViewManager.LoadOnInventoryId(inventoryId);

            ddlCarMake.SelectedValue = inventoryItem.MakeId.ToString();
            LoadCarModelsOnMake();
            ddlLocation.SelectedValue = inventoryItem.LocationId.ToString();

            txtColor.Text = inventoryItem.Color;
            txtprice.Value = (double)inventoryItem.Price.GetValueOrDefault();
            txtqty.Value = inventoryItem.Quantity;
            txtyear.Value = inventoryItem.CarYear;
           
        }

        private void LoadDropDowns()
        {
            LoadCarMakes();
            LoadCarModelsOnMake();
            LoadDddlLocations();
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

        private void LoadCarModelsOnMake()
        {
            int makeId;
            if (int.TryParse(ddlCarMake.SelectedValue, out makeId) && makeId > 0)
            {
                ddlCarModel.DataSource = CarModelManager.LoadOnMakeId(makeId).OrderBy(t => t.Name).ToList();
                ddlCarModel.DataValueField = "ModelId";
                ddlCarModel.DataTextField = "Name";
                ddlCarModel.DataBind();
            }
            ddlCarModel.Items.Insert(0, new RadComboBoxItem("Select One"));
            ddlCarModel.SelectedIndex = 0;
        }

        private void LoadDddlLocations()
        {
            ddlCarMake.DataSource = LocationManager.LoadAll().OrderBy(t => t.Name).ToList();
            ddlCarMake.DataValueField = "LocationId";
            ddlCarMake.DataTextField = "FullAddress";
            ddlCarMake.DataBind();
            ddlCarMake.Items.Insert(0, new RadComboBoxItem("Select One"));
            ddlCarMake.SelectedIndex = 0;
        }

        protected void ddlCarMake_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            LoadCarModelsOnMake();
        }
    }
}