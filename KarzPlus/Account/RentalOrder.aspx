<%@ Page Language="C#" Title="Place Rental Order" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="RentalOrder.aspx.cs" Inherits="KarzPlus.Account.RentalOrder" %>

<%@ Register Src="~/Controls/BillingInformation.ascx" TagPrefix="TC" TagName="transConfig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Skin="BlackMetroTouch" Behaviors="None"
        Title="Success" VisibleStatusbar="False" Modal="True" Width="1000px" Height="600px" />

    <telerik:RadCodeBlock runat="server">

        <script type="text/javascript">

            function ShowConfirmationDialog() {
                var oWnd = window.radopen('<%= ResolveUrl("~/Account/CheckoutSuccess.aspx") %>');
                oWnd.center();
            }

            function RedirectToBrowseInventory() {
                window.location.assign('<%= ResolveUrl("~/BrowseInventory.aspx") %>');
            }

        </script>

    </telerik:RadCodeBlock>

    <telerik:RadFormDecorator runat="server" ID="decorator" DecoratedControls="Default" Skin="MetroTouch" />

    <telerik:RadAjaxLoadingPanel runat="server" ID="LoadingPanel1" Skin="MetroTouch" />

    <telerik:RadAjaxPanel runat="server" ID="RadAjaxPanel1" LoadingPanelID="LoadingPanel1">

        <h2>
            <asp:Label ID="lblTitle" runat="server" /></h2>
        <br />
        <br />

        <asp:Panel runat="server" ID="pnlErrorMessage" CssClass="container alert-danger" Visible="False">
            <br />
            <br />
            <asp:Label runat="server" ID="lblError" />
            <br />
            <br />
        </asp:Panel>

        <table>
            <tr>
                <td>Speed up your checkout by loading a previously saved profile:
                </td>
                <td>
                    <telerik:RadComboBox ID="ddlUserPaymentInfo" runat="server" EnableVirtualScrolling="true" EmptyMessage="Please select payment information"
                        MaxHeight="200px" OnSelectedIndexChanged="ddlUserPaymentInfo_SelectedIndexChanged" Width="350px" AutoPostBack="True" />
                </td>
            </tr>
        </table>
        <br />

        <table>
            <tr>
                <td>Rental Start Date:
                </td>
                <td>
                    <telerik:RadDatePicker ID="dtStartDate" runat="server" MaxDate="1/1/2099" OnSelectedDateChanged="dtStartDate_OnSelectedDateChanged" AutoPostBack="True" />
                </td>

            </tr>
            <tr>
                <td>Rental End Date:
                </td>
                <td>
                    <telerik:RadDatePicker ID="dtEndDate" runat="server" MaxDate="1/1/2099" OnSelectedDateChanged="dtEndDate_OnSelectedDateChanged" AutoPostBack="True" />
                </td>

            </tr>
        </table>
        <br />
        <br />

        <table>
            <tr>
                <td>
                    <asp:Button ID="btnCalculate" runat="server" Text="Calculate Total" OnClick="btnCalculate_Click" />
                </td>
                <td>
                    <telerik:RadNumericTextBox ID="txtTotal" runat="server" Type="Currency" ReadOnly="true" />
                </td>
            </tr>
        </table>
        <br />
        <br />

        <table>
            <tr>
                <td>
                    <TC:transConfig runat="server" ID="ucPaymentForm" />
                </td>
            </tr>
        </table>
        <br />
        <br />

        <table>
            <tr>
                <td>
                    <asp:CheckBox ID="chbxTermConditions" runat="server" Text="Accept Terms And Conditions" OnCheckedChanged="chbxTermConditions_OnCheckedChanged" AutoPostBack="True" />
                </td>
            </tr>
        </table>

        <table>
            <tr>
                <td>
                    <telerik:RadButton runat="server" ID="btnPlaceRentalOrder" Text="Place Rental Order" OnClick="btnPlaceRentalOrder_OnClick" Width="150px" Height="35px" Enabled="False" />
                </td>
            </tr>
        </table>


    </telerik:RadAjaxPanel>
</asp:Content>
