using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KarzPlus.Business;
using KarzPlus.Entities;
using KarzPlus.Entities.ExtensionMethods;
using Telerik.Web.UI;
using KarzPlus.Base;

namespace KarzPlus.Controls
{
    public partial class TransactionConfiguration : BaseControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ReloadOnPaymentInfoId(int paymentInfoId)
        {
            PaymentInfo pInfo = PaymentInfoManager.Load(paymentInfoId);

            txtBillingAddress.Text = pInfo.BillingAddress;
            txtCity.Text = pInfo.BillingCity;
            ddlStates.SelectedValue = pInfo.BillingState;
            txtZip.Text = pInfo.BillingZip;
            txtCreditCardNumber.Text = pInfo.CreditCardNumber;
            txtCCV.Text = pInfo.CCV.ToString();
            dtExpirationDate.SelectedDate = pInfo.ExpirationDate;
        }

        public void HideErrorMessage(GridEditableItem item)
        {
            Panel pnlErrorMessage = item.FindControl("pnlErrorMessage") as Panel;

            Literal ltErrorMessage = item.FindControl("ltErrorMessage") as Literal;

            if (pnlErrorMessage != null &&
                ltErrorMessage != null)
            {
                pnlErrorMessage.Visible = false;

                ltErrorMessage.Text = string.Empty;
            }
        }

        public void ShowErrorMessage(GridEditableItem item, string errorMessage)
        {
            Panel pnlErrorMessage = item.FindControl("pnlErrorMessage") as Panel;

            Literal ltErrorMessage = item.FindControl("ltErrorMessage") as Literal;

            if (pnlErrorMessage != null &&
                ltErrorMessage != null)
            {
                pnlErrorMessage.Visible = true;

                ltErrorMessage.Text = errorMessage;
            }
        }

        protected void ddlState_OnLoad(object sender, EventArgs e)
        {
            RadComboBox comboBox = sender as RadComboBox;

            if (comboBox != null)
            {
                comboBox.Items.Add(new RadComboBoxItem("AL"));
                comboBox.Items.Add(new RadComboBoxItem("AK"));
                comboBox.Items.Add(new RadComboBoxItem("AZ"));
                comboBox.Items.Add(new RadComboBoxItem("AR"));
                comboBox.Items.Add(new RadComboBoxItem("CA"));
                comboBox.Items.Add(new RadComboBoxItem("CO"));
                comboBox.Items.Add(new RadComboBoxItem("CT"));
                comboBox.Items.Add(new RadComboBoxItem("DC"));
                comboBox.Items.Add(new RadComboBoxItem("DE"));
                comboBox.Items.Add(new RadComboBoxItem("FL"));
                comboBox.Items.Add(new RadComboBoxItem("GA"));
                comboBox.Items.Add(new RadComboBoxItem("HI"));
                comboBox.Items.Add(new RadComboBoxItem("ID"));
                comboBox.Items.Add(new RadComboBoxItem("IL"));
                comboBox.Items.Add(new RadComboBoxItem("IN"));
                comboBox.Items.Add(new RadComboBoxItem("IA"));
                comboBox.Items.Add(new RadComboBoxItem("KS"));
                comboBox.Items.Add(new RadComboBoxItem("KY"));
                comboBox.Items.Add(new RadComboBoxItem("LA"));
                comboBox.Items.Add(new RadComboBoxItem("ME"));
                comboBox.Items.Add(new RadComboBoxItem("MD"));
                comboBox.Items.Add(new RadComboBoxItem("MA"));
                comboBox.Items.Add(new RadComboBoxItem("MI"));
                comboBox.Items.Add(new RadComboBoxItem("MN"));
                comboBox.Items.Add(new RadComboBoxItem("MS"));
                comboBox.Items.Add(new RadComboBoxItem("MO"));
                comboBox.Items.Add(new RadComboBoxItem("MT"));
                comboBox.Items.Add(new RadComboBoxItem("NE"));
                comboBox.Items.Add(new RadComboBoxItem("NV"));
                comboBox.Items.Add(new RadComboBoxItem("NH"));
                comboBox.Items.Add(new RadComboBoxItem("NJ"));
                comboBox.Items.Add(new RadComboBoxItem("NH"));
                comboBox.Items.Add(new RadComboBoxItem("NY"));
                comboBox.Items.Add(new RadComboBoxItem("NC"));
                comboBox.Items.Add(new RadComboBoxItem("ND"));
                comboBox.Items.Add(new RadComboBoxItem("OH"));
                comboBox.Items.Add(new RadComboBoxItem("OK"));
                comboBox.Items.Add(new RadComboBoxItem("OR"));
                comboBox.Items.Add(new RadComboBoxItem("PA"));
                comboBox.Items.Add(new RadComboBoxItem("RI"));
                comboBox.Items.Add(new RadComboBoxItem("SC"));
                comboBox.Items.Add(new RadComboBoxItem("SD"));
                comboBox.Items.Add(new RadComboBoxItem("TN"));
                comboBox.Items.Add(new RadComboBoxItem("TX"));
                comboBox.Items.Add(new RadComboBoxItem("UT"));
                comboBox.Items.Add(new RadComboBoxItem("VT"));
                comboBox.Items.Add(new RadComboBoxItem("VA"));
                comboBox.Items.Add(new RadComboBoxItem("WA"));
                comboBox.Items.Add(new RadComboBoxItem("WV"));
                comboBox.Items.Add(new RadComboBoxItem("WI"));
                comboBox.Items.Add(new RadComboBoxItem("WY"));

                foreach (RadComboBoxItem item in comboBox.Items)
                {
                    item.Value = item.Text;
                }
            }
        }
    }
}