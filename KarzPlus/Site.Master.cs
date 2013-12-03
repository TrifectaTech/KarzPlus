using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KarzPlus
{
    public partial class SiteMaster : MasterPage
    {    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session.Abandon();
        }

        protected void btnManageAccount_OnPreRender(object sender, EventArgs e)
        {
            LinkButton btnManageAccount = sender as LinkButton;

            if (btnManageAccount != null)
            {
                btnManageAccount.Text = string.Format("Hello, {0}!", HttpContext.Current.User.Identity.Name);
            }
        }
    }

}