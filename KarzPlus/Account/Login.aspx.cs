using System.Web.Security;
using KarzPlus.Entities.ExtensionMethods;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace KarzPlus.Account
{
	public partial class Login : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			lgnKarzPlus.Focus();
			if (User.Identity.IsAuthenticated)
			{
				Response.Redirect("~/Default.aspx");
			}
		}

		protected void lgnKarzPlus_LoggedIn(object sender, EventArgs e)
		{
			Response.Redirect("~/Default.aspx");
		}

		protected void lgnKarzPlus_LoginError(object sender, EventArgs e)
		{
			MembershipUser membershipUser = Membership.GetUser(lgnKarzPlus.UserName);
			lgnKarzPlus.FailureText
				= membershipUser != null && membershipUser.IsLockedOut
					? @"You are locked out. Please contact the administrator."
					: @"Your login attempt was not successful. Please try again.";
		}
	}
}