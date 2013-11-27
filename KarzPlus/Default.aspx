<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="KarzPlus._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">

        $(document).ready(function () {
            $('.bxslider').bxSlider({
                mode: 'fade',
                captions: true
            });
        });

    </script>

    <div class="jumbotron">
        <h1>KarzPlus</h1>
        <p class="lead">KarzPlus is a leading and affordable car rental agency offering a competitive solution for your rental needs</p>
    </div>

    <div class="text-center">
        <ul class="bxslider">
            <li>
                <img src="Content/Images/AltimaCoupe.jpg" title="Premium Collection - 2008 Nissan Altima 3.5 SE" width="525px" height="400px" />
            </li>
            <li>
                <img src="Content/Images/AudiA4.jpg" title="Premium Collection - 2013 Audi A4 2.0T" width="525px" height="400px" /></li>
            <li>
                <img src="Content/Images/BMW328i.jpg" title="Premium Collection - 2012 BMW 328i Sport" width="525px" height="400px" /></li>
            <li>
                <img src="Content/Images/Boss302.jpg" title="Premium Collection - 2012 Ford Boss 302" width="525px" height="400px" /></li>
        </ul>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
