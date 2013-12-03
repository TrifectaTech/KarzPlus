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
				grdLocation.DataSource = LocationManager.LoadAll().ToList();
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
					  
				}
			}
		}

		protected void grdLocation_InsertCommand(object sender, GridCommandEventArgs e)
		{
			throw new NotImplementedException();
		}

		protected void grdLocation_UpdateCommand(object sender, GridCommandEventArgs e)
		{
			throw new NotImplementedException();
		}

		protected void grdLocation_DeleteCommand(object sender, GridCommandEventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}