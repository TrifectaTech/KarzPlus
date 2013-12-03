﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KarzPlus
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void StepNextButton_OnPreRender(object sender, EventArgs e)
        {
            Button btnStepNextButton = sender as Button;

            if (btnStepNextButton != null)
            {
                Page.Form.DefaultButton = btnStepNextButton.UniqueID;
            }
        }

        protected void ContinueButton_OnPreRender(object sender, EventArgs e)
        {
            Button btnContinueButton = sender as Button;

            if (btnContinueButton != null)
            {
                btnContinueButton.Focus();
            }
        }
    }
}