using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace RAFManagerWeb
{
    public partial class _default : System.Web.UI.Page
    {
 
        protected void Page_Load(object sender, EventArgs e)
        {
            try{
                //if just logged out
                if (Request.QueryString["a"].ToString() == "l")
                {
                    RAFSecurity _securityManager = new RAFSecurity();
                    _securityManager.Logout(Membership.Provider.Name);
                    LoginView1.FindControl("logoutMsg").Visible = true;
                    Response.Redirect("/default.aspx");
                }
                else
                {
                    LoginView1.FindControl("logoutMsg").Visible = false;
                }
            }
            catch(Exception x)
            {
            x.Message.Trim();
            }
            
            
        }
        protected void Login1_LoginError(object sender, EventArgs e)
        {
            LoginView1.FindControl("loginErrorMsg").Visible = true;
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
           
        }
    }
}
