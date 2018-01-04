using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace gridTest
{
    public partial class _AssetRules : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string my = "";
            }
            catch (Exception x)
            {
                x.Message.Trim();

            }
        }
 
       protected void SqlDataSource1_DataBinding(object sender, EventArgs e)
        {
            Console.WriteLine(RadGrid1.SelectedValue);
        }

        protected void RadGrid2_DataBound(object sender, EventArgs e)
        {
            if (RadGrid2.SelectedIndexes.Count == 0)
            {
                RadGrid2.SelectedIndexes.Add(0);
            }
        }

        protected void RadGrid1_DataBound(object sender, EventArgs e)
        {
            if (RadGrid1.SelectedIndexes.Count == 0)
            {
                RadGrid1.SelectedIndexes.Add(0);
            }
        }

        protected void RadGrid3_DataBound(object sender, EventArgs e)
        {
            if (RadGrid3.SelectedIndexes.Count == 0)
            {
                RadGrid3.SelectedIndexes.Add(0);
            }
        }
        protected void RadGrid4_DataBound(object sender, EventArgs e)
        {
            if (RadGrid4.SelectedIndexes.Count == 0)
            {
                RadGrid4.SelectedIndexes.Add(0);
            }
        }

        protected void rulesDS_Inserting(object sender, SqlDataSourceCommandEventArgs e)
        {
            string my = "";
        }
 
    }
}
