<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="RentalOrder.aspx.cs" Inherits="KarzPlus.Account.RentalOrder" %>

<%@ Register Src="~/Controls/TransactionConfiguration.ascx" TagPrefix="TC" TagName="transConfig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadFormDecorator runat="server" ID="decorator" DecoratedControls="Default" Skin="MetroTouch" />

    <telerik:RadAjaxLoadingPanel runat="server" ID="LoadingPanel1" Skin="MetroTouch" />

    <telerik:RadAjaxPanel runat="server" ID="RadAjaxPanel1" LoadingPanelID="LoadingPanel1">

        <h2><asp:Label ID="lblTitle" runat="server" /></h2>
        <br />
        <br />
        <table>
            <tr>
                <td>
                    <telerik:RadComboBox ID="ddlUserPaymentInfo" runat="server" EnableVirtualScrolling="true" MaxHeight="200px" OnSelectedIndexChanged="ddlUserPaymentInfo_SelectedIndexChanged" ></telerik:RadComboBox>
                </td>
            </tr>
        </table>
        <br />

        <table>
            <tr>
                <td>
                    Rental Start Date:
                </td>
                <td>
                    <telerik:RadDatePicker ID="dtStartDate" runat="server"></telerik:RadDatePicker>
                </td>

            </tr>
          <tr>
                <td>
                    Rental End Date:
                </td>
                <td>
                    <telerik:RadDatePicker ID="dtEndDate" runat="server"></telerik:RadDatePicker>
                </td>

            </tr>
        </table>
        <br />
        <br />

        <table>
            <tr>
                <td>
                    <asp:Button ID="btnCalculate" runat="server" Text="Calculate Total" OnClick="btnCalculate_Click"/>
                </td>
                <td>
                    <telerik:RadNumericTextBox ID="txtTotal" runat="server" Type="Currency" ReadOnly="true"></telerik:RadNumericTextBox>
                </td>
            </tr>
        </table>
        <br />
        <br />

        <table>
            <tr>
                <td>
                    <TC:transConfig runat="server" ID="trConfig" />
                </td>
            </tr>
        </table>
        <br />
        <br />

        <table>
            <tr>
                <td>
                    <asp:CheckBox ID="chbxTermConditions" runat="server" Text="Accept Terms And Conditions" />
                </td>
            </tr>
        </table>

    </telerik:RadAjaxPanel>
</asp:Content>
