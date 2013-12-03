<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageLocation.aspx.cs" Inherits="KarzPlus.Admin.ManageLocation" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
	<h1>
		<asp:Label runat="server" Text="Manage Location"/>
	</h1>
	<br />
	<br />
	<telerik:RadAjaxLoadingPanel runat="server" ID="lrapLocation"/>
	<telerik:RadAjaxPanel runat="server" ID="rapLocation" LoadingPanelID="lrapLocation">
		<telerik:RadGrid runat="server" ID="grdLocation" OnNeedDataSource="grdLocation_NeedDataSource"
			OnItemDataBound="grdLocation_ItemDataBound" OnInsertCommand="grdLocation_InsertCommand"
			OnUpdateCommand="grdLocation_UpdateCommand" OnDeleteCommand="grdLocation_DeleteCommand">
			<MasterTableView Name="Location" DataKeyNames="LocationId" AutoGenerateColumns="false"
				AllowAutomaticDeletes="True" AllowAutomaticInserts="True" AllowAutomaticUpdates="True">
				<Columns>
					
				</Columns>
			</MasterTableView>
		</telerik:RadGrid>
	</telerik:RadAjaxPanel>
</asp:Content>
