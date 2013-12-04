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
                <asp:RequiredFieldValidator ID="valmodel" runat="server" ForeColor="Red" ControlToValidate="ddlCarModel" InitialValue="Select One" Text="*" />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>Year:
            </td>
            <td>
                <telerik:RadNumericTextBox ID="txtyear" runat="server" MinValue="1900" MaxLength="4" MaxValue="2500"></telerik:RadNumericTextBox>
                <asp:RequiredFieldValidator ID="valyear" runat="server" ForeColor="Red" ControlToValidate="txtqty" Text="*" />
            </td>
            <td>Quantity:
            </td>
            <td>
                <telerik:RadNumericTextBox ID="txtqty" runat="server" MinValue="0"></telerik:RadNumericTextBox>
                <asp:RequiredFieldValidator ID="valtxtqty" runat="server" ForeColor="Red" ControlToValidate="txtqty" Text="*" />
            </td>
            <td>Color:
            </td>
            <td>
                <telerik:RadTextBox ID="txtColor" runat="server"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="valcolor" runat="server" ForeColor="Red" ControlToValidate="txtColor" Text="*" />
            </td>
            <td>Price:
            </td>
            <td>
                <telerik:RadNumericTextBox ID="txtprice" runat="server" MinValue="0" Type="Currency"></telerik:RadNumericTextBox>
                <asp:RequiredFieldValidator ID="valPrice" runat="server" ForeColor="Red" ControlToValidate="txtprice" Text="*" />
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
                <asp:RequiredFieldValidator ID="valLocation" runat="server" ForeColor="Red" ControlToValidate="ddlLocation" InitialValue="Select One" Text="*" />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:Button ID="btnSave" Text="Save" runat="server" CommandName="Update" />
            </td>
            <td>
                <asp:Button ID="btnCancel" Text="Cancel" runat="server" CommandName="Cancel" />
            </td>
        </tr>
    </table>
</asp:Panel>
