using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAFManagerWeb
{
    public partial class RoleSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RAFSecurity _securityManager = new RAFSecurity();
            List<object> _data = _securityManager.searchForUsers(Page.User.Identity.Name, 5);
            if (_data.Count != 0)
            {
                if (!(_securityManager.getUserRights((int)_data[0] + "", "Page").Contains("PageBuscarRol")))
                {
                    Response.Redirect("/default.aspx");
                }
            }
        }
    }
}
