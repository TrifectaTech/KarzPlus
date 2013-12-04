<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageLocation.aspx.cs" Inherits="KarzPlus.Admin.ManageLocation" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
	<h1>
		<asp:Label runat="server" Text="Manage Location"/>
	</h1>
	<br />
	<br />
	<telerik:RadAjaxLoadingPanel runat="server" ID="lrapLocation"/>
	<telerik:RadAjaxPanel runat="server" ID="rapLocation" LoadingPanelID="lrapLocation">
        <asp:Label ID="lblmessage" runat="server" ForeColor="Red"></asp:Label>
        <br />

		<telerik:RadGrid runat="server" ID="grdLocation" OnNeedDataSource="grdLocation_NeedDataSource"
			OnItemDataBound="grdLocation_ItemDataBound" Skin="MetroTouch" AllowSorting="true" AllowFilteringByColumn="true"
			OnUpdateCommand="grdLocation_UpdateCommand" OnDeleteCommand="grdLocation_DeleteCommand">
			<MasterTableView Name="Location" DataKeyNames="LocationId" AutoGenerateColumns="false"
                CommandItemDisplay="Top" CommandItemSettings-AddNewRecordText="Add Location">
				<Columns>
                    <telerik:GridEditCommandColumn EditText="Edit" ></telerik:GridEditCommandColumn>
                    <telerik:GridButtonColumn CommandName="Delete" Text="Delete" ButtonType="LinkButton" />
					<telerik:GridBoundColumn HeaderText="Name" UniqueName="Name" DataField="Name" />
                    <telerik:GridBoundColumn HeaderText="Address" UniqueName="Address" DataField="Address" />
                    <telerik:GridBoundColumn HeaderText="City" UniqueName="City" DataField="City" />
                    <telerik:GridBoundColumn HeaderText="State" UniqueName="State" DataField="State" />
                    <telerik:GridBoundColumn HeaderText="Zip" UniqueName="Zip" DataField="Zip" />
                    <telerik:GridBoundColumn HeaderText="Phone" UniqueName="Phone" DataField="Phone" />
                    <telerik:GridBoundColumn HeaderText="Email" UniqueName="Email" DataField="Email" />
				</Columns>
                <EditFormSettings EditFormType="WebUserControl" UserControlName="~/Controls/LocationConfiguration.ascx"></EditFormSettings> 
			</MasterTableView>
		</telerik:RadGrid>
	</telerik:RadAjaxPanel>
</asp:Content>
