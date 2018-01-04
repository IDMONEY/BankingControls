using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAFManagerWeb
{
    public partial class AuxiliarForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RAFSecurity _securityManager = new RAFSecurity();
            String plap = Request.QueryString["code"].ToString();
            int asd = String.Compare(plap, "1");
                if (Request.QueryString["code"].ToString() == "1" || Request.QueryString["code"].ToString() == "3")
                {
                    String _gp = Request.QueryString["gp"];
                    String _user = Request.QueryString["ui"];
                    if (_securityManager.deleteMembership(_user, _gp))
                    {
                        if (Request.QueryString["code"].ToString() == "3")
                        {
                            Response.Redirect("/rolModifications.aspx?code=3&resp=1&RolId="+_gp);
                        }
                        else
                        {
                            Response.Redirect("/UserModifications.aspx?code=1&resp=1&ui=" + _user);
                        }
                    }
                    else
                    {
                        if (Request.QueryString["code"].ToString() == "3")
                        {
                            Response.Redirect("/rolModifications.aspx?code=3&resp=0&RolId=" + _gp);
                        }
                        else
                        {
                            Response.Redirect("/UserModifications.aspx?code=1&resp=0&ui=" + _user);
                        }
                    }
                }
                else if (Request.QueryString["code"].ToString() == "2" || Request.QueryString["code"].ToString() == "4")
                {
                    String _gp = Request.QueryString["gp"];
                    String _user = Request.QueryString["ui"];
                    if (_securityManager.addMembership(_user, _gp))
                    {
                        if (Request.QueryString["code"].ToString() == "2")
                        {
                            Response.Redirect("/UserModifications.aspx?code=2&resp=1&ui=" + _user);
                        }
                        else
                        {
                            Response.Redirect("/rolModifications.aspx?code=4&resp=0&RolId=" + _gp);
                        }
                    }
                    else
                    {
                        if (Request.QueryString["code"].ToString() == "2")
                        {
                            Response.Redirect("/UserModifications.aspx?code=2&resp=0&ui=" + _user);
                        }
                        else
                        {
                            Response.Redirect("/rolModifications.aspx?code=4&resp=0&RolId=" + _gp);
                        }
                    }
                }
                 else if (Request.QueryString["code"].ToString() == "5")
                {
                    String _gp = Request.QueryString["gp"];
                    String _ident = Request.QueryString["ident"];
                    String _type = Request.QueryString["type"];
                    if (_securityManager.addRights(_gp, _type, _ident))
                    {
                        Response.Redirect("/rolModifications.aspx?code=5&resp=1&RolId=" + _gp);
                    }
                    else
                    {
                        Response.Redirect("/rolModifications.aspx?code=5&resp=0&RolId=" + _gp);
                    }
                }
                else if (Request.QueryString["code"].ToString() == "6")
                {
                    String _gp = Request.QueryString["gp"];
                    String _ident = Request.QueryString["ident"];
                    String _type = Request.QueryString["type"];
                    if (_securityManager.DeleteRights(_gp, _type, _ident))
                    {
                        Response.Redirect("/rolModifications.aspx?code=6&resp=1&RolId=" + _gp);
                    }
                    else
                    {
                        Response.Redirect("/rolModifications.aspx?code=6&resp=0&RolId=" + _gp);
                    }
                }
                else
                {
                }
        }
    }
}

