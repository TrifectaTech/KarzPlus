<%@ Page Title="Manage Specials" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageSpecials.aspx.cs" Inherits="KarzPlus.Admin.ManageSpecials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <telerik:RadFormDecorator runat="server" ID="decorator" DecoratedControls="Default" Skin="MetroTouch" />

    <telerik:RadAjaxLoadingPanel runat="server" ID="LoadingPanel1" Skin="MetroTouch" />

    <telerik:RadAjaxPanel runat="server" ID="RadAjaxPanel1" LoadingPanelID="LoadingPanel1">

        <h2>
            <asp:Label ID="lblTitle" runat="server" /></h2>

        <telerik:RadGrid runat="server" ID="grdSpecials" AllowSorting="True" AllowAutomaticDeletes="False" Skin="MetroTouch"
            AllowAutomaticInserts="False" AllowAutomaticUpdates="False" AllowMultiRowEdit="False"
            AutoGenerateColumns="False"
            AllowPaging="True" OnNeedDataSource="grdSpecials_OnNeedDataSource" OnInsertCommand="grdSpecials_OnInsertCommand"
            OnUpdateCommand="grdSpecials_OnUpdateCommand" OnItemDataBound="grdSpecials_OnItemDataBound">
            <MasterTableView Name="grdSpecials" DataKeyNames="InventoryId, SpecialId" CommandItemDisplay="Top" NoMasterRecordsText="No payment information">
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
                         <asp:Panel runat="server" ID="pnlErrorMessage" Visible="False">
                            <p class="text-danger">
                                <asp:Literal runat="server" ID="ltErrorMessage" />
                            </p>
                        </asp:Panel>

                        <fieldset>
                            <legend>Save A Special</legend>
                            <table>
                                <tr>
                                    <td>
                                        Special:
                                    </td>
                                    <td>
                                        <telerik:RadComboBox runat="server" ID="ddlInventory" EnableVirtualScrolling="True" MaxHeight="200px" Width="300px" 
                                            EmptyMessage="Please select an inventory record"/>
                                        
                                        <asp:RequiredFieldValidator runat="server" ID="valInventory" InitialValue="" CssClass="text-danger"  Display="Dynamic"
                                            ErrorMessage="*Special is required" ControlToValidate="ddlInventory"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Date Start:
                                    </td>
                                    <td>
                                        <telerik:RadDatePicker runat="server" ID="dtDateStart"/>
                                        
                                        <asp:RequiredFieldValidator runat="server" ID="valDateStart" CssClass="text-danger" Display="Dynamic" 
                                            ErrorMessage="*Date Start is required" ControlToValidate="dtDateStart"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Date End:
                                    </td>
                                    <td>
                                        <telerik:RadDatePicker runat="server" ID="dtDateEnd"/>
                                        
                                        <asp:RequiredFieldValidator runat="server" ID="valDateEnd" CssClass="text-danger" Display="Dynamic" 
                                            ErrorMessage="*Date End is required" ControlToValidate="dtDateEnd"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Price:
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox runat="server" ID="txtPrice" Type="Currency" MinValue="1" MaxValue="100000"/>
                                        
                                        <asp:RequiredFieldValidator runat="server" ID="valPrice" CssClass="text-danger" Display="Dynamic" 
                                            ErrorMessage="*Price is required" ControlToValidate="dtDateEnd"/>
                                    </td>
                                </tr>
                                </table>
                            <table>
                                <tr>
                                    <td>
                                        
                                        <telerik:RadButton runat="server" ID="btnSave" CommandName="Update" Text="Save" Width="150px" Height="35px" />
                                        
                                        <telerik:RadButton runat="server" ID="btnCancel" CommandName="Cancel" Text="Cancel" CausesValidation="False" Width="150px" Height="35px" />

                                    </td>
                                </tr>
                            </table>
                    </FormTemplate>
                </EditFormSettings>
            </MasterTableView>
        </telerik:RadGrid>

    </telerik:RadAjaxPanel>

</asp:Content>
