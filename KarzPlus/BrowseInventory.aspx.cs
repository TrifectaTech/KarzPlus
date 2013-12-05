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
using KarzPlus.Base;

namespace KarzPlus
{
    public partial class BrowseInventory : BasePage
    {
        private int? SelectedModelId
        {
            get
            {
                int modelId;
                int? id = null;
                if (int.TryParse(ddlCarModel.SelectedValue, out modelId))
                {
                    id = modelId;
                }
                return id;
            }
        }

        private int? SelectedMakeId
        {
            get
            {
                int makeId;
                int? id = null;
                if (int.TryParse(ddlCarMake.SelectedValue, out makeId))
                {
                    id = makeId;
                }
                return id;
            }
        }

        private string SelectedState
        {
            get
            {
                string state;
                if (ddlLocation.SelectedValue.IsNullOrWhiteSpace())
                {
                    state = null;
                }
                else
                {
                    state = ddlLocation.SelectedValue;
                }
                return state;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDropDowns();
            }
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            lblMessage.Visible = false;

            if (SelectedMakeId.HasValue || !SelectedState.IsNullOrWhiteSpace())
            {
                grdresults.Rebind();
            }
            else
            {
                lblMessage.Visible = true;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ddlCarMake.ClearSelection();
            ddlCarModel.ClearSelection();
            ddlLocation.ClearSelection();

            ddlCarModel.Items.Clear();
            LoadDropDowns();
            lblMessage.Visible = false;
            grdresults.Rebind();
        }

        protected void grdresults_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable)
            {
                if (SelectedMakeId.HasValue || !SelectedState.IsNullOrWhiteSpace())
                {
                    grdresults.DataSource = CarInventoryViewManager.GetOnSearchFields(SelectedMakeId, SelectedModelId, SelectedState).ToList();
                }
                else
                {
                    grdresults.DataSource = CarInventoryViewManager.GetOnSearchFields(0, 0, null).ToList();
                }
            }
        }

        protected void grdresults_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
            if (e.DetailTableView.Name.SafeEquals("ItemDetails"))
            {
                if (!User.Identity.IsAuthenticated)
                {
                    e.DetailTableView.Columns[0].Visible = false;
                }
                int inventoryId = (int)e.DetailTableView.ParentItem.GetDataKeyValue("InventoryId");

                List<Inventory> inventories = new List<Inventory>();

                Inventory inventory = InventoryManager.Load(inventoryId);

                inventories.Add(inventory);

                e.DetailTableView.DataSource = inventories;
            }
        }

        private void LoadDropDowns()
        {
            LoadCarMakes();
            LoadCarModelsOnMake();
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
        protected void ddlLocation_Load(object sender, EventArgs e)
        {
            if (ddlLocation.Items.Count == 0)
            {
                ddlLocation.Items.Add(new RadComboBoxItem("AL")); ddlLocation.Items.Add(new RadComboBoxItem("AK")); ddlLocation.Items.Add(new RadComboBoxItem("AZ")); ddlLocation.Items.Add(new RadComboBoxItem("AR")); ddlLocation.Items.Add(new RadComboBoxItem("CA"));
                ddlLocation.Items.Add(new RadComboBoxItem("CO")); ddlLocation.Items.Add(new RadComboBoxItem("CT")); ddlLocation.Items.Add(new RadComboBoxItem("DC")); ddlLocation.Items.Add(new RadComboBoxItem("DE")); ddlLocation.Items.Add(new RadComboBoxItem("FL"));
                ddlLocation.Items.Add(new RadComboBoxItem("GA")); ddlLocation.Items.Add(new RadComboBoxItem("HI")); ddlLocation.Items.Add(new RadComboBoxItem("ID")); ddlLocation.Items.Add(new RadComboBoxItem("IL")); ddlLocation.Items.Add(new RadComboBoxItem("IN"));
                ddlLocation.Items.Add(new RadComboBoxItem("IA")); ddlLocation.Items.Add(new RadComboBoxItem("KS")); ddlLocation.Items.Add(new RadComboBoxItem("KY")); ddlLocation.Items.Add(new RadComboBoxItem("LA")); ddlLocation.Items.Add(new RadComboBoxItem("ME"));
                ddlLocation.Items.Add(new RadComboBoxItem("MD")); ddlLocation.Items.Add(new RadComboBoxItem("MA")); ddlLocation.Items.Add(new RadComboBoxItem("MI")); ddlLocation.Items.Add(new RadComboBoxItem("MN")); ddlLocation.Items.Add(new RadComboBoxItem("MS"));
                ddlLocation.Items.Add(new RadComboBoxItem("MO")); ddlLocation.Items.Add(new RadComboBoxItem("MT")); ddlLocation.Items.Add(new RadComboBoxItem("NE")); ddlLocation.Items.Add(new RadComboBoxItem("NV")); ddlLocation.Items.Add(new RadComboBoxItem("NH"));
                ddlLocation.Items.Add(new RadComboBoxItem("NJ")); ddlLocation.Items.Add(new RadComboBoxItem("NH")); ddlLocation.Items.Add(new RadComboBoxItem("NY")); ddlLocation.Items.Add(new RadComboBoxItem("NC")); ddlLocation.Items.Add(new RadComboBoxItem("ND"));
                ddlLocation.Items.Add(new RadComboBoxItem("OH")); ddlLocation.Items.Add(new RadComboBoxItem("OK")); ddlLocation.Items.Add(new RadComboBoxItem("OR")); ddlLocation.Items.Add(new RadComboBoxItem("PA")); ddlLocation.Items.Add(new RadComboBoxItem("RI"));
                ddlLocation.Items.Add(new RadComboBoxItem("SC")); ddlLocation.Items.Add(new RadComboBoxItem("SD")); ddlLocation.Items.Add(new RadComboBoxItem("TN")); ddlLocation.Items.Add(new RadComboBoxItem("TX")); ddlLocation.Items.Add(new RadComboBoxItem("UT"));
                ddlLocation.Items.Add(new RadComboBoxItem("VT")); ddlLocation.Items.Add(new RadComboBoxItem("VA")); ddlLocation.Items.Add(new RadComboBoxItem("WA")); ddlLocation.Items.Add(new RadComboBoxItem("WV")); ddlLocation.Items.Add(new RadComboBoxItem("WI"));
                ddlLocation.Items.Add(new RadComboBoxItem("WY"));


                foreach (RadComboBoxItem item in ddlLocation.Items)
                {
                    item.Value = item.Text;
                }

                ddlLocation.Items.Insert(0, new RadComboBoxItem("Select One"));
                ddlLocation.SelectedIndex = 0;
            }
        }

        protected void ddlCarMake_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            LoadCarModelsOnMake();
        }

        protected void grdresults_OnItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.Item is GridDataItem &&
                e.Item.OwnerTableView.Name.Equals("ItemDetails") &&
                e.CommandName.SafeEquals("PlaceRentalOrder", StringComparison.CurrentCultureIgnoreCase))
            {
                GridDataItem item = e.Item as GridDataItem;

                int inventoryId = (int) item.GetDataKeyValue("InventoryId");

                Response.Redirect(string.Format("~/Account/RentalOrder.aspx?ID={0}", inventoryId));
            }
        }

        protected void grdresults_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem &&
                e.Item.OwnerTableView.Name.Equals("ItemDetails"))
            {
                GridDataItem item = e.Item as GridDataItem;

                GridDataItem parentItem = item.OwnerTableView.ParentItem;

                if (parentItem != null)
                {
                    int quantity = (int) parentItem.GetDataKeyValue("Quantity");

                    if (quantity == 0)
                    {
                        RadButton btnPlaceRentalOrder = item.FindControl("btnPlaceRentalOrder") as RadButton;

                        if (btnPlaceRentalOrder != null)
                        {
                            btnPlaceRentalOrder.Text = "Out of Stock";

                            btnPlaceRentalOrder.Enabled = false;
                        }
                    }
                }
            }
        }
    }
}