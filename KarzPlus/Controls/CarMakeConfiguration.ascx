﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CarMakeConfiguration.ascx.cs" Inherits="KarzPlus.Controls.CarMakeConfiguration" %>
<table>
    <tr>
        <td>
            Make Name:
        </td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtMakeName"></telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="valmakename" runat="server" ForeColor="Red" ControlToValidate="txtMakeName" Text="*" />
        </td>
    </tr>
    <tr>
        <td>


        </td>
    </tr>
    <tr>
        <td>
            Manufacturer:
        </td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtManufacturer"></telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="valMfg" runat="server" ForeColor="Red" ControlToValidate="txtManufacturer" Text="*" />
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