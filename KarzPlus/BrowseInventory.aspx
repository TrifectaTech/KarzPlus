<%@ Page Language="C#" Title="Browse Inventory" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BrowseInventory.aspx.cs" Inherits="KarzPlus.BrowseInventory" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="MetroTouch" DecoratedControls="All" />
    <asp:Panel ID="pnlSearch" runat="server" HorizontalAlign="Center" GroupingText="Search">
    <table >
        <tr>
            <td>
                Car Make:
            </td>
            <td>
                <telerik:RadComboBox ID="ddlCarMake" AutoPostBack="true" runat="server" EnableVirtualScrolling="true" MaxHeight="200px" OnSelectedIndexChanged="ddlCarMake_SelectedIndexChanged"></telerik:RadComboBox>
            </td>
            <td>

            </td>
            <td>
                Location:
            </td>
            <td>
                <telerik:RadComboBox ID="ddlLocation" runat="server" EnableVirtualScrolling="true" MaxHeight="200px" OnLoad="ddlLocation_Load" />
            </td>
        </tr>
        <tr>
            <td>

            </td>
        </tr>
        <tr>
            <td>
                Car Model:
            </td>
            <td>
                <telerik:RadComboBox ID="ddlCarModel" EnableVirtualScrolling="true" MaxHeight="200px" runat="server"></telerik:RadComboBox>
            </td>
        </tr>
    </table>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblMessage" ForeColor="Red" Visible="false" Text="Please select a criteria to search on." runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    <br />
    <table style="align-content:center">
        <tr>
            <td>
                <telerik:RadButton ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_OnClick"></telerik:RadButton>
            </td>
            <td>
                <telerik:RadButton ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click"></telerik:RadButton>
            </td>
        </tr>
    </table>
</asp:Panel>
    <br />
<asp:Panel ID="pnlResults" runat="server" GroupingText="Car Inventory">
    <table>
        <tr>
            <td>
                <telerik:RadGrid ID="grdresults" AutoGenerateColumns="false" OnNeedDataSource="grdresults_NeedDataSource" runat="server"
                        OnDetailTableDataBind="grdresults_DetailTableDataBind">
                    <MasterTableView Name="CarDisplay" DataKeyNames="InventoryId, MakeId, ModelId">
                        <Columns>
                            <telerik:GridBoundColumn DataField="MakeName" HeaderText="Make" UniqueName="MakeName" />
                            <telerik:GridBoundColumn DataField="ModelName" HeaderText="Model" UniqueName="ModelName" />
                            <telerik:GridBinaryImageColumn DataField="CarImage" HeaderText="Image" UniqueName="CarImage" />
                            <telerik:GridBoundColumn DataField="Quantity" HeaderText="Inventory" UniqueName="Quantity" />
                            <telerik:GridBoundColumn DataField="FullAddress" HeaderText="Location" UniqueName="FullAddress" />
                        </Columns>
                        <DetailTables>
                            <telerik:GridTableView Name="ItemDetails" DataKeyNames="InventoryId">
                        <Columns>
                            <telerik:GridButtonColumn ButtonType="PushButton" Text="Place Rental Order" />
                            <telerik:GridBoundColumn DataField="Year" HeaderText="Car Year" UniqueName="Year" />
                            <telerik:GridBoundColumn DataField="Color" HeaderText="Color" UniqueName="Color" />
                            <telerik:GridNumericColumn DataField="Price" HeaderText="Price" UniqueName="Price" NumericType="Currency"/>
                        </Columns>
                            </telerik:GridTableView>
                        </DetailTables>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
</asp:Panel>
</asp:Content>
