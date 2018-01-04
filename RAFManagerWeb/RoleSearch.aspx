<%@ Page Language="C#" MasterPageFile="~/ui/master/Default.Master" AutoEventWireup="true" CodeBehind="RoleSearch.aspx.cs" Inherits="RAFManagerWeb.RoleSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>  
      <h1>Busqueda de Roles</h1>
        <div class="fieldRow">
        <telerik:RadTextBox ID="TBHint" Runat="server">
        </telerik:RadTextBox>
            <telerik:RadComboBox ID="RadComboBox1" Runat="server" Height="49px" 
                Width="121px">
                <Items>
                    <telerik:RadComboBoxItem runat="server" Text="Nombre del Rol" Value="1" />
                    <telerik:RadComboBoxItem runat="server" Text="Descripcion" Value="2" />
                </Items>
            </telerik:RadComboBox>
            <telerik:RadButton ID="BTNGroupSearch" runat="server" Text="Buscar">
            </telerik:RadButton>
        </div>
        <telerik:RadGrid ID="GridResults" runat="server" AutoGenerateColumns="False" 
            CellSpacing="0" GridLines="None" Height="400px" TableLayout="Auto" AllowPaging="True" 
           PageSize="12" DataSourceID="RolSearch" >
         <%--   onneeddatasource="GridResults_NeedDataSource">--%>
        
<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>

<MasterTableView DataKeyNames="identifier" DataSourceID="RolSearch" TableLayout="Auto">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
</ExpandCollapseColumn>

    <Columns>
<Telerik:GridBoundColumn DataField="identifier" ReadOnly="True" 
            HeaderText="identifier" SortExpression="identifier" UniqueName="identifier" 
            DataType="System.Int32" FilterControlAltText="Filter identifier column"></Telerik:GridBoundColumn>
<Telerik:GridBoundColumn DataField="Name" HeaderText="Name" 
            SortExpression="Name" UniqueName="Name" 
            FilterControlAltText="Filter Name column"></Telerik:GridBoundColumn>
<Telerik:GridBoundColumn DataField="Description" HeaderText="Description" 
            SortExpression="Description" UniqueName="Description" 
            FilterControlAltText="Filter Description column"></Telerik:GridBoundColumn>
<Telerik:GridHyperLinkColumn DataNavigateUrlFields="identifier" 
            DataNavigateUrlFormatString="~/RolModifications.aspx?RolId={0}" 
            DataTextField="Modificar Rol" Text="Modificar Rol" HeaderText="Modificar Rol" 
            Resizable="False" UniqueName="ModifyRol" 
            FilterControlAltText="Filter ModifyRol column">
<ItemStyle HorizontalAlign="Center" Wrap="False" Width="50px"></ItemStyle>
</Telerik:GridHyperLinkColumn>
  </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
        
        </telerik:RadGrid>
        <asp:SqlDataSource ID="RolSearch" runat="server" 
            ConnectionString="<%$ ConnectionStrings:rafSecurityConnectionString %>" 
            SelectCommand="sp_SearchForGroups" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="TBHint" Name="pHint" PropertyName="Text" 
                    Type="String" />
                <asp:ControlParameter ControlID="RadComboBox1" Name="pControlValue" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </fieldset>  
     </asp:Content>