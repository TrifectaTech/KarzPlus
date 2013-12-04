using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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

        protected void grdSpecials_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (e.IsFromDetailTable)
            {
                grdSpecials.DataSource = SpecialManager.LoadAll().OrderByDescending(dd => dd.SpecialId).ToList();
            }
        }

        protected void grdSpecials_OnInsertCommand(object sender, GridCommandEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void grdSpecials_OnDeleteCommand(object sender, GridCommandEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void grdSpecials_OnUpdateCommand(object sender, GridCommandEventArgs e)
        {
            throw new NotImplementedException();
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
        }
    }
}