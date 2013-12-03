using System;
using System.Web.UI;

namespace KarzPlus.Controls
{
	public partial class LocationConfiguration : UserControl
	{
		public int? LocationId
		{
			get { return (int?) ViewState["SelectedLocationId"]; }
			set { ViewState["SelectedLocationId"] = value; }
		}

		protected void Page_Load(object sender, EventArgs e)
		{

		}
	}
}