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
            <h2>Quick</h2>
            <p>
                KarzPlus lets you rent a high quality vehicle in a few easy steps
            </p>
            <p>
                <asp:LinkButton runat="server" Text="Learn More" PostBackUrl="~/About.aspx" CssClass="btn btn-default"/>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Easy</h2>
            <p>
                KarzPlus lets you rent securely right from the comfort of your home. Create a free account and enjoy even more features.
            </p>
            <p>
                <asp:LinkButton runat="server" Text="Register" PostBackUrl="~/Register.aspx" CssClass="btn btn-default"/>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Rental</h2>
            <p>
                Let's get renting! Browse our inventory right now!
            </p>
            <p>
                <asp:LinkButton runat="server" Text="Browse" PostBackUrl="~/BrowseInventory.aspx" CssClass="btn btn-default"/>
            </p>
        </div>
    </div>

</asp:Content>
