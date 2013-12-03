<%@ Page Title="Manage Personal Information" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="KarzPlus.Account.Manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %>.</h2>

    <p class="text-danger">
        <asp:Literal runat="server" ID="ltErrorMessage" />
    </p>
    
    <telerik:RadGrid runat="server" ID="grdPaymentInfo" AllowSorting="True" AllowAutomaticDeletes="False" 
        AllowAutomaticInserts="False" AllowAutomaticUpdates="False" 
        AutoGenerateColumns="False" AllowPaging="True" />

</asp:Content>
