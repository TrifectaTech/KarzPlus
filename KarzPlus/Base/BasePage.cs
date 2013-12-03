using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace KarzPlus.Base
{
    public class BasePage : System.Web.UI.Page
    {
        public string Username
        {
            get
            {
                return Page.User.Identity.Name;
            }
        }

        public Guid UserId
        {
            get
            {
                var membershipUser = Membership.GetUser(Username);
                if (membershipUser != null && membershipUser.ProviderUserKey != null)
                {
                    Guid userId = Guid.Parse(membershipUser.ProviderUserKey.ToString());

                    return userId;
                }

                return Guid.Empty;
            }
        }

    }
}