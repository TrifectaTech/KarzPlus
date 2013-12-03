﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageInventory.aspx.cs" MasterPageFile="~/Site.Master" Inherits="KarzPlus.Admin.ManageInventory" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
	<h1>
		<asp:Label runat="server" Text="Manage Inventory"/>
	</h1>
	<br />
	<br />
	<telerik:RadAjaxLoadingPanel runat="server" ID="lrapLocation"/>
	<telerik:RadAjaxPanel runat="server" ID="rapLocation" LoadingPanelID="lrapLocation">
		<telerik:RadGrid runat="server" ID="grdInventory" OnNeedDataSource="grdInventory_NeedDataSource"
			OnItemDataBound="grdInventory_ItemDataBound" OnInsertCommand="grdInventory_InsertCommand" Skin="MetroTouch"
			OnUpdateCommand="grdInventory_UpdateCommand" OnDeleteCommand="grdInventory_DeleteCommand" >
			<MasterTableView Name="Location" DataKeyNames="InventoryId" AutoGenerateColumns="false" AllowSorting="true" AllowFilteringByColumn="true"
				AllowAutomaticDeletes="True" AllowAutomaticInserts="True" AllowAutomaticUpdates="True" CommandItemDisplay="Top" CommandItemSettings-AddNewRecordText="Add Inventory">
				<Columns>
                    <telerik:GridEditCommandColumn EditText="Edit" ></telerik:GridEditCommandColumn>
					<telerik:GridBoundColumn HeaderText="InventoryId" UniqueName="InventoryId" DataField="InventoryId" />
                    <telerik:GridBoundColumn HeaderText="Quantity" UniqueName="Quantity" DataField="Quantity" />
                    <telerik:GridBoundColumn HeaderText="Car Year" UniqueName="CarYear" DataField="CarYear" />
                    <telerik:GridBoundColumn HeaderText="Color" UniqueName="Color" DataField="Color" />
                    <telerik:GridNumericColumn HeaderText="Price" UniqueName="Price" DataField="Price" NumericType="Currency" />
                    <telerik:GridBoundColumn HeaderText="Make" UniqueName="MakeName" DataField="MakeName" />
                    <telerik:GridBoundColumn HeaderText="Model" UniqueName="ModelName" DataField="ModelName" />
                    <telerik:GridBoundColumn HeaderText="Address" UniqueName="FullAddress" DataField="FullAddress" />
				</Columns>
			</MasterTableView>
		</telerik:RadGrid>
	</telerik:RadAjaxPanel>
</asp:Content>