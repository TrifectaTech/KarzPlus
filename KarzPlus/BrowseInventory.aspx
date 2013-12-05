<%@ Page Language="C#" Title="Browse Inventory" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BrowseInventory.aspx.cs" Inherits="KarzPlus.BrowseInventory" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel runat="server" ID="pnlBuffer" Visible="<%# User.Identity.IsAuthenticated %>">
        <br />
    </asp:Panel>
    
     <h2>
            <asp:Label ID="lblTitle" runat="server" /></h2>

    <telerik:RadAjaxLoadingPanel ID="loadingpnl" runat="server" Skin="MetroTouch" />
    <telerik:RadAjaxPanel ID="ajpnl" runat="server" LoadingPanelID="loadingpnl">
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="MetroTouch" DecoratedControls="Default" />
        <asp:Panel ID="pnlSearch" runat="server" CssClass="container" GroupingText="Search">
            <table>
                <tr>
                    <td>Car Make:
                    </td>
                    <td>
                        <telerik:RadComboBox ID="ddlCarMake" AutoPostBack="true" runat="server" EnableVirtualScrolling="true" MaxHeight="200px" OnSelectedIndexChanged="ddlCarMake_SelectedIndexChanged"></telerik:RadComboBox>
                    </td>
                    <td></td>
                    <td>State:
                    </td>
                    <td>
                        <telerik:RadComboBox ID="ddlLocation" runat="server" EnableVirtualScrolling="true" MaxHeight="200px" OnLoad="ddlLocation_Load" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>Car Model:
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
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_OnClick"></asp:Button>
                    </td>
                    <td>
                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click"></asp:Button>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <asp:Panel ID="pnlResults" runat="server" GroupingText="Car Inventory" CssClass="container">
            <telerik:RadGrid ID="grdresults" AutoGenerateColumns="false" OnNeedDataSource="grdresults_NeedDataSource" runat="server" Width="100%" OnItemCommand="grdresults_OnItemCommand"
                OnDetailTableDataBind="grdresults_DetailTableDataBind" Skin="MetroTouch" OnItemDataBound="grdresults_OnItemDataBound">
                <MasterTableView Name="CarDisplay" DataKeyNames="InventoryId, MakeId, ModelId, Quantity">
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

                                <telerik:GridTemplateColumn>
                                    <ItemTemplate>
                                        <telerik:RadButton runat="server" ID="btnPlaceRentalOrder" CommandName="PlaceRentalOrder" Text="Place Rental Order" Width="150px" Height="35px" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="Year" HeaderText="Car Year" UniqueName="Year" />
                                <telerik:GridBoundColumn DataField="Color" HeaderText="Color" UniqueName="Color" />
                                <telerik:GridNumericColumn DataField="Price" HeaderText="Price" UniqueName="Price" NumericType="Currency" />
                            </Columns>
                        </telerik:GridTableView>
                    </DetailTables>
                </MasterTableView>
            </telerik:RadGrid>
        </asp:Panel>
    </telerik:RadAjaxPanel>
</asp:Content>
