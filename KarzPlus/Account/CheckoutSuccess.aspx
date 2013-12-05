<%@ Page Title="Success" Language="C#" AutoEventWireup="true" CodeBehind="CheckoutSuccess.aspx.cs" Inherits="KarzPlus.Account.CheckoutSuccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />

</head>
<body class="alert-dismissable">
    <form id="form1" runat="server">

        <script type="text/javascript">

            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog  
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz az well)  

                return oWindow;
            }

            function CloseAndReload() {

                var radWindow = GetRadWindow();

                radWindow.close();

                radWindow.BrowserWindow.RedirectToBrowseInventory();

            }

        </script>

        <div class="container">
            <h3>Congratulations! You have successfully checked out!
            </h3>
            <h4>Thanks for choosing KarzPlus. You will receive an email confirmation shortly.
            </h4>

            <br />
            <asp:Button runat="server" ID="btnClose" CssClass="btn btn-lg" Text="Close" OnClientClick="CloseAndReload()" />
        </div>
    </form>
</body>
</html>
