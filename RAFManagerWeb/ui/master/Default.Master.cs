using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Collections.Generic;

namespace RAFManagerWeb
{
    public partial class Default : System.Web.UI.MasterPage
    {
        private List<String> _sections = new List<string>();
        private List<String> _Categories = new List<string>();
        private List<String> _pages = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Page.User.Identity.IsAuthenticated)
            {
                navMenu.Visible = true;
                getRights();
                interfaceEnable();
            }
            else
            {
                navMenu.Visible = false;
            }
            //if (!navMenu.Items.Contains(navMenu.Items.FindItemByText("Inicio")))
            //{
            //    RadMenuItem menu_Home = new RadMenuItem();
            //    menu_Home.Text = "Inicio";
            //    menu_Home.NavigateUrl = "/default.aspx";
            //    navMenu.Items.Add(menu_Home);
            //}
            ////Help
            //if (!navMenu.Items.Contains(navMenu.Items.FindItemByText("Ayuda")))
            //{
            //    RadMenuItem menu_Help = new RadMenuItem();
            //    menu_Help.Text = "Ayuda";
            //    menu_Help.NavigateUrl = "/help.aspx";
            //    navMenu.Items.Add(menu_Help);
            //}



        }
        protected void SectionEnable()
        {
            SecCustomerEnroll.Enabled = _sections.Contains("SecCustomerEnroll");
            SecCustomerSearch.Enabled = _sections.Contains("SecCustomerSearch");
           // SecReport.Enabled = _sections.Contains("SecReport");
            SecConfiguration.Enabled = _sections.Contains("SecConfiguration");
          //  SecSystem.Enabled = _sections.Contains("SecSystem");
        }

        protected void CategoryEnable()
        {
            //CatConsultas.Enabled = _Categories.Contains("CatConsultas");
            //CatMatriculas.Enabled = _Categories.Contains("CatMatriculas");
           // CatAuditoria.Enabled = _Categories.Contains("CatAuditoria");
            CatControlAcceso.Enabled = _Categories.Contains("CatControlAcceso");
            CatUsuarios.Enabled = _Categories.Contains("CatUsuarios");
            CatRoles.Enabled = _Categories.Contains("CatRoles");
           // CatServicios.Enabled = _Categories.Contains("CatServicios");
           // CatUsuariosSesion.Enabled = _Categories.Contains("CatUsuariosSesion");
           // CatEstadoServicio.Enabled = _Categories.Contains("CatEstadoServicio");
           // CatBitacoraErrores.Enabled = _Categories.Contains("CatBitacoraErrores");
        }

        protected void pageEnable()
        {
            //PageVolumenConsultas.Enabled = _pages.Contains("PageVolumenConsultas");
            //PageMatriculaUsuarios.Enabled = _pages.Contains("PageMatriculaUsuarios");
            //PageMatriculaActivos.Enabled = _pages.Contains("PageMatriculaActivos");
            //PageIngresoUsuarios.Enabled = _pages.Contains("PageIngresoUsuarios");
            //PageAccesoClientes.Enabled = _pages.Contains("PageAccesoClientes");
            //PageEdiciones.Enabled = _pages.Contains("PageEdiciones");
            PageBusquedaUsuarios.Enabled = _pages.Contains("PageBusquedaUsuarios");
            PageCreacionUsuarios.Enabled = _pages.Contains("PageCreacionUsuarios");
            PageBuscarRol.Enabled = _pages.Contains("PageBuscarRol");
            PageCreacionRoles.Enabled = _pages.Contains("PageCreacionRoles");
            //PageGestionDerechos.Enabled = _pages.Contains("PageGestionDerechos");
            //PagePoliticasSeguridad.Enabled = _pages.Contains("PagePoliticasSeguridad");
            //PageValoresDefecto.Enabled = _pages.Contains("PageValoresDefecto");
            //PageActivos.Enabled = _pages.Contains("PageActivos");
            //PageCanales.Enabled = _pages.Contains("PageCanales");
            //PageTransacciones.Enabled = _pages.Contains("PageTransacciones");
        }
        protected void interfaceEnable()
        {
            SectionEnable();
            CategoryEnable();
            pageEnable();
        }
        protected void getRights()
        {
            _sections.Clear();
            _Categories.Clear();
            _pages.Clear();
            RAFSecurity _securityManager = new RAFSecurity();
            List<object> _data = _securityManager.searchForUsers(Page.User.Identity.Name, 5);
            if (_data.Count != 0)
            {
                _sections = _securityManager.getUserRights((int)_data[0] + "", "Section");
                _Categories = _securityManager.getUserRights((int)_data[0] + "", "Category");
                _pages = _securityManager.getUserRights((int)_data[0] + "", "Page");
            }
        }
    }
}
