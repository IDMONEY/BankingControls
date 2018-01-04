using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAFManagerWeb
{
    public partial class rolModifications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RAFSecurity _securityManager = new RAFSecurity();
            List<object> _dat = _securityManager.searchForUsers(Page.User.Identity.Name, 5);
            if (_dat.Count != 0)
            {
                if (!(_securityManager.getUserRights((int)_dat[0] + "", "Page").Contains("PageRolModifications")))
                {
                    Response.Redirect("/default.aspx");
                }
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["RolId"] != null)
                {
                    RolId.Value = Request.QueryString["RolId"];
                    _securityManager = new RAFSecurity();
                    List<object> _data =  _securityManager.searchForGroups(RolId.Value.ToString(), 2);
                    if (_data != null)
                    {
                        TBRolName.Text = (String)_data[1];
                        TXBDescription.Text = (String)_data[2];
                        if ((Boolean)_data[3])
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

        protected void TransactionsGrid_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }
        protected void gridSelectFirstRow(object sender, EventArgs e)
        {
            gridSelectFirstRow((Telerik.Web.UI.RadGrid)sender);
        }

        protected void gridSelectFirstRow(Telerik.Web.UI.RadGrid grid)
        {
            if (grid.Items.Count > 0)
            {
                if (grid.SelectedItems.Count == 0)
                {
                    grid.MasterTableView.Items[0].Selected = true;
                    grid.SelectedIndexes.Add(0);
                }
            }
        }

        protected void ChannelsGrid_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BTNNewUser_Click(object sender, EventArgs e)
        {
            if (TXBDescription.Text != null)
            {
                RAFSecurity _securityManager = new RAFSecurity();
                if (RaBuHabilitar.SelectedIndex == 0)
                {
                    if (_securityManager.updateGroup(TBRolName.Text,TXBDescription.Text, 1))
                    {//success
                    }
                    //fail error
                }
                else
                {
                    if (_securityManager.updateGroup(TBRolName.Text, TXBDescription.Text, 0))
                    {//sucess
                    }
                    //fail error
                }
            }
            //fail error
        }
         
        protected void BTNCancel_Click(object sender, EventArgs e)
        {

        }

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }

        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }

        protected void RadGrid3_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }

        protected void RadGrid4_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }
    }
}
