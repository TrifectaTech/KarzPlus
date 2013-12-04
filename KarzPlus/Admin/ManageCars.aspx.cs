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
using KarzPlus.Controls;

namespace KarzPlus.Admin
{
    public partial class ManageCars : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grdCars_DetailTableDataBind(object sender, Telerik.Web.UI.GridDetailTableDataBindEventArgs e)
        {
            if (e.DetailTableView.Name.SafeEquals("Models"))
            {
                int makeId = (int)e.DetailTableView.ParentItem.GetDataKeyValue("MakeId");
                e.DetailTableView.DataSource = CarModelManager.LoadOnMakeId(makeId).ToList();
            }
        }

        protected void grdCars_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode && e.Item.OwnerTableView.Name.SafeEquals("Makes"))
            {
                GridEditableItem item = e.Item as GridEditableItem;
                CarMakeConfiguration userControl = item.FindControl(GridEditFormItem.EditFormUserControlID) as CarMakeConfiguration;
                if (userControl != null)
                {
                    e.Canceled = !userControl.SaveControl();
                }
            }

            if (e.Item is GridEditableItem && e.Item.IsInEditMode && e.Item.OwnerTableView.Name.SafeEquals("Models"))
            {
                GridEditableItem item = e.Item as GridEditableItem;
                CarModelConfiguration userControl = item.FindControl(GridEditFormItem.EditFormUserControlID) as CarModelConfiguration;
                if (userControl != null)
                {
                    e.Canceled = !userControl.SaveControl();
                }
            }
        }

        protected void grdCars_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            GridDataItem item = (e.Item as GridDataItem);
            if (item.OwnerTableView.Name.SafeEquals("Makes"))
            {
                int makeId = (int)item.GetDataKeyValue("MakeId");
                lblmessage.Text = string.Empty;
                if (CarMakeManager.IsValidToRemove(makeId))
                {
                    CarMakeManager.Delete(makeId);
                }
                else
                {
                    lblmessage.Text = "There is an active Car Model. Please remove Car Model before removing Car Make.";
                }
            }

            if (item.OwnerTableView.Name.SafeEquals("Models"))
            {
                int modelId = (int)item.GetDataKeyValue("ModelId");
                lblmessage.Text = string.Empty;
                if (CarModelManager.IsValidToRemove(modelId))
                {
                    CarModelManager.Delete(modelId);
                }
                else
                {
                    lblmessage.Text = "There is active inventory item. Please remove inventory before removing Car Model.";
                }
            }
        }

        protected void grdCars_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode && e.Item.OwnerTableView.Name.SafeEquals("Makes"))
            {
                GridEditableItem item = e.Item as GridEditableItem;
                CarMakeConfiguration userControl = item.FindControl(GridEditFormItem.EditFormUserControlID) as CarMakeConfiguration;
                if (userControl != null)
                {
                    if (!(item is GridEditFormInsertItem))
                    {
                        int makeId = (int)item.GetDataKeyValue("MakeId");
                        userControl.MakeId = makeId;
                        userControl.EditOption = true;
                    }

                    userControl.ReloadControl();
                }
            }

            if (e.Item is GridEditableItem && e.Item.IsInEditMode && e.Item.OwnerTableView.Name.SafeEquals("Models"))
            {
                GridEditableItem item = e.Item as GridEditableItem;
                CarModelConfiguration userControl = item.FindControl(GridEditFormItem.EditFormUserControlID) as CarModelConfiguration;
                if (userControl != null)
                {
                    int makeId = (int)e.Item.OwnerTableView.ParentItem.GetDataKeyValue("MakeId");
                    userControl.MakeId = makeId;

                    if (!(item is GridEditFormInsertItem))
                    {
                        int modelId = (int)item.GetDataKeyValue("ModelId");
                        userControl.ModelId = modelId;
                        userControl.EditOption = true;
                    }

                    userControl.ReloadControl();
                }
            }
        }

        protected void grdCars_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable)
            {
                grdCars.DataSource = CarMakeManager.LoadAll().ToList();
            }
        }
    }
}