<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KarzPlus.Account.Login" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
	<asp:Login ID="lgnKarzPlus" runat="server" DisplayRememberMe="False" RememberMeSet="False" TitleText="Please Log In"
		OnLoggedIn="lgnKarzPlus_LoggedIn" OnLoginError="lgnKarzPlus_LoginError">
		<InstructionTextStyle Font-Italic="True" ForeColor="Black" />
		<LayoutTemplate>
			<div>
				<h1>
					<asp:Literal ID="LogInText" runat="server" Text="Please Log In" />
				</h1>
				<br />
			</div>
			<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" Text="User Name:" />
			<asp:TextBox ID="UserName" runat="server" />
			<asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="*User name is required."
				ToolTip="User Name is required." ValidationGroup="Login1" />
			<br />
			<asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" Text="Password:" />
			&nbsp;
                    <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="180px" />
			<asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="*Password is required."
				ToolTip="Password is required." ValidationGroup="Login1" />
			<br />
			<asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="Login1" Width="100px" />
			<br />
			<br />
			<span class="text-danger">
				<asp:Literal ID="FailureText" runat="server" EnableViewState="False" />
			</span>
		</LayoutTemplate>
		<LoginButtonStyle Width="100px" />
		<TitleTextStyle Font-Bold="True" />
	</asp:Login>
</asp:Content>
