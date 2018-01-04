using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Xml;

namespace RAFManagerWeb
{
    public partial class customerInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RAFSecurity _securityManager = new RAFSecurity();
            List<object> _data = _securityManager.searchForUsers(Page.User.Identity.Name, 5);
            if (_data.Count != 0)
            {
                if (!(_securityManager.getUserRights((int)_data[0] + "", "Page").Contains("PageCustomerInfo")))
                {
                    Response.Redirect("/default.aspx");
                }
            }
            
            if (!IsPostBack)
            {
                if (Request.QueryString["cu"] != null)
                {
                    custIDHid.Value = Request.QueryString["cu"];
                }
            }
        }


        protected void ChannelsGrid_DataBound(object sender, EventArgs e)
        {
            if (ChannelsGrid.SelectedIndexes.Count == 0)
            {
                ChannelsGrid.SelectedIndexes.Add(0);
            }
        }
        protected void TransactionsGrid_DataBound(object sender, EventArgs e)
        {
            if (TransactionsGrid.SelectedIndexes.Count == 0)
            {
                TransactionsGrid.SelectedIndexes.Add(0);
            }
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
                //else
                //{
                //    grid.MasterTableView.Items[0].Selected = false;
                //}            
            }
        }

        protected void AssetsDS_Inserting(object sender, SqlDataSourceCommandEventArgs e)
        {
            System.Data.Common.DbCommand command = e.Command;
            try
            {
                int assetType;
                string assetNumber = command.Parameters["@displaymask"].Value.ToString();
                bool su = Int32.TryParse(command.Parameters["@type"].Value.ToString(), out assetType);
                if (su)
                {
                    command.Parameters["@issueent"].Value = "1";
                    command.Parameters["@displaymask"].Value = RAFCommon.Assets.AssetGenDisplayMask(assetType, assetNumber);
                    command.Parameters["@idnumber"].Value = RAFCommon.Assets.AssetGenStoredAssetNum(assetType, assetNumber);
                }
            }
            catch (Exception x)
            {
                x.Message.Trim();
            }


        }

        protected void TransactionsDS_Inserting(object sender, SqlDataSourceCommandEventArgs e)
        {
            try
            {
            System.Data.Common.DbCommand command = e.Command;
            command.Parameters["@channel"].Value = ChannelsGrid.SelectedItems[0].Cells[2].Text;
            }
            catch (Exception x)
            {
                x.Message.Trim();
            }
        }

        protected void TransactionsDS_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            try
            {
                System.Data.Common.DbCommand command = e.Command;
                command.Parameters["@channel"].Value = ChannelsGrid.SelectedItems[0].Cells[2].Text;
            }
            catch (Exception x)
            {
                x.Message.Trim();
            }
        }

        protected void rulesDS_Inserting(object sender, SqlDataSourceCommandEventArgs e)
        {
            try
            {
            System.Data.Common.DbCommand command = e.Command;
            command.Parameters["@channel"].Value = ChannelsGrid.SelectedItems[0].Cells[2].Text;
            command.Parameters["@transactionid"].Value = TransactionsGrid.SelectedItems[0].Cells[2].Text;
            }
            catch (Exception x)
            {
                x.Message.Trim();
            }
        }

        protected void rulesDS_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            try
            {            
            System.Data.Common.DbCommand command = e.Command;
            command.Parameters["@channel"].Value = ChannelsGrid.SelectedItems[0].Cells[2].Text;
            }
            catch (Exception x)
            {
                x.Message.Trim();
            }
        }

        protected void AssetsDS_Inserted(object sender, SqlDataSourceStatusEventArgs e)
        {
            System.Data.Common.DbCommand command = e.Command;
            string assetID = "";
            string assetType = "";
            try
            {
                assetID = command.Parameters["@idnumber"].Value.ToString();
                assetType = command.Parameters["@type"].Value.ToString();

                XmlDocument enrollParams = new XmlDocument();
                enrollParams.LoadXml(Raf.B2B.Byte.NofifyEnrollmentXml().OuterXml);

                enrollParams.SelectSingleNode("Enrollment/AssetType").InnerText = assetType;
                enrollParams.SelectSingleNode("Enrollment/AssetID").InnerText = assetID;

                RafLog.Log.LogToFile("Logging: " + enrollParams.OuterXml);
                Raf.B2B.Byte.NofifyEnrollment(enrollParams);
            }
            catch (Exception x)
            {
                x.Message.Trim();
            }

        }

        protected void AssetsDS_Deleted(object sender, SqlDataSourceStatusEventArgs e)
        {

        }

   }
}
