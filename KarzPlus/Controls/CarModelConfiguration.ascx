<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CarModelConfiguration.ascx.cs" Inherits="KarzPlus.Controls.CarModelConfiguration" %>
<table>
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
            <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server" MaxFileInputsCount="1" TemporaryFileExpiration="1"></telerik:RadAsyncUpload>
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