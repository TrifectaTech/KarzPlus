using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;
using KarzPlus.Base;
using KarzPlus.Business;
using KarzPlus.Entities;
using Telerik.Web.UI;

namespace KarzPlus.Admin
{
    public partial class ManageSpecials : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblTitle.Text = Page.Title;
            }
        }

        public void HideErrorMessage(GridEditableItem item)
        {
            Panel pnlErrorMessage = item.FindControl("pnlErrorMessage") as Panel;

            Literal ltErrorMessage = item.FindControl("ltErrorMessage") as Literal;

            if (pnlErrorMessage != null &&
                ltErrorMessage != null)
            {
                pnlErrorMessage.Visible = false;

                ltErrorMessage.Text = string.Empty;
            }
        }

        public void ShowErrorMessage(GridEditableItem item, string errorMessage)
        {
            Panel pnlErrorMessage = item.FindControl("pnlErrorMessage") as Panel;

            Literal ltErrorMessage = item.FindControl("ltErrorMessage") as Literal;

            if (pnlErrorMessage != null &&
                ltErrorMessage != null)
            {
                pnlErrorMessage.Visible = true;

                ltErrorMessage.Text = errorMessage;
            }
        }

        protected void grdSpecials_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable)
            {
                grdSpecials.DataSource = SpecialManager.LoadAll().OrderByDescending(dd => dd.SpecialId).ToList();
            }
        }

        protected void grdSpecials_OnInsertCommand(object sender, GridCommandEventArgs e)
        {
            if (e.Item is GridEditableItem)
            {
                GridEditableItem item = e.Item as GridEditableItem;

                RadComboBox ddlInventory = item.FindControl("ddlInventory") as RadComboBox;

                RadDatePicker dtDateStart = item.FindControl("dtDateStart") as RadDatePicker;

                RadDatePicker dtDateEnd = item.FindControl("dtDateEnd") as RadDatePicker;

                RadNumericTextBox txtPrice = item.FindControl("txtPrice") as RadNumericTextBox;

                HideErrorMessage(item);

                if (ddlInventory != null &&
                    dtDateStart != null &&
                    dtDateEnd != null &&
                    txtPrice != null)
                {
                    Special special = new Special
                    {
                        InventoryId = Convert.ToInt32(ddlInventory.SelectedValue),
                        DateStart = dtDateStart.SelectedDate.GetValueOrDefault(),
                        DateEnd = dtDateEnd.SelectedDate.GetValueOrDefault(),
                        Price = (decimal) txtPrice.Value.GetValueOrDefault()
                    };

                    string errorMessage;

                    if (!SpecialManager.Save(special, out errorMessage))
                    {
                        e.Canceled = true;

                        ShowErrorMessage(item, errorMessage);
                    }
                }
            }
        }

        protected void grdSpecials_OnUpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem item = e.Item as GridEditableItem;

            RadComboBox ddlInventory = item.FindControl("ddlInventory") as RadComboBox;

            RadDatePicker dtDateStart = item.FindControl("dtDateStart") as RadDatePicker;

            RadDatePicker dtDateEnd = item.FindControl("dtDateEnd") as RadDatePicker;

            RadNumericTextBox txtPrice = item.FindControl("txtPrice") as RadNumericTextBox;

            HideErrorMessage(item);

            if (ddlInventory != null &&
                   dtDateStart != null &&
                   dtDateEnd != null &&
                   txtPrice != null)
            {
                Special special = new Special
                {
                    InventoryId = Convert.ToInt32(ddlInventory.SelectedValue),
                    DateStart = dtDateStart.SelectedDate.GetValueOrDefault(),
                    DateEnd = dtDateEnd.SelectedDate.GetValueOrDefault(),
                    Price = (decimal)txtPrice.Value.GetValueOrDefault(),
                    SpecialId = (int)item.GetDataKeyValue("SpecialId")
                };

                string errorMessage;

                if (!SpecialManager.Save(special, out errorMessage))
                {
                    e.Canceled = true;

                    ShowErrorMessage(item, errorMessage);
                }
            }
        }

        private void LoadDropdownSpecials(RadComboBox box)
        {
            box.Items.Clear();

            List<Inventory> allInventories = InventoryManager.LoadAll().ToList();

            foreach (Inventory inventory in allInventories)
            {
                CarModel model = CarModelManager.Load(inventory.ModelId);

                CarMake make = CarMakeManager.Load(model.MakeId);

                Location location = LocationManager.Load(inventory.LocationId);

                string formattedString = string.Format("{0} at {1}", model.Name + " " + make.Name, location.Name + " " + location.FullAddress);

                box.Items.Add(new RadComboBoxItem(formattedString, inventory.InventoryId.ToString()));
            }
        }

        protected void grdSpecials_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem &&
                e.Item.OwnerTableView.Name.Equals("grdSpecials"))
            {
                GridDataItem item = e.Item as GridDataItem;

                int inventoryId = (int)item.GetDataKeyValue("InventoryId");

                Inventory inventory = InventoryManager.Load(inventoryId);

                if (inventory != null)
                {
                    CarModel model = CarModelManager.Load(inventory.ModelId);

                    CarMake make = CarMakeManager.Load(model.MakeId);

                    Location location = LocationManager.Load(inventory.LocationId);

                    Label lblCarDetails = item.FindControl("lblCarDetails") as Label;

                    Label lblLocationDetails = item.FindControl("lblLocationDetails") as Label;

                    if (lblCarDetails != null &&
                        lblLocationDetails != null)
                    {
                        string carDetailsText = string.Format("{0} {1}", make.Name, model.Name);

                        string locationsDetailsText = string.Format("{0} {1}", location.Name, location.FullAddress);

                        lblCarDetails.Text = carDetailsText;

                        lblLocationDetails.Text = locationsDetailsText;
                    }
                }
            }

            if (e.Item is GridEditableItem &&
                e.Item.OwnerTableView.Name.Equals("grdSpecials") &&
                e.Item.IsInEditMode)
            {
                GridEditableItem item = e.Item as GridEditableItem;

                Special dataItem = item.DataItem as Special;

                RadComboBox ddlInventory = item.FindControl("ddlInventory") as RadComboBox;

                RadDatePicker dtDateStart = item.FindControl("dtDateStart") as RadDatePicker;

                RadDatePicker dtDateEnd = item.FindControl("dtDateEnd") as RadDatePicker;

                RadNumericTextBox txtPrice = item.FindControl("txtPrice") as RadNumericTextBox;

                RadButton btnSave = item.FindControl("btnSave") as RadButton;

                if (ddlInventory != null &&
                    dtDateStart != null &&
                    dtDateEnd != null &&
                    txtPrice != null &&
                    btnSave != null)
                {
                    LoadDropdownSpecials(ddlInventory);

                    if (item.ItemIndex >= 0)
                    {
                        if (dataItem != null)
                        {
                            ddlInventory.SelectedValue = dataItem.InventoryId.ToString(CultureInfo.InvariantCulture);

                            dtDateStart.SelectedDate = dataItem.DateStart;

                            dtDateEnd.SelectedDate = dataItem.DateEnd;

                            txtPrice.Value = (double) dataItem.Price;

                            btnSave.CommandName = "Update";
                        }
                    }
                    else
                    {
                        dtDateStart.SelectedDate = DateTime.Today;

                        dtDateEnd.SelectedDate = DateTime.Today;

                        btnSave.CommandName = "PerformInsert";
                    }
                }
            }
        }
    }
}