using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KarzPlus.Controls
{
    public partial class CarModelConfiguration : System.Web.UI.UserControl
    {
        public bool EditOption
        {
            get
            {
                if (ViewState["EditOption"] == null)
                {
                    ViewState["EditOption"] = false;
                }
                return (bool)ViewState["EditOption"];
            }
            set { ViewState["EditOption"] = value; }
        }

        public int ModelId
        {
            get
            {
                if (ViewState["ModelId"] == null)
                {
                    ViewState["ModelId"] = 0;
                }
                return (int)ViewState["ModelId"];
            }
            set { ViewState["ModelId"] = value; }
        }   

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool SaveControl()
        {
            return true;
        }

        public void ReloadControl()
        {
        }
    }
}