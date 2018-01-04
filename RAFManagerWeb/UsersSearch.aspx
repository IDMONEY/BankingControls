<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersSearch.aspx.cs" 
Inherits="RAFManagerWeb.UsersSearch" MasterPageFile="~/ui/master/Default.Master"
Title="Busqueda de Usuarios"%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Busqueda de Usuarios</h1>
    <asp:Label ID="errorMsg" runat="server"  EnableViewState="False" 
        Text="" CssClass="alert" Visible="False"></asp:Label>
    <fieldset>
        <legend>Criterios de Búsqueda</legend>
        <div class="fieldRow">
        <telerik:RadTextBox ID="TBHint" Runat="server">
        </telerik:RadTextBox>
            <telerik:RadComboBox ID="RadComboBox1" Runat="server">
                <Items>
                    <telerik:RadComboBoxItem runat="server" Text="Nombre de Usuario" Value="0" />
                    <telerik:RadComboBoxItem runat="server" Text="Nombre" Value="1" />
                    <telerik:RadComboBoxItem runat="server" Text="Apellido" Value="2" />
                </Items>
            </telerik:RadComboBox>
            <telerik:RadButton ID="BTNUserSearch" runat="server" Text="Buscar" 
                >
            </telerik:RadButton>
        </div>
        <telerik:RadGrid ID="GridResults" runat="server" AutoGenerateColumns="False" 
            CellSpacing="0" GridLines="None" Height="400px" 
            DataSourceID="SqlDataSource2" AllowPaging="True" PageSize="12" >
         <%--   onneeddatasource="GridResults_NeedDataSource">--%>
        
<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>

<MasterTableView DataSourceID="SqlDataSource2" DataKeyNames="identifier">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn datafield="identifier" datatype="System.Int32" 
            filtercontrolalttext="Filter identifier column" headertext="identifier" 
            readonly="True" sortexpression="identifier" uniquename="identifier"></telerik:GridBoundColumn>
        <telerik:GridBoundColumn datafield="LoginName" 
            filtercontrolalttext="Filter LoginName column" headertext="LoginName" 
            sortexpression="LoginName" uniquename="LoginName"></telerik:GridBoundColumn>
        <telerik:GridBoundColumn datafield="FirstName" 
            filtercontrolalttext="Filter FirstName column" headertext="FirstName" 
            sortexpression="FirstName" uniquename="FirstName"></telerik:GridBoundColumn>
        <telerik:GridBoundColumn datafield="SurName" 
            filtercontrolalttext="Filter SurName column" headertext="SurName" 
            sortexpression="SurName" uniquename="SurName"></telerik:GridBoundColumn>
        <telerik:GridHyperLinkColumn DataNavigateUrlFields="identifier" 
            DataNavigateUrlFormatString="/UserModifications.aspx?ui={0}" 
            DataTextField="Modificar Usuario" DataTextFormatString="Modificar Usuario" 
            Resizable="False" UniqueName="ModifyUserRequest" 
            FilterControlAltText="Filter ModifyUserRequest column" 
            footertext="Modificar Usuario" headertext="Modificar Usuario" 
            text="Modificar Usuario">
            <ItemStyle HorizontalAlign="Center" Wrap="False" Width="50px"></ItemStyle>
        </telerik:GridHyperLinkColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
        
        </telerik:RadGrid>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:rafSecurityConnectionString %>" 
            SelectCommand="sp_SearchForUsers" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="TBHint" Name="pHint" PropertyName="Text" 
                    Type="String" />
                <asp:ControlParameter ControlID="RadComboBox1" DefaultValue="0" 
                    Name="pControlValue" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </fieldset>
</asp:Content>

