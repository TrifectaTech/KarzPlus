using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KarzPlus.Base;
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}