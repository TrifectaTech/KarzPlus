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
        <div class="container text-center">
            <ul class="bxslider">
                <li>
                    <img src="Content/Images/BMWX6.jpg" title="Premium Collection - 2013 BMW X6" />
                </li>
                <li>
                    <img src="Content/Images/GT3.jpg" title="Premium Collection - 2010 GT3 LeMans Champion" /></li>
                <li>
                    <img src="Content/Images/Bugatti.jpg" title="Premium Collection - 2011 Bugatti SS" /></li>
                <li>
                    <img src="Content/Images/GTR.jpg" title="Premium Collection - 2012 Nissan GTR" /></li>
                <li>
                    <img src="Content/Images/TheBoss.jpg" title="Premium Collection - 2012 Ford Boss 302" /></li>
            </ul>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <h2>Quick</h2>
            <p>
                KarzPlus lets you rent a high quality vehicle in a few easy steps
            </p>
            <p>
                <asp:LinkButton runat="server" Text="Learn More" PostBackUrl="~/About.aspx" CssClass="btn btn-default" />
            </p>
        </div>
        <div class="col-md-4">
            <h2>Easy</h2>
            <p>
                KarzPlus lets you rent securely right from the comfort of your home. Create a free account and enjoy even more features.
            </p>
            <p>
                <asp:LinkButton runat="server" Text="Register" PostBackUrl="~/Register.aspx" CssClass="btn btn-default" />
            </p>
        </div>
        <div class="col-md-4">
            <h2>Rental</h2>
            <p>
                Let's get renting! Browse our inventory right now!
            </p>
            <p>
                <asp:LinkButton runat="server" Text="Browse" PostBackUrl="~/BrowseInventory.aspx" CssClass="btn btn-default" />
            </p>
        </div>
    </div>

</asp:Content>
