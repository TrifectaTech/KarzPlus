<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CarModelConfiguration.ascx.cs" Inherits="KarzPlus.Controls.CarModelConfiguration" %>
<table>
    <tr>
                <td>
            Car Make:
        </td>
        <td>
            <telerik:RadComboBox ID="ddlCarMake" AutoPostBack="true" runat="server" EnableVirtualScrolling="true" MaxHeight="200px"></telerik:RadComboBox>
            <asp:RequiredFieldValidator ID="valMake" runat="server" ForeColor="Red" ControlToValidate="ddlCarMake" InitialValue="Select One" Text="*" />
        </td>
    </tr>
    <tr>
        <td>
            Model Name:
        </td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtModelName"></telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="valModelName" runat="server" ForeColor="Red" ControlToValidate="txtModelName" Text="*" />
        </td>
    </tr>
    <tr>
        <td>


        </td>
    </tr>
    <tr>
        <td>
            Car Image:
        </td>
        <td>
        </td>
    </tr>
</table>