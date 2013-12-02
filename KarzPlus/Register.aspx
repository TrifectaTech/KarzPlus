<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="KarzPlus.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
	<h2><%: Title %>.</h2>
	<p class="text-danger">
		<asp:Literal runat="server" ID="ErrorMessage" />
	</p>

	<div class="form-horizontal">
		<h4>Create a new account.</h4>
		<hr />
		<asp:CreateUserWizard runat="server" ID="cuwUserWizard" ContinueDestinationPageUrl="~/Default.aspx" LoginCreatedUser="True" MembershipProvider="KarzPlusAspNetSqlMembershipProvider" />
	</div>
</asp:Content>
