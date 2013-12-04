<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TransactionConfiguration.ascx.cs" Inherits="KarzPlus.Controls.TransactionConfiguration" %>
                        <asp:Panel runat="server" ID="pnlErrorMessage" Visible="False">
                            <p class="text-danger">
                                <asp:Literal runat="server" ID="ltErrorMessage" />
                            </p>
                        </asp:Panel>

                        <fieldset>
                            <legend>Billing Information</legend>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblCreditCardNumber" Text="Credit Card Number: " />
                                    </td>
                                    <td>
                                        <telerik:RadTextBox runat="server" ID="txtCreditCardNumber" MaxLength="16"  />

                                        <asp:RequiredFieldValidator runat="server" ID="valCreditCardNumber" ControlToValidate="txtCreditCardNumber" Display="Dynamic"
                                            ErrorMessage="*Credit Card Number Is Required" ValidationGroup="PaymentInfoValidationGroup" CssClass="text-danger" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblExpirationDate" Text="Expiration Date: " />
                                    </td>
                                    <td>
                                        <telerik:RadDatePicker runat="server" ID="dtExpirationDate" MinDate="1/1/2000" MaxDate="1/1/2099" />

                                        <asp:RequiredFieldValidator runat="server" ID="valExpirationDate" ControlToValidate="dtExpirationDate" Display="Dynamic"
                                            ErrorMessage="*Expiration Date Is Required" ValidationGroup="PaymentInfoValidationGroup" CssClass="text-danger" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblCCV" Text="CCV: " />
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox runat="server" ID="txtCCV" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MaxValue="9999" />

                                        <asp:RequiredFieldValidator runat="server" ID="valCCV" ControlToValidate="txtCCV" Display="Dynamic"
                                            ErrorMessage="*CCV Is Required" ValidationGroup="PaymentInfoValidationGroup" CssClass="text-danger" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblBillingAddress" Text="Billing Address: " />
                                    </td>
                                    <td>
                                        <telerik:RadTextBox runat="server" ID="txtBillingAddress" />

                                        <asp:RequiredFieldValidator runat="server" ID="valBillingAddress" ControlToValidate="txtBillingAddress" Display="Dynamic"
                                            ErrorMessage="*Billing Address Is Required" ValidationGroup="PaymentInfoValidationGroup" CssClass="text-danger" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblCity" Text="Billing City: " />
                                    </td>
                                    <td>
                                        <telerik:RadTextBox runat="server" ID="txtCity" />

                                        <asp:RequiredFieldValidator runat="server" ID="valCity" ControlToValidate="txtCity" Display="Dynamic"
                                            ErrorMessage="*City Is Required" ValidationGroup="PaymentInfoValidationGroup" CssClass="text-danger" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblState" Text="Billing State: " />
                                    </td>
                                    <td>
                                        <telerik:RadComboBox runat="server" ID="ddlStates" EmptyMessage="Please select a state" EnableVirtualScrolling="True" MaxHeight="200px" Width="200px" OnLoad="ddlState_OnLoad" />

                                        <asp:RequiredFieldValidator runat="server" ID="valState" ControlToValidate="ddlStates" InitialValue="" Display="Dynamic"
                                            ErrorMessage="*State Is Required" ValidationGroup="PaymentInfoValidationGroup" CssClass="text-danger" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblZip" Text="Zip: " />
                                    </td>
                                    <td>
                                        <telerik:RadTextBox runat="server" ID="txtZip" />

                                        <asp:RequiredFieldValidator runat="server" ID="valZip" ControlToValidate="txtZip" Display="Dynamic"
                                            ErrorMessage="*Zip Is Required" ValidationGroup="PaymentInfoValidationGroup" CssClass="text-danger" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table> 
                                <tr>
                                    <td>
                            <telerik:RadButton runat="server" ID="btnSave" CommandName="Update" Text="Save" ValidationGroup="PaymentInfoValidationGroup" Width="150px" Height="35px" />

                                    </td>
                                    <td>

                            <telerik:RadButton runat="server" ID="btnCancel" CommandName="Cancel" Text="Cancel" CausesValidation="False" Width="150px" Height="35px" />
                                    </td>
                                </tr>
                            </table>

                            </fieldset>