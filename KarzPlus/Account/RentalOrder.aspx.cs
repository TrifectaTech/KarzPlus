using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KarzPlus.Business;
using KarzPlus.Entities;
using KarzPlus.Entities.ExtensionMethods;
using Telerik.Web.UI;
using KarzPlus.Base;
using Telerik.Web.UI.Calendar;

namespace KarzPlus.Account
{
    public partial class RentalOrder : BasePage
    {
        protected decimal RentalTotal
        {
            get
            {
                return (decimal)txtTotal.Value.GetValueOrDefault();
            }
            set
            {
                txtTotal.Value = (double)value;
            }
        }

        protected DateTime RentalDateStart
        {
            get
            {
                return dtStartDate.SelectedDate.GetValueOrDefault();
            }
            set
            {
                dtStartDate.SelectedDate = value;
            }
        }

        protected DateTime RentalDateEnd
        {
            get
            {
                return dtEndDate.SelectedDate.GetValueOrDefault();
            }
            set
            {
                dtEndDate.SelectedDate = value;
            }
        }

        private int InventoryId
        {
            get
            {
                int inventoyrId = 0;
                if (!Request.QueryString["ID"].IsNullOrWhiteSpace())
                {
                    int.TryParse(Request.QueryString["ID"], out inventoyrId);
                }

                return inventoyrId;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                lblTitle.Text = Page.Title;

                if (InventoryId == default(int))
                {
                    ConsumeGlobalErrorMessage = true;

                    GlobalErrorMessage = "*Please select a product to rent";

                    Response.Redirect("~/BrowseInventory.aspx");
                }

                SetupForm();
            }
        }

        protected void LoadddlUserPaymentInfo()
        {
            ddlUserPaymentInfo.DataSource = PaymentInfoManager.LoadByUserId(UserId).ToList();
            ddlUserPaymentInfo.DataTextField = "PaymentInfoDisplay";
            ddlUserPaymentInfo.DataValueField = "PaymentInfoId";
            ddlUserPaymentInfo.DataBind();
        }

        protected void ddlUserPaymentInfo_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            int paymentInfoId;
            if (int.TryParse(ddlUserPaymentInfo.SelectedValue, out paymentInfoId))
            {
                ucPaymentForm.ReloadOnPaymentInfoId(paymentInfoId);
            }
        }

        private void SetupForm()
        {
            LoadddlUserPaymentInfo();

            dtEndDate.MinDate = DateTime.Today;

            dtStartDate.MinDate = DateTime.Today;

            dtStartDate.SelectedDate = DateTime.Today;

            dtEndDate.SelectedDate = DateTime.Today.AddDays(1);
        }

        private void CalculateTotal()
        {
            Transaction transaction = GetTransactionFromForm();

            RentalTotal = TransactionManager.CalculateTransactionPrice(transaction);
        }

        private bool ValidateForm(out string errorMessage)
        {
            StringBuilder builder = new StringBuilder();

            Transaction rental = GetTransactionFromForm();

            if (!TransactionManager.Validate(rental, out errorMessage))
            {
                builder.Append(errorMessage);
            }

            errorMessage = builder.ToString();

            return errorMessage.IsNullOrWhiteSpace();
        }

        private Transaction GetTransactionFromForm()
        {
            Transaction tranny = new Transaction
            {
                BillingAddress = ucPaymentForm.BillingAddress,
                UserId = UserId,
                BillingCity = ucPaymentForm.BillingCity,
                BillingState = ucPaymentForm.BillingStateCode,
                BillingZip = ucPaymentForm.BillingZipCode,
                CCV = ucPaymentForm.BillingCCV,
                CreditCardNumber = ucPaymentForm.CreditCardNumber,
                ExpirationDate = ucPaymentForm.CreditCardExpirationDate,
                IsItemModified = true,
                InventoryId = InventoryId,
                IsRentalTransactionInProgress = true,
                Price = RentalTotal,
                RentalDateEnd = RentalDateEnd,
                RentalDateStart = RentalDateStart,
                TransactionDate = DateTime.Now,
                TransactionId = null
            };

            return tranny;
        }

        private void ShowErrorMessage(string errorMessage)
        {
            pnlErrorMessage.Visible = true;

            lblError.Text = errorMessage;
        }

        private void HideErrorMessage()
        {
            pnlErrorMessage.Visible = false;

            lblError.Text = string.Empty;
        }

        protected void dtStartDate_OnSelectedDateChanged(object sender, SelectedDateChangedEventArgs e)
        {
            string errorMessage;

            if (ValidateForm(out errorMessage))
            {
                CalculateTotal();
            }
        }

        protected void dtEndDate_OnSelectedDateChanged(object sender, SelectedDateChangedEventArgs e)
        {
            string errorMessage;

            if (ValidateForm(out errorMessage))
            {
                CalculateTotal();
            }
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        protected void btnPlaceRentalOrder_OnClick(object sender, EventArgs e)
        {
            Transaction newTransaction = GetTransactionFromForm();

            string errorMessage;

            HideErrorMessage();

            if (!TransactionManager.Save(newTransaction, out errorMessage))
            {
                ShowErrorMessage(errorMessage);
            }
            else
            {
                RadAjaxPanel1.ResponseScripts.Add("return ShowConfirmationDialog();");
            }
        }

        protected void chbxTermConditions_OnCheckedChanged(object sender, EventArgs e)
        {
            btnPlaceRentalOrder.Enabled = chbxTermConditions.Checked;
        }
    }
}