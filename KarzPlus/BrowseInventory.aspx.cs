using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KarzPlus.Business;

namespace KarzPlus
{
    public partial class BrowseInventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
          
        protected void btnSearch_OnClick(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }

        protected void grdresults_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable)
            {
                grdresults.DataSource = CarInventoryViewManager.GetOnSearchFields(1, 1, "FL").ToList();
            }
        }

        protected void grdresults_DetailTableDataBind(object sender, Telerik.Web.UI.GridDetailTableDataBindEventArgs e)
        {

        }
    }
}