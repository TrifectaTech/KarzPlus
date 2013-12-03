using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

    }
}