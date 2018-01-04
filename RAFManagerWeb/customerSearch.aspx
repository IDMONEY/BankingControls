<%@ Page Language="C#" MasterPageFile="~/ui/master/Default.Master" AutoEventWireup="true"
    CodeBehind="customerSearch.aspx.cs" Inherits="RAFManagerWeb.customerSearch" Title="Untitled Page" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="Web20" />
    <asp:SqlDataSource ID="custIDTypesDS" runat="server" ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>"
        SelectCommand="meta_getLanguage" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="2" Name="Language" Type="Int32" />
            <asp:Parameter DefaultValue="6" Name="Type" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <h1>
        Buscar Cliente</h1>
    <fieldset>
        <legend>Criterios de Búsqueda</legend>
        <div class="form">
            <h3>
                Nombre:</h3>
            <div class="fieldRow">
                <asp:Label ID="nameL" runat="server" CssClass="formLabel" AssociatedControlID="nameT">Nombre: </asp:Label>
                <telerik:RadTextBox ID="nameT" runat="server">
                </telerik:RadTextBox>
            </div>
            <div class="fieldRow">
                <asp:Label ID="lastNameL" runat="server" CssClass="formLabel" AssociatedControlID="lastNameT">Apellidos: </asp:Label>
                <telerik:RadTextBox ID="lastNameT" runat="server">
                </telerik:RadTextBox><telerik:RadTextBox ID="lastName2T" runat="server">
                </telerik:RadTextBox>
            </div>
            <div class="fieldRow">
                <asp:Label ID="companyNameL" runat="server" CssClass="formLabel" AssociatedControlID="companyNameT">Razón Social: </asp:Label>
                <telerik:RadTextBox ID="companyNameT" CssClass="inputDoubleWidth" runat="server">
                </telerik:RadTextBox>
            </div>
            <h3>
                Identificación:</h3>
            <div class="fieldRow">
                <asp:Label ID="custIDTypeL" runat="server" CssClass="formLabel" AssociatedControlID="custIDTypeT">Tipo: </asp:Label>
                <telerik:RadComboBox ID="custIDTypeT" runat="server" DataSourceID="custIDTypesDS"
                    DataTextField="description" DataValueField="reference" 
                    AppendDataBoundItems="True" Width="150px" 
                    onselectedindexchanged="custIDTypeT_SelectedIndexChanged" 
                    AutoPostBack="true">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Selected="True" Text=" " Font-Italic="true" />
                    </Items>
                    <CollapseAnimation Type="OutQuint" Duration="200"></CollapseAnimation>
                </telerik:RadComboBox>
            </div>
            <div class="fieldRow">
                <asp:Label ID="custIDNumL" runat="server" CssClass="formLabel" AssociatedControlID="custIDNumT">Número: </asp:Label>
                <telerik:RadMaskedTextBox ID="custIDNumT" runat="server" 
                    SelectionOnFocus="CaretToBeginning" Width="125px" ZeroPadNumericRanges="False">
                </telerik:RadMaskedTextBox>
            </div>
            <div class="formButtonsRow">
                <telerik:RadButton ID="searchButton" runat="server" Text="Buscar Cliente" Skin="WebBlue"
                    OnClick="searchButton_Click">
                    <Icon PrimaryIconUrl="~/ui/img/icons/button_Search.png" PrimaryIconHeight="16" PrimaryIconWidth="16" />
                </telerik:RadButton>
            </div>
    </fieldset>
    <telerik:RadGrid ID="resultsGrid" runat="server" Visible="False" AutoGenerateColumns="False"
        CellSpacing="0" GridLines="None" Skin="WebBlue" TableLayout="Auto" Width="625px">
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_WebBlue">
        </HeaderContextMenu>
        <MasterTableView Summary="RadGrid table" TableLayout="Auto">
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="CustName" FilterControlAltText="Filter column column"
                    FooterText="Nombre" HeaderText="Nombre" ReadOnly="True" SortExpression="CustName"
                    UniqueName="column">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn AllowFiltering="False" DataField="CustIDNumber" FilterControlAltText="Filter column1 column"
                    FooterText="Identificación" Groupable="False" HeaderText="Identificación" ReadOnly="True"
                    SortExpression="CustIDNumber" UniqueName="column1">
                </telerik:GridBoundColumn>
                <telerik:GridHyperLinkColumn DataTextFormatString="Ver Cliente" DataNavigateUrlFields="CustID"
                    UniqueName="CustID" DataNavigateUrlFormatString="/customerInfo.aspx?cu={0}" DataTextField="CustID"
                    Resizable="False">
                    <ItemStyle HorizontalAlign="Center" Wrap="False" Width="50px" />
                </telerik:GridHyperLinkColumn>

          </Columns>
            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                </EditColumn>
            </EditFormSettings>
            <HeaderStyle BackColor="#538CC6" />
        </MasterTableView>
        <HeaderStyle CssClass="gridHeaders" />
        <FilterMenu EnableImageSprites="False">
        </FilterMenu>
    </telerik:RadGrid>
    <telerik:RadAjaxManager runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="custIDTypeT">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="custIDTypeT" />
                    <telerik:AjaxUpdatedControl ControlID="custIDNumT" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
