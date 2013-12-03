<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InventoryConfiguration.ascx.cs" Inherits="KarzPlus.Controls.InventoryConfiguration" %>

<asp:Panel ID="pnlInventoryConfiguration" runat="server">

    <table>
        <tr>
            <td>Car Make:
            </td>
            <td>
                <telerik:RadComboBox ID="ddlCarMake" AutoPostBack="true" runat="server" EnableVirtualScrolling="true" MaxHeight="200px" OnSelectedIndexChanged="ddlCarMake_SelectedIndexChanged"></telerik:RadComboBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td>Car Model:
            </td>
            <td>
                <telerik:RadComboBox ID="ddlCarModel" EnableVirtualScrolling="true" MaxHeight="200px" runat="server"></telerik:RadComboBox>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>Year:
            </td>
            <td>
                <telerik:RadNumericTextBox ID="txtyear" runat="server" MinValue="1900" MaxLength="4" MaxValue="2500"></telerik:RadNumericTextBox>
            </td>
            <td>Quantity:
            </td>
            <td>
                <telerik:RadNumericTextBox ID="txtqty" runat="server" MinValue="0"></telerik:RadNumericTextBox>
            </td>
            <td>Color:
            </td>
            <td>
                <telerik:RadTextBox ID="txtColor" runat="server"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="valcolor" runat="server" ControlToValidate="txtColor" Text="*"></asp:RequiredFieldValidator>
            </td>
            <td>Price:
            </td>
            <td>
                <telerik:RadNumericTextBox ID="txtprice" runat="server" MinValue="0" Type="Currency"></telerik:RadNumericTextBox>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                Location:
            </td>
            <td>
                <telerik:RadComboBox ID="ddlLocation" runat="server" EnableVirtualScrolling="true" MaxHeight="200px" />
            </td>
        </tr>
    </table>
</asp:Panel>
