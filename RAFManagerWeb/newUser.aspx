<%@ Page Language="C#" MasterPageFile="~/ui/master/Default.Master" AutoEventWireup="true"
    CodeBehind="newUser.aspx.cs" Inherits="RAFManagerWeb.newUser"
    Title="Creación de Usuarios" %>
    
 <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #Password1
        {
            width: 150px;
        }
        #Password2
        {
            width: 150px;
        }
    </style>

    <script language="javascript" type="text/javascript">
// <!CDATA[

        function Password1_onclick() {

        }

// ]]>
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Nuevo Usuario</h1>
    <asp:Label ID="errorMsg" runat="server"  EnableViewState="False" 
        Text="" CssClass="alert" Visible="False"></asp:Label>
    <fieldset>
        <legend>Creación de Usuario</legend>
        <h3>Datos de Usuario:</h3>
        <div class="fieldRow">
            <asp:Label ID="LBLUserName" runat="server" CssClass="formLabel">
            Nombre de Usuario: </asp:Label>
            <telerik:RadTextBox ID="TBUserName" Runat="server">
            </telerik:RadTextBox>
        &nbsp;
        </div>
        <div class="fieldRow">
            <asp:Label ID="LBLPass" runat="server" CssClass="formLabel">Contraseña: </asp:Label>
            <asp:TextBox id="TBPass" TextMode="Password" runat="server" /></div>
        <div class="fieldRow">
            <asp:Label ID="LBLPassConfirm" runat="server" CssClass="formLabel">Confirme la Contraseña: </asp:Label>
            <asp:TextBox id="TBPassConfirm" TextMode="Password" runat="server"/></div>
        <h3>Datos Personales</h3>
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
        <asp:Label ID="LBLAuxilar" runat="server" CssClass="formLabel">Segundo Apellido:</asp:Label>
        <telerik:RadTextBox ID="TBLastName2" runat="server">
            </telerik:RadTextBox>
        </div>
        <div class="formButtonsRow">
            <telerik:RadButton ID="BTNNewUser" runat="server" Text="Ingresar Nuevo Usuario" 
                onclick="BTNNewUser_Click">
            </telerik:RadButton>
            <telerik:RadButton ID="BTNCancel"  runat="server" Text="Cancelar">
            </telerik:RadButton>
        </div>
    </fieldset>
</asp:Content>