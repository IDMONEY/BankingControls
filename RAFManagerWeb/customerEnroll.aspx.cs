using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;

namespace RAFManagerWeb
{
    public partial class _customerEnroll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RAFSecurity _securityManager = new RAFSecurity();
            List<object> _data = _securityManager.searchForUsers(Page.User.Identity.Name, 5);
            if (_data.Count != 0)
            {
                if (!(_securityManager.getUserRights((int)_data[0] + "", "Section").Contains("SecCustomerEnroll")))
                {
                    Response.Redirect("/default.aspx");
                }
            }
        }


        protected void custIDTypeT_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            custIDNumT.ZeroPadNumericRanges = false;
            custIDNumT.DisplayPromptChar = "_";
            custIDNumT.PromptChar = "_";
            switch (custIDTypeT.SelectedValue)
            {
                case "1":
                    {
                        custIDNumT.Mask = "#-####-####";

                        companyNameT.Enabled = false;
                        companyNameT.Text = "";
                        nameT.Enabled = true;
                        lastNameT.Enabled = true;
                        lastName2T.Enabled = true;

                        break;
                    }
                case "2":
                    {
                        custIDNumT.Mask = "#-###-######";

                        companyNameT.Enabled = true;
                        nameT.Enabled = false;
                        lastNameT.Enabled = false;
                        lastName2T.Enabled = false;

                        nameT.Text = "";
                        lastNameT.Text = "";
                        lastName2T.Text = "";

                        break;
                    }
                default:
                    {
                        custIDNumT.Mask = "aaaaaaaaaaaaaaaaaaaaaa";
                        custIDNumT.DisplayPromptChar = " ";
                        custIDNumT.PromptChar = " ";

                        companyNameT.Enabled = false;
                        companyNameT.Text = "";
                        nameT.Enabled = true;
                        lastNameT.Enabled = true;
                        lastName2T.Enabled = true;

                        break;
                    }
            }
            custIDNumT.Text = "";
        }


        protected void enrollButton_Click(object sender, EventArgs e)
        {
            //Create xml to Post
            XmlDocument param = new XmlDocument();
            //Create xml to Collect
            XmlDocument resp = new XmlDocument();
            //Cust
            Int32 newCustomerID = new Int32();
            //Svc
            RAFProxy.RAFProxy rproxy = new RAFProxy.RAFProxy();
            param.LoadXml(rproxy.CustomerInsertParams().OuterXml);

            //Populate
            param.SelectSingleNode("/Params/Profile").Attributes["Value"].Value = "1";
            param.SelectSingleNode("/Params/Password").Attributes["Value"].Value = passphraseT.Text;
            param.SelectSingleNode("/Params/Photo").Attributes["Value"].Value = "";
            param.SelectSingleNode("/Params/FingerRight").Attributes["Value"].Value = null;
            param.SelectSingleNode("/Params/FingerLeft").Attributes["Value"].Value = null;
            param.SelectSingleNode("/Params/IDNumber").Attributes["Value"].Value = custIDNumT.Text;
            param.SelectSingleNode("/Params/IDType").Attributes["Value"].Value = custIDTypeT.SelectedValue;
            param.SelectSingleNode("/Params/IDCountry").Attributes["Value"].Value = countryT.SelectedValue;
            param.SelectSingleNode("/Params/FirstName").Attributes["Value"].Value = nameT.Text;
            param.SelectSingleNode("/Params/MiddleName").Attributes["Value"].Value = name2T.Text;
            param.SelectSingleNode("/Params/SurName1").Attributes["Value"].Value = lastNameT.Text;
            param.SelectSingleNode("/Params/SurName2").Attributes["Value"].Value = lastName2T.Text;
            param.SelectSingleNode("/Params/Suffix").Attributes["Value"].Value = "";
            param.SelectSingleNode("/Params/Country").Attributes["Value"].Value = countryT.SelectedValue;
            param.SelectSingleNode("/Params/Registrar").Attributes["Value"].Value = "1";
            param.SelectSingleNode("/Params/CompanyName").Attributes["Value"].Value = companyNameT.Text;

            resp.LoadXml(rproxy.CustomerInsert(param).OuterXml);

            if (resp.SelectSingleNode("/CustomerInsert/Status/ErrMsg").InnerText != "")
            {
                errorMsg.Visible = true;
                errorMsg.Text = resp.SelectSingleNode("/CustomerInsert/Status/ErrMsg").InnerText;
            }
            else
            {
                newCustomerID = Convert.ToInt32(resp.SelectSingleNode("/CustomerInsert/CustomerID").InnerText);
                Server.Transfer("/customerInfo.aspx?cu=" + newCustomerID.ToString(), false);
            }
        }

        
    

    }
}
