<%@ Page Language="C#" MasterPageFile="~/ui/master/Default.Master" AutoEventWireup="true" CodeBehind="UserModifications.aspx.cs" Inherits="RAFManagerWeb.UserModifications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="UserId" runat="server"  />
<h1>Gestión de Usuarios</h1>  

        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" 
            MultiPageID="RadMultiPage1" SelectedIndex="0">
        <tabs>
            <telerik:RadTab runat="server" Text="Información de Usuario">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Selected="True" Text="Roles del Usuario">
            </telerik:RadTab>
        </tabs>
    </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" 
        Width="820px" >
        <telerik:RadPageView ID="RadPageView1" runat="server" CssClass="tabPage">
            <fieldset>
        <legend>Modificacion de Usuario</legend>
        <div class="fieldRow">
            <asp:Label ID="LBLUserName" runat="server" CssClass="formLabel">
            Nombre de Usuario: </asp:Label>
            <telerik:RadTextBox  Enabled="false" ID="TBUserName" Runat="server">
            </telerik:RadTextBox>
        </div>
        <div class="fieldRow">
            <asp:Label ID="LBLPass" runat="server" CssClass="formLabel">Contraseña: </asp:Label>
            <asp:TextBox id="TBOldPass" TextMode="Password" runat="server" /></div>
        <div class="fieldRow">
            <asp:Label ID="LBLPasschange" runat="server" CssClass="formLabel">Contraseña Nueva: </asp:Label>
            <asp:TextBox id="TBPass" TextMode="Password" runat="server" /></div>
        <div class="fieldRow">
            <asp:Label ID="LBLPassConfirm" runat="server" CssClass="formLabel" 
                Height="39px" Width="149px">Confirme la nueva Contraseña: </asp:Label>
            <asp:TextBox id="TBPassConfirm" TextMode="Password" runat="server" /></div>
        <div class="fieldRow">
        <h3>Datos Personales</h3>
        </div>
        <div class="fieldRow">
            <asp:Label ID="LBLName" runat="server" CssClass="formLabel">Nombre: </asp:Label>
            <telerik:RadTextBox ID="nameT" runat="server">
            </telerik:RadTextBox>
        </div>
        <div class="fieldRow">
            <asp:Label ID="LBLSecondName" runat="server" CssClass="formLabel">Segundo Nombre:</asp:Label>
            <telerik:RadTextBox ID="TBSecondName" runat="server">
            </telerik:RadTextBox>
        </div>
        <div class="fieldRow">
            <asp:Label ID="LBLLastName" runat="server" CssClass="formLabel">Apellidos: </asp:Label>
            <telerik:RadTextBox ID="TBLastName1" runat="server">
            </telerik:RadTextBox>
        </div>
        <div class="fieldRow">
        <asp:Label ID="LBLAuxilar" runat="server" CssClass="formLabel"> SegundoApellido:</asp:Label>
        <telerik:RadTextBox ID="TBLastName2" runat="server">
            </telerik:RadTextBox>
        </div>
        <div class="fieldRow">
        <asp:Label ID="HabilitarUsuario" runat="server" CssClass="formLabel" Height="16px">Habilitar Usuario:</asp:Label>
            <asp:RadioButtonList ID="RaBuHabilitar" runat="server" 
                onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
            
                <asp:ListItem Value="1">Habilitar</asp:ListItem>
                <asp:ListItem Value="0">Deshabilitar</asp:ListItem>
            
            </asp:RadioButtonList>
            <br />
        </div>
        <div class="formButtonsRow">
            <telerik:RadButton ID="BTNNewUser" runat="server" Text="Modificar Usuario" 
                onclick="BTNNewUser_Click">
            </telerik:RadButton>
        </div>
    </fieldset>
        </telerik:RadPageView>
   <telerik:RadPageView ID="RadPageView2" runat="server" CssClass="tabPage">
   <fieldset>
   <legend>Asignación de Roles</legend>
        <h1>Roles de Usuario</h1>
        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
            CellSpacing="0" GridLines="None" Height="400px" AllowPaging="True" 
           PageSize="12" DataSourceID="Membresias" 
           onneeddatasource="RadGrid1_NeedDataSource2">
        
<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>

<MasterTableView DataKeyNames="Identifier" DataSourceID="Membresias">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
</ExpandCollapseColumn>

    <Columns>
             <telerik:GridBoundColumn datafield="UserId2" Visible = "false" DataType="System.Int32" 
                 filtercontrolalttext="Filter UserId2 column" headertext="UserId2" 
                 readonly="True" sortexpression="UserId2" uniquename="UserId2"></telerik:GridBoundColumn>
             <telerik:GridBoundColumn datafield="Identifier" datatype="System.Int32" 
                 filtercontrolalttext="Filter Identifier column" headertext="Identifier" 
                 readonly="True" sortexpression="Identifier" uniquename="Identifier"></telerik:GridBoundColumn>
             <telerik:GridBoundColumn datafield="Name" 
                 filtercontrolalttext="Filter Name column" headertext="Name" 
                 sortexpression="Name" uniquename="Name"></telerik:GridBoundColumn>
             <telerik:GridBoundColumn datafield="Description" 
                 filtercontrolalttext="Filter Description column" headertext="Description" 
                 sortexpression="Description" uniquename="Description"></telerik:GridBoundColumn>
         <telerik:GridHyperLinkColumn DataNavigateUrlFields="identifier, UserId2" 
             DataNavigateUrlFormatString="/AuxiliarForm.aspx?code=1&ui={1}&gp={0}" 
             DataTextField="Salir del grupo" DataTextFormatString="Salir del grupo" 
             filtercontrolalttext="Filter QuitGroup column" footertext="Salir del Grupo" 
             headertext="Salir del Grupo" resizable="False" text="Salir del Grupo" 
             uniquename="QuitGroup">
            <ItemStyle HorizontalAlign="Center" Width="50px" Wrap="False"></ItemStyle>
        </telerik:GridHyperLinkColumn>

    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
        
        </telerik:RadGrid>
        <asp:SqlDataSource ID="Membresias" runat="server" 
           ConnectionString="<%$ ConnectionStrings:rafSecurityConnectionString %>" 
           SelectCommand="sp_SelectUserMemberships" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="UserId" Name="pIdUser" PropertyName="Value" 
                    Type="Int32" />
            </SelectParameters>
       </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        <h1>Busqueda de Roles</h1>
        <div class="fieldRow">
        <telerik:RadTextBox ID="TBHint" Runat="server">
        </telerik:RadTextBox>
            <telerik:RadComboBox ID="RadComboBox1" Runat="server" Height="50px" 
                Width="121px">
                <Items>
                    <telerik:RadComboBoxItem runat="server" Text="Nombre de Grupo" Value="1" />
                    <telerik:RadComboBoxItem runat="server" Text="Descripcion" Value="2" />
                </Items>
            </telerik:RadComboBox>
            <telerik:RadButton ID="BTNGroupSearch" runat="server" Text="Buscar">
            </telerik:RadButton>
        </div>
        <telerik:RadGrid ID="GridResults" runat="server" AutoGenerateColumns="False" 
            CellSpacing="0" GridLines="None" Height="400px" AllowPaging="True" 
           PageSize="12" DataSourceID="Roles" 
           onneeddatasource="GridResults_NeedDataSource" >
         <%--   onneeddatasource="GridResults_NeedDataSource">--%>
        
<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>

<MasterTableView DataSourceID="Roles" DataKeyNames="Identifier">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
</ExpandCollapseColumn>

    <Columns>
                 <telerik:GridBoundColumn datafield="UserId2" Visible = "false" DataType="System.Int32" 
                 filtercontrolalttext="Filter UserId2 column" headertext="UserId2" 
                 readonly="True" sortexpression="UserId2" uniquename="UserId2"></telerik:GridBoundColumn>
         <telerik:GridBoundColumn datafield="Identifier" datatype="System.Int32" 
             filtercontrolalttext="Filter Identifier column" headertext="Identifier" 
             readonly="True" sortexpression="Identifier" uniquename="Identifier"></telerik:GridBoundColumn>
         <telerik:GridBoundColumn datafield="Name" 
             filtercontrolalttext="Filter Name column" headertext="Name" 
             sortexpression="Name" uniquename="Name"></telerik:GridBoundColumn>
         <telerik:GridBoundColumn datafield="Description" 
             filtercontrolalttext="Filter Description column" headertext="Description" 
             sortexpression="Description" uniquename="Description"></telerik:GridBoundColumn>
         <telerik:GridHyperLinkColumn DataNavigateUrlFields="Identifier, UserId2" 
             DataNavigateUrlFormatString="/AuxiliarForm.aspx?code=2&ui={1}&gp={0}" 
             DataTextField="Unirse al grupo" DataTextFormatString="Salir del grupo" 
             filtercontrolalttext="Filter JoinGroup column" footertext="Unirse al Grupo" 
             headertext="Unirse al Grupo" resizable="False" text="Unirse al Grupo" 
             uniquename="JoinGroup">
            <ItemStyle HorizontalAlign="Center" Width="50px" Wrap="False"></ItemStyle>
        </telerik:GridHyperLinkColumn>

    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
        
        </telerik:RadGrid>
       <asp:SqlDataSource ID="Roles" runat="server" 
           ConnectionString="<%$ ConnectionStrings:rafSecurityConnectionString %>" 
           SelectCommand="sp_SelectUserNonMemberships" SelectCommandType="StoredProcedure">
           <SelectParameters>
               <asp:ControlParameter ControlID="UserId" Name="pIdUser" PropertyName="Value" 
                   Type="Int32" />
               <asp:ControlParameter ControlID="TBHint" Name="pHint" PropertyName="Text" 
                   Type="String" />
               <asp:ControlParameter ControlID="RadComboBox1" DefaultValue="1" Name="pType" 
                   PropertyName="SelectedValue" Type="Int32" />
           </SelectParameters>
       </asp:SqlDataSource>
    </fieldset>   
   </telerik:RadPageView>

    </telerik:RadMultiPage>    
</asp:Content>