<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ui/master/Default.Master" CodeBehind="rolModifications.aspx.cs" Inherits="RAFManagerWeb.rolModifications" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="RolId" runat="server" />
    <h1>Gestión de Roles</h1>  
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" 
            MultiPageID="RadMultiPage1" SelectedIndex="0">
        <tabs>
            <telerik:RadTab runat="server" Text="Información de Rol">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Usuarios por Rol" Selected="True">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Selected="True" Text="Gestión de Derechos">
            </telerik:RadTab>
        </tabs>
    </telerik:RadTabStrip>
   <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" 
        Width="820px" >
    <telerik:RadPageView ID="RadPageView1" runat="server" CssClass="tabPage">
            <fieldset>
        <legend>Modificacion de Roles</legend>
                <div class="fieldRow">
            <asp:Label ID="LBLRolName"  runat="server" CssClass="formLabel">
            Nombre del Rol: </asp:Label>
            <telerik:RadTextBox ID="TBRolName" Enabled="false" Runat="server">
            </telerik:RadTextBox>
        </div>
        <div class="fieldRow">
            <asp:Label ID="LBLDescripcion" runat="server" CssClass="formLabel">Descripcion: </asp:Label>
            <asp:TextBox ID="TXBDescription" runat="server" Columns="25" Font-Size="Small"
                Height="66px" MaxLength="250" Rows="10" TextMode="MultiLine" Width="383px" 
                CausesValidation="True" ToolTip="Maximo 250 caracteres" 
                ontextchanged="TextBox1_TextChanged"></asp:TextBox>
        </div>
       <div class="fieldRow">
        <asp:Label ID="HabilitarRol" runat="server" CssClass="formLabel" Height="16px">Habilitar Rol:</asp:Label>
            <asp:RadioButtonList ID="RaBuHabilitar" runat="server" 
               onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" >
            
                <asp:ListItem Value="1">Habilitar</asp:ListItem>
                <asp:ListItem Value="0">Deshabilitar</asp:ListItem>
            
            </asp:RadioButtonList>
            <br />
        </div>
        <div class="formButtonsRow">
            <telerik:RadButton ID="BTNNewUser" runat="server" Text="Modificar Rol" 
                onclick="BTNNewUser_Click">
            </telerik:RadButton>
        </div>
    </fieldset>
        </telerik:RadPageView>
   <telerik:RadPageView ID="RadPageView2" runat="server" CssClass="tabPage">
   <fieldset>
   <legend>Asignación de Roles</legend>
        <h1>Usuarios por Rol</h1>
        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
            CellSpacing="0" GridLines="None" Height="400px" AllowPaging="True" 
           PageSize="12" DataSourceID="SqlDataSource1" 
           onneeddatasource="RadGrid1_NeedDataSource" >
         <%--   onneeddatasource="GridResults_NeedDataSource">--%>
        
<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>

<MasterTableView DataKeyNames="identifier" DataSourceID="SqlDataSource1">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
</ExpandCollapseColumn>

    <Columns>
           <telerik:GridBoundColumn datafield="RolId2" Visible = "false" DataType="System.Int32" 
                 filtercontrolalttext="Filter RolId2 column" headertext="RolId2" 
                 readonly="True" sortexpression="RolId2" uniquename="RolId2"></telerik:GridBoundColumn>
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
        <telerik:GridHyperLinkColumn DataNavigateUrlFields="identifier, RolId2" 
            DataNavigateUrlFormatString="/AuxiliarForm.aspx?code=3&ui={0}&gp={1}" 
            DataTextField="Remover Usuario" DataTextFormatString="Remover Usuario" 
            Resizable="False" UniqueName="RemoveUser" 
            FilterControlAltText="Filter RemoverUser column" 
            footertext="Remover Usuario" headertext="Remover Usuario" 
            text="Remover Usuario">
            <ItemStyle HorizontalAlign="Center" Wrap="False" Width="50px"></ItemStyle>
        </telerik:GridHyperLinkColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
        
        </telerik:RadGrid>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
           ConnectionString="<%$ ConnectionStrings:rafSecurityConnectionString %>" 
           SelectCommand="sp_SelectUsersByGroup" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="RolId" Name="pIdGroup" PropertyName="Value" 
                    Type="Int32" />
            </SelectParameters>
       </asp:SqlDataSource>
        <h1>Busqueda de Usuarios</h1>
        <div class="fieldRow">
        <telerik:RadTextBox ID="TBHint" Runat="server">
        </telerik:RadTextBox>
            <telerik:RadComboBox ID="RadComboBox1" Runat="server" Height="50px" 
                Width="121px">
                <Items>
                    <telerik:RadComboBoxItem runat="server" Text="Nombre" Value="0" />
                    <telerik:RadComboBoxItem runat="server" Text="Apellido" Value="1" />
                    <telerik:RadComboBoxItem runat="server" Text="Nombre de Usuario" Value="2" />                    
                    <telerik:RadComboBoxItem runat="server" Text="Todos los Usuarios" Value="3" />
                </Items>
            </telerik:RadComboBox>
            <telerik:RadButton ID="BTNGroupSearch" runat="server" Text="Buscar">
            </telerik:RadButton>
        </div>
                <telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="False" 
            CellSpacing="0" GridLines="None" Height="400px" AllowPaging="True" 
           PageSize="12" DataSourceID="UsuariosBusqueda" 
           onneeddatasource="RadGrid2_NeedDataSource" >
         <%--   onneeddatasource="GridResults_NeedDataSource">--%>
        
<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>

<MasterTableView DataKeyNames="identifier" DataSourceID="UsuariosBusqueda">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
</ExpandCollapseColumn>

    <Columns>
              <telerik:GridBoundColumn datafield="RolId2" datatype="System.Int32" 
                   filtercontrolalttext="Filter RolId2 column" headertext="RolId2" readonly="True" 
                   sortexpression="RolId2" uniquename="RolId2"></telerik:GridBoundColumn>
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
                <telerik:GridHyperLinkColumn DataNavigateUrlFields="identifier, RolId2" 
                    DataNavigateUrlFormatString="/AuxiliarForm.aspx?code=4&ui={0}&gp={1}"
                    DataTextField="Agregar Usuario" DataTextFormatString="Agregar Usuario" 
                    Resizable="False" UniqueName="AddUser" 
                    FilterControlAltText="Filter AddUser column" 
                    footertext="Agregar Usuario" headertext="Agregar Usuario" 
                    text="Agregar Usuario">
                    <ItemStyle HorizontalAlign="Center" Wrap="False" Width="50px"></ItemStyle>
                </telerik:GridHyperLinkColumn>
               
            
               
               
            
   </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
        
        </telerik:RadGrid>
       <asp:SqlDataSource ID="UsuariosBusqueda" runat="server" 
           ConnectionString="<%$ ConnectionStrings:rafSecurityConnectionString %>" 
           SelectCommand="sp_SelectNonUsersInAGroup" SelectCommandType="StoredProcedure">
           <SelectParameters>
               <asp:ControlParameter ControlID="RolId" Name="pIdGroup" PropertyName="Value" 
                   Type="Int32" />
               <asp:ControlParameter ControlID="RadComboBox1" Name="pType" 
                   PropertyName="SelectedValue" Type="Int32" />
               <asp:ControlParameter ControlID="TBHint" Name="pHint" PropertyName="Text" 
                   Type="String" DefaultValue="*" />
           </SelectParameters>
       </asp:SqlDataSource>
    </fieldset>   
   </telerik:RadPageView>
   
      <telerik:RadPageView ID="RadPageView3" runat="server" CssClass="tabPage">
   <fieldset>
   <legend>Asignación de Roles</legend>
        <h1>Permisos por Rol</h1>
        <telerik:RadGrid ID="RadGrid3" runat="server" AutoGenerateColumns="False" 
            CellSpacing="0" GridLines="None" Height="400px" AllowPaging="True" 
           PageSize="12" DataSourceID="PermisosObtenidos" 
           onneeddatasource="RadGrid3_NeedDataSource" >
        
<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>

<MasterTableView DataSourceID="PermisosObtenidos">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
</ExpandCollapseColumn>

    <Columns>
       
        <telerik:GridBoundColumn datafield="RolId2" Visible ="false" datatype="System.Int32" 
            filtercontrolalttext="Filter RolId2 column" headertext="RolId2" readonly="True" 
            sortexpression="RolId2" uniquename="RolId2"></telerik:GridBoundColumn>
        <telerik:GridBoundColumn datafield="identifier" datatype="System.Int32" 
            filtercontrolalttext="Filter identifier column" headertext="identifier" 
            readonly="True" sortexpression="identifier" uniquename="identifier"></telerik:GridBoundColumn>
        <telerik:GridBoundColumn datafield="Name" 
            filtercontrolalttext="Filter Name column" headertext="Name" readonly="True" 
            sortexpression="Name" uniquename="Name"></telerik:GridBoundColumn>
        <telerik:GridBoundColumn datafield="TypeName" 
            filtercontrolalttext="Filter TypeName column" headertext="TypeName" 
            readonly="True" sortexpression="TypeName" uniquename="TypeName"></telerik:GridBoundColumn>
        <telerik:GridBoundColumn datafield="Parent" 
            filtercontrolalttext="Filter Parent column" headertext="Parent" readonly="True" 
            sortexpression="Parent" uniquename="Parent"></telerik:GridBoundColumn>
        <telerik:GridBoundColumn datafield="ParentType" 
            filtercontrolalttext="Filter ParentType column" headertext="ParentType" 
            readonly="True" sortexpression="ParentType" uniquename="ParentType"></telerik:GridBoundColumn>
        <telerik:GridHyperLinkColumn DataNavigateUrlFields="identifier, RolId2, TypeName" 
            DataNavigateUrlFormatString="/AuxiliarForm.aspx?code=6&ident={0}&gp={1}&type={2}" 
            DataTextField="Remover Permiso" DataTextFormatString="Remover Permiso" 
            Resizable="False" UniqueName="RemovePermiso" 
            FilterControlAltText="Filter RemoverPermiso column" 
            footertext="Remover Permiso" headertext="Remover Permiso" 
            text="Remover Permiso">
            <ItemStyle HorizontalAlign="Center" Wrap="False" Width="50px"></ItemStyle>
        </telerik:GridHyperLinkColumn>

    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
        
        </telerik:RadGrid>
        <asp:SqlDataSource ID="PermisosObtenidos" runat="server" 
           ConnectionString="<%$ ConnectionStrings:rafSecurityConnectionString %>" 
           SelectCommand="sp_SelectAllRights" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="RolId" Name="pIdGroup" PropertyName="Value" 
                    Type="Int32" />
            </SelectParameters>
       </asp:SqlDataSource>
        <h1>Busqueda de Permisos</h1>
        <div class="fieldRow">
        <telerik:RadTextBox ID="TXBSearch" Runat="server">
        </telerik:RadTextBox>
            <telerik:RadComboBox ID="CBXRoles" Runat="server" Height="50px" 
                Width="121px">
                <Items>
                    <telerik:RadComboBoxItem runat="server" Text="Secciones" Value="0" />
                    <telerik:RadComboBoxItem runat="server" Text="Categorias" Value="1" />
                    <telerik:RadComboBoxItem runat="server" Text="Paginas" Value="2" />
                    <telerik:RadComboBoxItem runat="server" Visible="false" Text="Formularios" Value="3" />
                    <telerik:RadComboBoxItem runat="server" Visible="false" Text="SubFormularios" Value="4" />
                </Items>
            </telerik:RadComboBox>
            <telerik:RadButton ID="RadButton1" runat="server" Text="Buscar">
            </telerik:RadButton>
        </div>
                <telerik:RadGrid ID="RadGrid4" runat="server" AutoGenerateColumns="False" 
            CellSpacing="0" GridLines="None" Height="400px" AllowPaging="True" 
           PageSize="12" DataSourceID="BusquedaRoles" 
           onneeddatasource="RadGrid4_NeedDataSource" >
        
<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>

<MasterTableView DataKeyNames="identifier" DataSourceID="BusquedaRoles">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn datafield="RolId2" Visible="false" datatype="System.Int32" 
            filtercontrolalttext="Filter RolId2 column" headertext="RolId2" readonly="True" 
            sortexpression="RolId2" uniquename="RolId2"></telerik:GridBoundColumn>
        <telerik:GridBoundColumn datafield="identifier" datatype="System.Int32" 
            filtercontrolalttext="Filter identifier column" headertext="identifier" 
            readonly="True" sortexpression="identifier" uniquename="identifier"></telerik:GridBoundColumn>
        <telerik:GridBoundColumn datafield="Name" 
            filtercontrolalttext="Filter Name column" headertext="Name" 
            sortexpression="Name" uniquename="Name"></telerik:GridBoundColumn>
        <telerik:GridBoundColumn datafield="TypeName" 
            filtercontrolalttext="Filter TypeName column" headertext="TypeName" 
            readonly="True" sortexpression="TypeName" uniquename="TypeName"></telerik:GridBoundColumn>
        <telerik:GridHyperLinkColumn DataNavigateUrlFields="identifier, RolId2, TypeName " 
            DataNavigateUrlFormatString="/AuxiliarForm.aspx?code=5&ident={0}&gp={1}&type={2}" 
            DataTextField="Agregar Permiso" DataTextFormatString="Agregar Permiso" 
            Resizable="False" UniqueName="AddRight" 
            FilterControlAltText="Filter AddRight column" 
            footertext="Agregar Usuario" headertext="Agregar Permiso" 
            text="Agregar Permiso">
            <ItemStyle HorizontalAlign="Center" Wrap="False" Width="50px"></ItemStyle>
        </telerik:GridHyperLinkColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
        
        </telerik:RadGrid>
       <asp:SqlDataSource ID="BusquedaRoles" runat="server" 
           ConnectionString="<%$ ConnectionStrings:rafSecurityConnectionString %>" 
           SelectCommand="sp_RoleSearch" SelectCommandType="StoredProcedure">
           <SelectParameters>
               <asp:ControlParameter ControlID="TXBSearch" Name="pHint" PropertyName="Text" 
                   Type="String" />
               <asp:ControlParameter ControlID="CBXRoles" Name="pType" 
                   PropertyName="SelectedValue" Type="Int32" />
               <asp:ControlParameter ControlID="RolId" Name="pIdGroup" PropertyName="Value" 
                   Type="Int32" />
           </SelectParameters>
       </asp:SqlDataSource>
    </fieldset>   
   </telerik:RadPageView>
   </telerik:RadMultiPage>    
</asp:Content>