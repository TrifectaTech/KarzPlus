<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LocationConfiguration.ascx.cs" Inherits="KarzPlus.Controls.LocationConfiguration" %>

<table>
    <tr>
        <td>
            Location Name:
        </td>
        <td>
            <telerik:RadTextBox ID="txtLocationName" runat="server"  />
        </td>
    </tr>
    <tr>
        <td>
            Address:
        </td>
        <td>
            <telerik:RadTextBox ID="txtAddress" runat="server"  />
        </td>

        <td>
            City:
        </td>
        <td>
            <telerik:RadTextBox ID="txtCity" runat="server"  />
        </td>
            <td>
                State:
            </td>
            <td>
                <telerik:RadComboBox ID="ddlLocation" runat="server" EnableVirtualScrolling="true" MaxHeight="200px" OnLoad="ddlLocation_Load" />
            </td>
    </tr>
    <tr>
        <td>
            Zip:
        </td>
        <td>
            <telerik:RadTextBox ID="txtZip" runat="server"  />
        </td>

        <td>
            Phone:
        </td>
        <td>
            <telerik:RadTextBox ID="txtPhone" runat="server"  />
        </td>

        <td>
            Email:
        </td>
        <td>
            <telerik:RadTextBox ID="txtEmail" runat="server"  />
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