using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KarzPlus.Base;

namespace KarzPlus.Account
{
    public partial class Manage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        public void HideErrorMessage()
        {
            ltErrorMessage.Text = string.Empty;
        }

        public void ShowErrorMessage(string message)
        {
            ltErrorMessage.Text = message;
        }
    }
}