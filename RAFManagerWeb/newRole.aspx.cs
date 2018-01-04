using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace RAFManagerWeb
{
    public partial class newRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RAFSecurity _securityManager = new RAFSecurity();
            List<object> _data = _securityManager.searchForUsers(Page.User.Identity.Name, 5);
            if (_data.Count != 0)
            {
                if (!(_securityManager.getUserRights((int)_data[0] + "", "Page").Contains("PageCreacionRoles")))
                {
                    Response.Redirect("/default.aspx");
                }
            }
        }

        protected void BTNNewRol_Click(object sender, EventArgs e)
        {
            RAFSecurity _securityManager = new RAFSecurity();
            if (TBDescription.Text.Length < 255 && TBDescription.Text.Length > 1 && TBRolName.Text != null)
            {
                if (_securityManager.insertGroup(TBRolName.Text, TBDescription.Text))
                {
                    int idRol = _securityManager.searchForGroup(TBRolName.Text, 0);
                    Response.Redirect("/RolModifications.aspx?RolId=" + idRol);
                }
                {
                    errorMsg.Text = "Error el Nombre del rol ya está en uso";
                    errorMsg.Visible = true;
                }
            }
            else
            {
                errorMsg.Text = "Ingrese los datos correctamente";
                errorMsg.Visible = true;
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void BTNCancel_Click(object sender, EventArgs e)
        {
            TBRolName.Text = "";
            TBDescription.Text = "";
        }
    }
}
