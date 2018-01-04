<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ui/master/Default.Master" CodeBehind="newRole.aspx.cs" Inherits="RAFManagerWeb.newRole" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Nuevo Rol</h1>
    <asp:Label ID="errorMsg" runat="server"  EnableViewState="False" 
        Text="" CssClass="alert" Visible="False"></asp:Label>
    <fieldset>
        <legend>Creación de Roles</legend>
        <div class="fieldRow">
            <asp:Label ID="LBLRolName" runat="server" CssClass="formLabel">
            Nombre del Rol: </asp:Label>
            <telerik:RadTextBox ID="TBRolName" Runat="server">
            </telerik:RadTextBox>
        </div>
        <div class="fieldRow">
            <asp:Label ID="LBLDescripcion" runat="server" CssClass="formLabel">Descripcion: </asp:Label>
            <asp:TextBox ID="TBDescription" runat="server" Columns="25" Font-Size="Small"
                Height="50px" MaxLength="250" Rows="10" TextMode="MultiLine" Width="383px" 
                CausesValidation="True" ToolTip="Maximo 250 caracteres" 
                ontextchanged="TextBox1_TextChanged"></asp:TextBox>
        </div>
       <div class="fieldRow">
            <telerik:RadButton ID="BTNNewRol" runat="server" Text="Ingresar Nuevo Rol" 
                     onclick="BTNNewRol_Click">
            </telerik:RadButton>
            <telerik:RadButton ID="BTNCancel" runat="server" Text="Cancelar" 
                     onclick="BTNCancel_Click">
            </telerik:RadButton>
        </div>
    </fieldset>
</asp:Content>