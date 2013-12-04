<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageCars.aspx.cs" Inherits="KarzPlus.Admin.ManageCars" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblmessage" runat="server" ForeColor="Red"></asp:Label>
		<telerik:RadGrid runat="server" ID="grdCars" OnNeedDataSource="grdCars_NeedDataSource"
			OnItemDataBound="grdCars_ItemDataBound" Skin="MetroTouch" OnDetailTableDataBind="grdCars_DetailTableDataBind"
			OnUpdateCommand="grdCars_UpdateCommand" OnDeleteCommand="grdCars_DeleteCommand" >
			<MasterTableView Name="Makes" DataKeyNames="MakeId" AutoGenerateColumns="false" AllowSorting="true" AllowFilteringByColumn="true"
				CommandItemDisplay="Top" CommandItemSettings-AddNewRecordText="Add Car Make">
				<Columns>
                    <telerik:GridEditCommandColumn EditText="Edit" ></telerik:GridEditCommandColumn>
                    <telerik:GridButtonColumn CommandName="Delete" Text="Delete" ButtonType="LinkButton" />
					<telerik:GridBoundColumn HeaderText="Make Name" UniqueName="Name" DataField="Name" />
                    <telerik:GridBoundColumn HeaderText="Manufacturer" UniqueName="Manufacturer" DataField="Manufacturer" />
				</Columns>
                <EditFormSettings EditFormType="WebUserControl" UserControlName="~/Controls/CarMakeConfiguration.ascx"></EditFormSettings> 
                <DetailTables>
                    <telerik:GridTableView Name="Models" DataKeyNames="ModelId" AllowSorting="true" AllowFilteringByColumn="true"
				CommandItemDisplay="Top" CommandItemSettings-AddNewRecordText="Add Car Model" AutoGenerateColumns="false">
                        <Columns>
                            <telerik:GridEditCommandColumn EditText="Edit" ></telerik:GridEditCommandColumn>
                            <telerik:GridButtonColumn CommandName="Delete" Text="Delete" ButtonType="LinkButton" />
					        <telerik:GridBoundColumn HeaderText="Model Name" UniqueName="Name" DataField="Name" />
                            <telerik:GridBinaryImageColumn DataField="CarImage" HeaderText="Image" UniqueName="CarImage" />
                        </Columns>
                        <EditFormSettings EditFormType="WebUserControl" UserControlName="~/Controls/CarModelConfiguration.ascx"></EditFormSettings> 
                    </telerik:GridTableView>
                </DetailTables>
			</MasterTableView>
		</telerik:RadGrid>
</asp:Content>
