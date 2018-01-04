<%@ Page Language="C#" MasterPageFile="~/ui/master/Default.Master" AutoEventWireup="true"
    CodeBehind="customerEnroll.aspx.cs" Inherits="RAFManagerWeb._customerEnroll"
    Title="Untitled Page" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Matricular Nuevo Cliente</h1>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="custIDTypeT">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="custIDTypeT" />
                    <telerik:AjaxUpdatedControl ControlID="custIDNumT" />
                    <telerik:AjaxUpdatedControl ControlID="nameT" />
                    <telerik:AjaxUpdatedControl ControlID="lastNameT" />
                    <telerik:AjaxUpdatedControl ControlID="lastName2T" />
                    <telerik:AjaxUpdatedControl ControlID="companyNameT" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <asp:SqlDataSource ID="custIDTypesDS" runat="server" ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>"
        SelectCommand="meta_getLanguage" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="2" Name="Language" Type="Int32" />
            <asp:Parameter DefaultValue="6" Name="Type" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="countriesDS" runat="server" ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>"
        SelectCommand="meta_getLanguage" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="2" Name="Language" Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="Type" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="languagesDS" runat="server" ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>"
        SelectCommand="SELECT id, language FROM languages ORDER BY language"></asp:SqlDataSource>
    <asp:Label ID="errorMsg" runat="server"  EnableViewState="False" 
        Text="" CssClass="alert" Visible="False"></asp:Label>
    <fieldset>
        <legend>Nuevo Cliente</legend>
        <h3>Identificación:</h3>
        <div class="fieldRow">
            <asp:Label ID="countryL" runat="server" CssClass="formLabel" AssociatedControlID="countryT">País Emisor: </asp:Label>
            <telerik:RadComboBox ID="countryT" runat="server" DataSourceID="countriesDS" DataTextField="description"
                DataValueField="reference" AppendDataBoundItems="True" Width="150px">
                <Items>
                    <telerik:RadComboBoxItem runat="server" Selected="True" Text=" " Font-Italic="true" />
                </Items>
                <CollapseAnimation Type="OutQuint" Duration="200"></CollapseAnimation>
            </telerik:RadComboBox>
        </div>
        <div class="fieldRow">
            <asp:Label ID="custIDTypeL" runat="server" CssClass="formLabel" AssociatedControlID="custIDTypeT">Tipo: </asp:Label>
            <telerik:RadComboBox ID="custIDTypeT" runat="server" DataSourceID="custIDTypesDS"
                DataTextField="description" DataValueField="reference" AppendDataBoundItems="True" Width="150px"
                OnSelectedIndexChanged="custIDTypeT_SelectedIndexChanged" AutoPostBack="true">
                <Items>
                    <telerik:RadComboBoxItem runat="server" Selected="True" Text=" " Font-Italic="true" />
                </Items>
                <CollapseAnimation Type="OutQuint" Duration="200"></CollapseAnimation>
            </telerik:RadComboBox>
        </div>
        <div class="fieldRow">
            <asp:Label ID="custIDNumL" runat="server" CssClass="formLabel" AssociatedControlID="custIDNumT">Número: </asp:Label>
            <telerik:RadMaskedTextBox ID="custIDNumT" runat="server" SelectionOnFocus="CaretToBeginning"
                Width="125px" ZeroPadNumericRanges="False">
            </telerik:RadMaskedTextBox>
        </div>
<%--        <asp:Label ID="Label4" runat="server" Text="Idioma Preferido"></asp:Label>
        <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="languagesDS" DataTextField="language"
            DataValueField="id">
        </asp:DropDownList>--%>
        <h3>Nombre del Cliente</h3>
        <div class="fieldRow">
            <asp:Label ID="nameL" runat="server" CssClass="formLabel" AssociatedControlID="nameT">Nombre: </asp:Label>
            <telerik:RadTextBox ID="nameT" runat="server">
            </telerik:RadTextBox>
            <telerik:RadTextBox ID="name2T" runat="server">
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
        <h3>Acceso</h3>
        <div class="fieldRow">
            <asp:Label ID="userName" runat="server" CssClass="formLabel" AssociatedControlID="nameT">Clave: </asp:Label>
            <telerik:RadTextBox ID="passphraseT" runat="server">
            </telerik:RadTextBox>
        </div>
        <div class="formButtonsRow">
            <telerik:RadButton ID="enrollButton" runat="server" Text="Matricular Cliente" 
                Skin="WebBlue" onclick="enrollButton_Click">
                <Icon PrimaryIconUrl="~/ui/img/icons/button_Check.png" PrimaryIconHeight="16" PrimaryIconWidth="16" />
            </telerik:RadButton>
        </div>
    </fieldset>
</asp:Content>
