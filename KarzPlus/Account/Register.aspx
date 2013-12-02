<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="KarzPlus.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
	<h2><%: Title %>.</h2>
	<p class="text-danger">
		<asp:Literal runat="server" ID="ErrorMessage" />
	</p>

	<div class="form-horizontal">
		<h4>Create a new account.</h4>
		<hr />
		<asp:CreateUserWizard runat="server" ID="cuwUserWizard" ContinueDestinationPageUrl="~/Default.aspx" LoginCreatedUser="True" />
		<%--<asp:ValidationSummary runat="server" CssClass="text-danger" />
		<div class="form-group">
			<asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="col-md-2 control-label" Text="Email" />
			<div class="col-md-10">
				<asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
				<asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" CssClass="text-danger" ErrorMessage="The email field is required." />
			</div>
		</div>
		<div class="form-group">
			<asp:Label runat="server" AssociatedControlID="txtUsername" CssClass="col-md-2 control-label" Text="Username" />
			<div class="col-md-10">
				<asp:TextBox runat="server" ID="txtUsername" CssClass="form-control" />
				<asp:RequiredFieldValidator runat="server" ControlToValidate="txtUsername" CssClass="text-danger" ErrorMessage="The user name field is required." />
			</div>
		</div>
		<div class="form-group">
			<asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="col-md-2 control-label" Text="Password" />
			<div class="col-md-10">
				<asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" />
				<asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" CssClass="text-danger" ErrorMessage="The password field is required." />
			</div>
		</div>
		<div class="form-group">
			<asp:Label runat="server" AssociatedControlID="txtPasswordConfirmation" CssClass="col-md-2 control-label" Text="Confirm password" />
			<div class="col-md-10">
				<asp:TextBox runat="server" ID="txtPasswordConfirmation" TextMode="Password" CssClass="form-control" />
				<asp:RequiredFieldValidator runat="server" ControlToValidate="txtPasswordConfirmation" CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
				<asp:CompareValidator runat="server" ControlToCompare="txtPassword" ControlToValidate="txtPasswordConfirmation" CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
			</div>
		</div>
		<div class="form-group">
			<div class="col-md-offset-2 col-md-10">
				<asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
			</div>
		</div>--%>
	</div>
</asp:Content>
