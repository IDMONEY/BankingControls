using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace RAFManagerWeb
{
    public partial class newUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RAFSecurity _securityManager = new RAFSecurity();
            List<object> _data = _securityManager.searchForUsers(Page.User.Identity.Name, 5);
            if (_data.Count != 0)
            {
                if (!(_securityManager.getUserRights((int)_data[0] + "", "Page").Contains("PageCreacionUsuarios")))
                {
                    Response.Redirect("/default.aspx");
                }
            }
        }

        protected void BTNNewUser_Click(object sender, EventArgs e)
        { 
            RAFSecurity _securityManager = new RAFSecurity();
            if (TBUserName.Text != null && TBPass.Text == TBPassConfirm.Text && TBPass.Text.Length > 5)
            {
                if (_securityManager.insertUser(TBUserName.Text, TBPass.Text, nameT.Text, TBSecondName.Text, TBLastName1.Text, TBLastName2.Text, Membership.Provider.Name))
                {
                    List<object> _result = _securityManager.searchForUsers(TBUserName.Text, 5);

                    Response.Redirect("/UserModifications.aspx?ui=" + _result[0]);
                }
                else
                {
                    errorMsg.Text = "Error el Nombre del Usuario ya está en uso";
                    errorMsg.Visible = true;
                    
                }
            }
            else
            {
                errorMsg.Text = "Ingrese los datos correctamente";
                errorMsg.Visible = true;
            }
        }


    }
}
