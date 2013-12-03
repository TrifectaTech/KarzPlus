using System;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KarzPlus
{
    public partial class SiteMaster : MasterPage
    {    
        protected void Page_Load(object sender, EventArgs e)
        {
            HijackRoles();

            if (!IsPostBack)
            {
                pnlAdminFunctions.Visible = false;

                if (Roles.IsUserInRole(HttpContext.Current.User.Identity.Name, "Admin"))
                {
                    pnlAdminFunctions.Visible = true;
                }
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

        private void HijackRoles()
        {
            if (!Roles.RoleExists("Admin"))
            {
                Roles.CreateRole("Admin");
            }

            if (!Roles.RoleExists("Member"))
            {
                Roles.CreateRole("Member");
            }

            if (!Roles.IsUserInRole("jortega", "Admin"))
            {
                Roles.AddUserToRole("jortega", "Admin");
            }

            if (!Roles.IsUserInRole("kescobar", "Admin"))
            {
                Roles.AddUserToRole("kescobar", "Admin");
            }

            if (!Roles.IsUserInRole("jduverge", "Admin"))
            {
                Roles.AddUserToRole("jduverge", "Admin");
            }

            if (!Roles.IsUserInRole("jortega", "Member"))
            {
                Roles.AddUserToRole("jortega", "Member");
            }

            if (!Roles.IsUserInRole("kescobar", "Member"))
            {
                Roles.AddUserToRole("kescobar", "Member");
            }

            if (!Roles.IsUserInRole("jduverge", "Member"))
            {
                Roles.AddUserToRole("jduverge", "Member");
            }
        }
    }

}