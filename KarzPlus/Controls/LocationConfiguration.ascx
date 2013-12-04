<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LocationConfiguration.ascx.cs" Inherits="KarzPlus.Controls.LocationConfiguration" %>

<table>
    <tr>
        <td>
            Location Name:
        </td>
        <td>
            <telerik:RadTextBox ID="txtLocationName" runat="server"  />
            <asp:RequiredFieldValidator ID="valLocationname" runat="server" ForeColor="Red" ControlToValidate="txtLocationName" Text="*" />
        </td>
    </tr>
    <tr>
        <td>
            Address:
        </td>
        <td>
            <telerik:RadTextBox ID="txtAddress" runat="server"  />
            <asp:RequiredFieldValidator ID="valAddress" runat="server" ForeColor="Red" ControlToValidate="txtAddress" Text="*" />
        </td>

        <td>
            City:
        </td>
        <td>
            <telerik:RadTextBox ID="txtCity" runat="server"  />
            <asp:RequiredFieldValidator ID="valCity" runat="server" ForeColor="Red" ControlToValidate="txtCity" Text="*" />
        </td>
            <td>
                State:
            </td>
            <td>
                <telerik:RadComboBox ID="ddlLocation" runat="server" EnableVirtualScrolling="true" MaxHeight="200px" OnLoad="ddlLocation_Load" />
                <asp:RequiredFieldValidator ID="valLocation" runat="server" ForeColor="Red" ControlToValidate="ddlLocation" InitialValue="Select One" Text="*" />
            </td>
    </tr>
    <tr>
        <td>
            Zip:
        </td>
        <td>
            <telerik:RadTextBox ID="txtZip" runat="server"  />
            <asp:RequiredFieldValidator ID="valZip" runat="server" ForeColor="Red" ControlToValidate="txtZip" Text="*" />
        </td>

        <td>
            Phone:
        </td>
        <td>
            <telerik:RadTextBox ID="txtPhone" runat="server"  />
            <asp:RequiredFieldValidator ID="valphone" runat="server" ForeColor="Red" ControlToValidate="txtPhone" Text="*" />
        </td>

        <td>
            Email:
        </td>
        <td>
            <telerik:RadTextBox ID="txtEmail" runat="server"  />
<asp:RequiredFieldValidator ID="valEmail" runat="server" ForeColor="Red" ControlToValidate="txtEmail" Text="*" />
        </td>
    </tr>
</table>
<table>
    <tr>
        <td>
            <asp:Label runat="server" ID="lblError" ForeColor="Red" />
        </td>
    </tr>
</table>
    <table>
        <tr>
            <td>
                <asp:Button ID="btnSave" Text="Save" runat="server" CommandName="Update" CausesValidation="true"  />
            </td>
            <td>
                <asp:Button ID="btnCancel" Text="Cancel" runat="server" CausesValidation="false" CommandName="Cancel" />
            </td>
        </tr>
    </table>