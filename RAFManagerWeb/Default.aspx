<%@ Page Language="C#" MasterPageFile="~/ui/master/Default.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="RAFManagerWeb._default" Title="Untitled Page" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:LoginView ID="LoginView1" runat="server">
      <AnonymousTemplate>
    <h1>Control de Acceso</h1>
    <div class="singleForm">
    <asp:ValidationSummary CssClass="alert" ID="ValidationSummary1" runat="server"  
            ValidationGroup="Login1" ForeColor=""/>
    <asp:Label ID="loginErrorMsg" runat="server"  EnableViewState="False" 
                Text="Usuario o contraseña incorrecto" CssClass="alert" Visible="False"></asp:Label>
    <asp:Label ID="logoutMsg" runat="server"  EnableViewState="False" 
                Text="Su sesión ha cerrado correctamente." CssClass="notice" Visible="False"></asp:Label>
    <asp:Login ID="Login1" runat="server" onloginerror="Login1_LoginError" VisibleWhenLoggedIn="False">
        <LayoutTemplate>
            <table border="0" cellpadding="1" cellspacing="0" 
                style="border-collapse:collapse;">
                <tr>
                    <td>
                        <table border="0" cellpadding="0">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuario:</asp:Label>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="UserName" runat="server">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                        ControlToValidate="UserName" ErrorMessage="El campo 'Usuario' es requerido." 
                                        ToolTip="El campo 'Usuario' es requerido." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="Password" TextMode="Password" runat="server">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                        ControlToValidate="Password" ErrorMessage="El campo 'Contraseña' es requerido." 
                                        ToolTip="El campo 'Contraseña' es requerido." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Ingresar" 
                                        ValidationGroup="Login1" onclick="LoginButton_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
    </asp:Login>
    </div>

        </AnonymousTemplate>
        <LoggedInTemplate>
        <h1>Bienvenido</h1>
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>
