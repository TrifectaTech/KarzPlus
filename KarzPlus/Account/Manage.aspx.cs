﻿using System;
using System.Linq;
using System.Web.UI.WebControls;
using KarzPlus.Base;
using KarzPlus.Business;
using KarzPlus.Entities;
using KarzPlus.Entities.ExtensionMethods;
using Telerik.Web.UI;

namespace KarzPlus.Account
{
    public partial class Manage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblTitle.Text = Page.Title;
            }
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

        protected void grdPaymentInfo_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable)
            {
                grdPaymentInfo.DataSource =
                    PaymentInfoManager.LoadByUserId(UserId).ToList();
            }
        }

        protected void grdPaymentInfo_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem &&
                e.Item.IsInEditMode)
            {
                GridEditableItem item = e.Item as GridEditableItem;

                RadComboBox ddlStates = item.FindControl("ddlStates") as RadComboBox;

                RadButton btnSave = item.FindControl("btnSave") as RadButton;

                if (btnSave != null)
                {
                    btnSave.CommandName = "PerformInsert";

                    if (ddlStates != null)
                    {
                        if (item.ItemIndex >= 0)
                        {
                            btnSave.CommandName = "Update";

                            int paymentInfoId = (int)item.GetDataKeyValue("PaymentInfoId");

                            PaymentInfo infoFromDb = PaymentInfoManager.Load(paymentInfoId);

                            if (infoFromDb != null)
                            {
                                RadTextBox txtCreditCardNumber = item.FindControl("txtCreditCardNumber") as RadTextBox;

                                RadDatePicker dtExpirationDate = item.FindControl("dtExpirationDate") as RadDatePicker;

                                RadNumericTextBox txtCCV = item.FindControl("txtCCV") as RadNumericTextBox;

                                RadTextBox txtBillingAddress = item.FindControl("txtBillingAddress") as RadTextBox;

                                RadTextBox txtCity = item.FindControl("txtCity") as RadTextBox;

                                RadTextBox txtZip = item.FindControl("txtZip") as RadTextBox;

                                bool canEdit = txtBillingAddress != null && dtExpirationDate != null && txtCCV != null &&
                                               txtCity != null && txtZip != null && txtCreditCardNumber != null;

                                if (canEdit)
                                {
                                    txtCreditCardNumber.Text = infoFromDb.CreditCardNumber;

                                    dtExpirationDate.SelectedDate = infoFromDb.ExpirationDate;

                                    txtCCV.Value = infoFromDb.CCV;

                                    txtBillingAddress.Text = infoFromDb.BillingAddress;

                                    txtCity.Text = infoFromDb.BillingCity;

                                    txtZip.Text = infoFromDb.BillingZip;

                                    ddlStates.SelectedValue = infoFromDb.BillingState;
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void grdPaymentInfo_OnInsertCommand(object sender, GridCommandEventArgs e)
        {
            if (e.Item is GridEditableItem &&
                e.Item.OwnerTableView.Name.SafeEquals("grdPaymentInfo", StringComparison.CurrentCultureIgnoreCase))
            {
                GridEditableItem item = e.Item as GridEditableItem;

                HideErrorMessage(item);

                RadTextBox txtCreditCardNumber = item.FindControl("txtCreditCardNumber") as RadTextBox;

                RadDatePicker dtExpirationDate = item.FindControl("dtExpirationDate") as RadDatePicker;

                RadNumericTextBox txtCCV = item.FindControl("txtCCV") as RadNumericTextBox;

                RadTextBox txtBillingAddress = item.FindControl("txtBillingAddress") as RadTextBox;

                RadTextBox txtCity = item.FindControl("txtCity") as RadTextBox;

                RadTextBox txtZip = item.FindControl("txtZip") as RadTextBox;

                RadComboBox ddlStates = item.FindControl("ddlStates") as RadComboBox;

                bool canEdit = txtBillingAddress != null && dtExpirationDate != null && txtCCV != null &&
                                              txtCity != null && txtZip != null && txtCreditCardNumber != null && ddlStates != null;

                if (canEdit)
                {
                    PaymentInfo info = new PaymentInfo
                    {
                        BillingAddress = txtBillingAddress.Text,
                        BillingCity = txtCity.Text,
                        BillingState = ddlStates.SelectedValue,
                        UserId = UserId,
                        ExpirationDate = dtExpirationDate.SelectedDate.GetValueOrDefault(),
                        BillingZip = txtZip.Text,
                        CreditCardNumber = txtCreditCardNumber.Text,
                        CCV = Convert.ToInt32(txtCCV.Value),
                        IsItemModified = true
                    };

                    string errorMessage;

                    if (!PaymentInfoManager.Save(info, out errorMessage))
                    {
                        ShowErrorMessage(item, errorMessage);

                        e.Canceled = true;
                    }
                }
                else
                {
                    ShowErrorMessage(item, "*There was a problem processing your request. Please try again.");

                    e.Canceled = true;
                }
            }
        }

        protected void grdPaymentInfo_OnDeleteCommand(object sender, GridCommandEventArgs e)
        {
            if (e.Item is GridDataItem &&
                e.Item.OwnerTableView.Name.SafeEquals("grdPaymentInfo", StringComparison.CurrentCultureIgnoreCase))
            {
                GridDataItem item = e.Item as GridDataItem;

                int paymentInfoId = (int)item.GetDataKeyValue("PaymentInfoId");

                PaymentInfoManager.Delete(paymentInfoId);
            }
        }

        protected void grdPaymentInfo_OnUpdateCommand(object sender, GridCommandEventArgs e)
        {
            if (e.Item is GridDataItem &&
                e.Item.OwnerTableView.Name.SafeEquals("grdPaymentInfo", StringComparison.CurrentCultureIgnoreCase))
            {
                GridDataItem item = e.Item as GridDataItem;

                int paymentInfoId = (int)item.GetDataKeyValue("PaymentInfoId");

                HideErrorMessage(item);

                RadNumericTextBox txtCreditCardNumber = item.FindControl("txtCreditCardNumber") as RadNumericTextBox;

                RadDatePicker dtExpirationDate = item.FindControl("dtExpirationDate") as RadDatePicker;

                RadNumericTextBox txtCCV = item.FindControl("txtCCV") as RadNumericTextBox;

                RadTextBox txtBillingAddress = item.FindControl("txtBillingAddress") as RadTextBox;

                RadTextBox txtCity = item.FindControl("txtCity") as RadTextBox;

                RadTextBox txtZip = item.FindControl("txtZip") as RadTextBox;

                RadComboBox ddlStates = item.FindControl("ddlStates") as RadComboBox;

                bool canEdit = txtBillingAddress != null && dtExpirationDate != null && txtCCV != null &&
                                              txtCity != null && txtZip != null && txtCreditCardNumber != null && ddlStates != null;

                if (canEdit)
                {
                    PaymentInfo info = new PaymentInfo
                    {
                        BillingAddress = txtBillingAddress.Text,
                        BillingCity = txtCity.Text,
                        BillingState = ddlStates.SelectedValue,
                        UserId = UserId,
                        ExpirationDate = dtExpirationDate.SelectedDate.GetValueOrDefault(),
                        BillingZip = txtZip.Text,
                        CreditCardNumber = txtCreditCardNumber.Text,
                        CCV = Convert.ToInt32(txtCCV.Value),
                        IsItemModified = true
                    };

                    info.PaymentInfoId = paymentInfoId;

                    string errorMessage;

                    if (!PaymentInfoManager.Save(info, out errorMessage))
                    {
                        ShowErrorMessage(item, errorMessage);

                        e.Canceled = true;
                    }
                }
                else
                {
                    ShowErrorMessage(item, "*There was a problem processing your request. Please try again.");

                    e.Canceled = true;
                }
            }
        }

    }
}