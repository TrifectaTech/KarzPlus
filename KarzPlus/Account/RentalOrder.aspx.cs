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

namespace KarzPlus.Account
{
    public partial class RentalOrder : BasePage
    {
        private int InventoryId
        {
            get
            {
                int inventoyrId = 0;
                if(!Request.QueryString["ID"].IsNullOrWhiteSpace())
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

            }
        }

        protected void LoadddlUserPaymentInfo()
        {
            ddlUserPaymentInfo.DataSource = PaymentInfoManager.LoadByUserId(UserId).ToList();
            ddlUserPaymentInfo.DataTextField = "PaymentInfoDisplay";
            ddlUserPaymentInfo.DataValueField= "PaymentInfoId";
            ddlUserPaymentInfo.DataBind();
            ddlUserPaymentInfo.Items.Insert(0, new RadComboBoxItem("Select One"));
            ddlUserPaymentInfo.SelectedIndex = 0;
        }

        protected void ddlUserPaymentInfo_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            int paymentInfoId;
            if(int.TryParse(ddlUserPaymentInfo.SelectedValue, out paymentInfoId))
            {
                trConfig.ReloadOnPaymentInfoId(paymentInfoId);
            }
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            List<Special> special = SpecialManager.LoadByInventoryId(InventoryId).ToList();
            Inventory item = InventoryManager.Load(InventoryId);

            decimal price = item.Price;
            if (special.SafeAny(t => DateTime.Now.Date.Between(t.DateStart, t.DateEnd)))
            {
                price = special.FirstOrDefault(t => DateTime.Now.Date.Between(t.DateStart, t.DateEnd)).Price;
            }

            int amtOfDays = dtStartDate.SelectedDate.Value.GetAmountOfDaysBetweenDates(dtEndDate.SelectedDate.Value);

            txtTotal.Value = (double)(price * amtOfDays);
        }
    }
}