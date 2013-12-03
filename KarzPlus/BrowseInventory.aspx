<%@ Page Language="C#" Title="Browse Inventory" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BrowseInventory.aspx.cs" Inherits="KarzPlus.BrowseInventory" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlSearch" runat="server" HorizontalAlign="Center" GroupingText="Search">
    <table >
        <tr>
            <td>
                Car Make:
            </td>
            <td>
                <telerik:RadComboBox ID="ddlCarMake" runat="server"></telerik:RadComboBox>
            </td>
            <td>

            </td>
            <td>
                Location:
            </td>
            <td>
                <telerik:RadComboBox ID="ddlLocation" runat="server"></telerik:RadComboBox>
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
                <telerik:RadComboBox ID="ddlCarModel" runat="server"></telerik:RadComboBox>
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
                    <MasterTableView Name="CarDisplay">
                        <Columns>
                            <telerik:GridBoundColumn DataField="" HeaderText="" UniqueName="" />
                            <telerik:GridBoundColumn DataField="" HeaderText="" UniqueName="" />
                            <telerik:GridBoundColumn DataField="" HeaderText="" UniqueName="" />
                            <telerik:GridBoundColumn DataField="" HeaderText="" UniqueName="" />
                            <telerik:GridBoundColumn DataField="" HeaderText="" UniqueName="" />
                            <telerik:GridBoundColumn DataField="" HeaderText="" UniqueName="" />
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
