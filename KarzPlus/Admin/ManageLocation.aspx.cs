using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KarzPlus.Business;
using KarzPlus.Controls;
using Telerik.Web.UI;

namespace KarzPlus.Admin
{
	public partial class ManageLocation : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void grdLocation_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
		{
			if (!e.IsFromDetailTable)
			{
				grdInventory.DataSource = LocationManager.LoadAll().ToList();
			}
		}

        protected void grdLocation_ItemDataBound(object sender, GridItemEventArgs e)
		{
			if (e.Item is GridEditableItem && e.Item.IsInEditMode)
			{
				GridEditableItem item = e.Item as GridEditableItem;
				LocationConfiguration userControl = item.FindControl(GridEditFormItem.EditFormUserControlID) as LocationConfiguration;
				if (userControl != null)
				{
                    if (!(item is GridEditFormInsertItem))
                    {
                        int locationId = (int)item.GetDataKeyValue("LocationId");
                        userControl.LocationId = locationId;
                        userControl.EditOption = true;
                    }

                    userControl.ReloadControl();
				}
			}
		}

        protected void grdLocation_UpdateCommand(object sender, GridCommandEventArgs e)
		{
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                GridEditableItem item = e.Item as GridEditableItem;
                LocationConfiguration userControl = item.FindControl(GridEditFormItem.EditFormUserControlID) as LocationConfiguration;
                if (userControl != null)
                {
                    userControl.SaveControl();
                }
            }
		}

        protected void grdLocation_DeleteCommand(object sender, GridCommandEventArgs e)
		{
            GridDataItem item = (e.Item as GridDataItem);
            int locationId = (int)item.GetDataKeyValue("LocationId");
            lblmessage.Text = string.Empty;
            if (InventoryManager.IsValidToRemove(locationId))
            {
                LocationManager.Delete(locationId);
            }
            else
            {
                lblmessage.Text = "There is active inventory items. Please remove inventory before removing Location.";
            }
            
		}


        protected void grdInventory_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                GridEditableItem item = e.Item as GridEditableItem;
                KarzPlus.Controls.InventoryConfiguration userControl = item.FindControl(GridEditFormItem.EditFormUserControlID) as KarzPlus.Controls.InventoryConfiguration;
                if (userControl != null)
                {
                    userControl.SaveControl();
                }
            }
        }

        protected void grdInventory_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = (e.Item as GridDataItem);
            int id = (int)item.GetDataKeyValue("InventoryId");
            InventoryManager.Delete(id);
        }

	}
}