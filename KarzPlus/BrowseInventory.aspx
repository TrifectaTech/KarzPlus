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
                            <telerik:GridBoundColumn DataField="MakeName" HeaderText="MakeName" UniqueName="MakeName" />
                            <telerik:GridBoundColumn DataField="ModelName" HeaderText="ModelName" UniqueName="ModelName" />
                            <telerik:GridBinaryImageColumn DataField="CarImage" HeaderText="CarImage" UniqueName="CarImage" />
                            <telerik:GridBoundColumn DataField="Color" HeaderText="Color" UniqueName="Color" />
                            <telerik:GridBoundColumn DataField="CarYear" HeaderText="CarYear" UniqueName="CarYear" />
                            <telerik:GridBoundColumn DataField="Price" HeaderText="Price" UniqueName="Price" />
                            <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" UniqueName="Quantity" />
                            <telerik:GridBoundColumn DataField="FullAddress" HeaderText="FullAddress" UniqueName="FullAddress" />
                        </Columns>
                        <DetailTables>
                            <telerik:GridTableView Name="ItemDetails">
                        <Columns>
                            <telerik:GridBoundColumn DataField="" HeaderText="" UniqueName="" />
                            <telerik:GridBoundColumn DataField="" HeaderText="" UniqueName="" />
                            <telerik:GridBoundColumn DataField="" HeaderText="" UniqueName="" />
                            <telerik:GridBoundColumn DataField="" HeaderText="" UniqueName="" />
                            <telerik:GridBoundColumn DataField="" HeaderText="" UniqueName="" />
                            <telerik:GridBoundColumn DataField="" HeaderText="" UniqueName="" />
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
