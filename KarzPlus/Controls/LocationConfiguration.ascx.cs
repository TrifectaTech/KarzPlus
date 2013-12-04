using System;
using System.Web.UI;
using Telerik.Web.UI;
using KarzPlus.Entities;
using KarzPlus.Business;

namespace KarzPlus.Controls
{
	public partial class LocationConfiguration : UserControl
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

        public int LocationId
        {
            get
            {
                if (ViewState["LocationId"] == null)
                {
                    ViewState["LocationId"] = 0;
                }
                return (int)ViewState["LocationId"];
            }
            set { ViewState["LocationId"] = value; }
        }

		protected void Page_Load(object sender, EventArgs e)
		{

		}

        public bool SaveControl()
        {
            bool valid = false;
            lblError.Text = string.Empty;
            Location location = new Location();
            if (EditOption)
            {
                location = LocationManager.Load(LocationId);
            }

            location.Name = txtLocationName.Text;
            location.Address = txtAddress.Text;
            location.City = txtCity.Text;
            location.Zip = txtZip.Text;
            location.Phone = txtPhone.Text;
            location.Email = txtEmail.Text;
            location.State = ddlLocation.SelectedValue;

            string errorMessage;
            valid = LocationManager.Save(location, out errorMessage);
            lblError.Text = errorMessage;
            return valid;
        }

        public void ReloadControl()
        {
            if (EditOption)
            {
                LoadControlOnLocationId(LocationId);
            }
        }

        private void LoadControlOnLocationId(int locationId)
        {
            Location location = LocationManager.Load(locationId);

            txtLocationName.Text = location.Name;
            txtAddress.Text = location.Address;
            txtCity.Text = location.City;
            txtZip.Text = location.Zip;
            txtPhone.Text = location.Phone;
            txtEmail.Text = location.Email;

            ddlLocation.SelectedValue = location.State;
        }

        protected void ddlLocation_Load(object sender, EventArgs e)
        {
            if (ddlLocation.Items.Count == 0)
            {
                ddlLocation.Items.Add(new RadComboBoxItem("AL")); ddlLocation.Items.Add(new RadComboBoxItem("AK")); ddlLocation.Items.Add(new RadComboBoxItem("AZ")); ddlLocation.Items.Add(new RadComboBoxItem("AR")); ddlLocation.Items.Add(new RadComboBoxItem("CA"));
                ddlLocation.Items.Add(new RadComboBoxItem("CO")); ddlLocation.Items.Add(new RadComboBoxItem("CT")); ddlLocation.Items.Add(new RadComboBoxItem("DC")); ddlLocation.Items.Add(new RadComboBoxItem("DE")); ddlLocation.Items.Add(new RadComboBoxItem("FL"));
                ddlLocation.Items.Add(new RadComboBoxItem("GA")); ddlLocation.Items.Add(new RadComboBoxItem("HI")); ddlLocation.Items.Add(new RadComboBoxItem("ID")); ddlLocation.Items.Add(new RadComboBoxItem("IL")); ddlLocation.Items.Add(new RadComboBoxItem("IN"));
                ddlLocation.Items.Add(new RadComboBoxItem("IA")); ddlLocation.Items.Add(new RadComboBoxItem("KS")); ddlLocation.Items.Add(new RadComboBoxItem("KY")); ddlLocation.Items.Add(new RadComboBoxItem("LA")); ddlLocation.Items.Add(new RadComboBoxItem("ME"));
                ddlLocation.Items.Add(new RadComboBoxItem("MD")); ddlLocation.Items.Add(new RadComboBoxItem("MA")); ddlLocation.Items.Add(new RadComboBoxItem("MI")); ddlLocation.Items.Add(new RadComboBoxItem("MN")); ddlLocation.Items.Add(new RadComboBoxItem("MS"));
                ddlLocation.Items.Add(new RadComboBoxItem("MO")); ddlLocation.Items.Add(new RadComboBoxItem("MT")); ddlLocation.Items.Add(new RadComboBoxItem("NE")); ddlLocation.Items.Add(new RadComboBoxItem("NV")); ddlLocation.Items.Add(new RadComboBoxItem("NH"));
                ddlLocation.Items.Add(new RadComboBoxItem("NJ")); ddlLocation.Items.Add(new RadComboBoxItem("NH")); ddlLocation.Items.Add(new RadComboBoxItem("NY")); ddlLocation.Items.Add(new RadComboBoxItem("NC")); ddlLocation.Items.Add(new RadComboBoxItem("ND"));
                ddlLocation.Items.Add(new RadComboBoxItem("OH")); ddlLocation.Items.Add(new RadComboBoxItem("OK")); ddlLocation.Items.Add(new RadComboBoxItem("OR")); ddlLocation.Items.Add(new RadComboBoxItem("PA")); ddlLocation.Items.Add(new RadComboBoxItem("RI"));
                ddlLocation.Items.Add(new RadComboBoxItem("SC")); ddlLocation.Items.Add(new RadComboBoxItem("SD")); ddlLocation.Items.Add(new RadComboBoxItem("TN")); ddlLocation.Items.Add(new RadComboBoxItem("TX")); ddlLocation.Items.Add(new RadComboBoxItem("UT"));
                ddlLocation.Items.Add(new RadComboBoxItem("VT")); ddlLocation.Items.Add(new RadComboBoxItem("VA")); ddlLocation.Items.Add(new RadComboBoxItem("WA")); ddlLocation.Items.Add(new RadComboBoxItem("WV")); ddlLocation.Items.Add(new RadComboBoxItem("WI"));
                ddlLocation.Items.Add(new RadComboBoxItem("WY"));


                foreach (RadComboBoxItem item in ddlLocation.Items)
                {
                    item.Value = item.Text;
                }

                ddlLocation.Items.Insert(0, new RadComboBoxItem("Select One"));
                ddlLocation.SelectedIndex = 0;
            }
        }
	}
}