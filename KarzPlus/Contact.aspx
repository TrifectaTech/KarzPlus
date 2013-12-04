<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="KarzPlus.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>We want you to! Really!</h3>
    <address>
        One KarzPlus Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>

    <address>
        <strong>Technical Support:</strong>   <a href="mailto:Support@example.com">Support@KarzPlus.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@KarzPlus.com</a>
    </address>
</asp:Content>
