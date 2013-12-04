using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KarzPlus.Business;
using KarzPlus.Entities;
using Telerik.Web.UI;

namespace KarzPlus.Admin
{
    public partial class ManageInventory : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grdInventory_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable)
            {
                grdInventory.DataSource = CarInventoryViewManager.LoadAllActive().ToList();
            }
        }

        protected void grdInventory_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                GridEditableItem item = e.Item as GridEditableItem;
                KarzPlus.Controls.InventoryConfiguration userControl = item.FindControl(GridEditFormItem.EditFormUserControlID) as KarzPlus.Controls.InventoryConfiguration;
                if (userControl != null)
                {
                    if (!(item is GridEditFormInsertItem))
                    {
                        int inventoryId = (int)item.GetDataKeyValue("InventoryId");
                        userControl.InventoryId = inventoryId;
                        userControl.EditOption = true;
                    }

                    userControl.ReloadControl();
                }
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