using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace RAFManagerWeb
{
    public partial class UserModifications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { //Permisos para esta página
            RAFSecurity _securityManager = new RAFSecurity();
            List<object> _dat = _securityManager.searchForUsers(Page.User.Identity.Name, 5);
            if (_dat.Count != 0)
            {
                if (!(_securityManager.getUserRights((int)_dat[0] + "", "Page").Contains("PageUserModifications")))
                {
                    Response.Redirect("/default.aspx");
                }
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["ui"] != null)
                {
                    UserId.Value = Request.QueryString["ui"];
                    _securityManager = new RAFSecurity();
                    List<object> _data = _securityManager.searchForUsers(UserId.Value.ToString(), 4);
                    if (_data != null)
                    {
                        if (_data[1].ToString() != null && _data[1].ToString() != "")
                        {
                            TBUserName.Text = (String)_data[1];
                        }
                        if (_data[2].ToString() != null && _data[2].ToString() != "")
                        {
                            nameT.Text = (String)_data[2];
                        }
                        if (_data[3].ToString() != null && _data[3].ToString() != "")
                        {
                            TBSecondName.Text = (String)_data[3];
                        }
                        if (_data[4].ToString() != null && _data[4].ToString() != "")
                        {
                            TBLastName1.Text = (String)_data[4];
                        }
                        if (_data[5].ToString() != null && _data[5].ToString() != "")
                        {
                            TBLastName2.Text = (String)_data[5];
                        }
                        if ((String)_data[6] == "E")
                        {
                            RaBuHabilitar.SelectedIndex = 0;
                        }
                        else
                        {
                            RaBuHabilitar.SelectedIndex = 1;
                        }
                    }
                }
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridResults_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            
        }

        protected void BTNNewUser_Click(object sender, EventArgs e)
        {

            
            if (nameT.Text != null && TBSecondName.Text != null && TBLastName1.Text != null && TBLastName2.Text != null)
            {
                RAFSecurity _securityManager = new RAFSecurity();
                int _userId = int.Parse(UserId.Value);

                if (TBOldPass.Text.Length > 6 && TBPassConfirm.Text == TBPass.Text && TBPassConfirm.Text.Length > 6)
                {
                        if (_securityManager.passwordChange(TBUserName.Text, TBOldPass.Text, TBPass.Text, UserId.Value.ToString()))
                        {//success
                        }
                        else
                        {//Fail pass
                            return;
                        }
                }

                if (RaBuHabilitar.SelectedIndex == 0)
                {
                    if (_securityManager.updateUser(nameT.Text, TBSecondName.Text, TBLastName1.Text, TBLastName2.Text, "E", TBUserName.Text, _userId))
                    {//success
                    }
                    //fail error
                    return;
                }
                else
                {
                    if (_securityManager.updateUser(nameT.Text, TBSecondName.Text, TBLastName1.Text, TBLastName2.Text, "D", TBUserName.Text, _userId))
                    {//sucess
                    }
                    //fail error
                    return;
                }
            }
            //fail error
        }

        protected void RadTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }

        protected void RadGrid1_NeedDataSource1(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }

        protected void RadGrid1_NeedDataSource2(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }
    }
}
