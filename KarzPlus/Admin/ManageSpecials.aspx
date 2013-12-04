<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageSpecials.aspx.cs" Inherits="KarzPlus.Admin.ManageSpecials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <telerik:RadFormDecorator runat="server" ID="decorator" DecoratedControls="Default" Skin="MetroTouch" />

    <telerik:RadAjaxLoadingPanel runat="server" ID="LoadingPanel1" Skin="MetroTouch" />

    <telerik:RadAjaxPanel runat="server" ID="RadAjaxPanel1" LoadingPanelID="LoadingPanel1">

        <h2>
            <asp:Label ID="lblTitle" runat="server" /></h2>

        <telerik:RadGrid runat="server" ID="grdSpecials" AllowSorting="True" AllowAutomaticDeletes="False" Skin="MetroTouch"
            AllowAutomaticInserts="False" AllowAutomaticUpdates="False" Width="" AllowMultiRowEdit="False"
            AutoGenerateColumns="False"
            AllowPaging="True" OnNeedDataSource="grdSpecials_OnNeedDataSource" OnInsertCommand="grdSpecials_OnInsertCommand"
            OnDeleteCommand="grdSpecials_OnDeleteCommand" OnUpdateCommand="grdSpecials_OnUpdateCommand" OnItemDataBound="grdSpecials_OnItemDataBound">
            <MasterTableView Name="grdSpecials" DataKeyNames="InventoryId, SpecialId" CommandItemDisplay="Top">
                <Columns>
                    <telerik:GridEditCommandColumn EditText="Edit Special" />
                    <telerik:GridTemplateColumn HeaderText="Special Details">
                        <ItemTemplate>
                            <div class="panel-default">
                                <asp:Label ID="lblCarDetails" runat="server" />
                                <br />
                                <asp:Label runat="server" ID="lblLocationDetails" />
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridNumericColumn DataField="Price" UniqueName="Price" HeaderText="Special Price" NumericType="Currency"/>
                    <telerik:GridDateTimeColumn DataField="DateStart" HeaderText="Special Start Date" UniqueName="DateStart" DataFormatString="{0:MM/dd/yyyy}" />
                    <telerik:GridDateTimeColumn DataField="DateEnd" HeaderText="Special End Date" UniqueName="DateEnd" DataFormatString="{0:MM/dd/yyyy}" />
                </Columns>
                <EditFormSettings EditFormType="Template">
                    <FormTemplate>
                    </FormTemplate>
                </EditFormSettings>
            </MasterTableView>
        </telerik:RadGrid>

    </telerik:RadAjaxPanel>

</asp:Content>
