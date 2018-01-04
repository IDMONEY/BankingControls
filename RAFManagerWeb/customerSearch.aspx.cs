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
using System.Xml;
using System.Collections.Generic;

namespace RAFManagerWeb
{
    public partial class customerSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RAFSecurity _securityManager = new RAFSecurity();
            List<object> _data = _securityManager.searchForUsers(Page.User.Identity.Name, 5);
            if (_data.Count != 0)
            {
                if (!(_securityManager.getUserRights((int)_data[0] + "", "Section").Contains("SecCustomerSearch")))
                {
                    Response.Redirect("/default.aspx");
                }
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            RAFProxy.RAFProxy svc = new RAFProxy.RAFProxy();
            DataSet custSearchResults = new DataSet();
            XmlDocument paramsXML = new XmlDocument();

            try
            {
                paramsXML.LoadXml(svc.CustomerSearchParams().OuterXml);

                //Values
                paramsXML.SelectSingleNode("/Params/FirstName/@Value").Value = nameT.Text;
                paramsXML.SelectSingleNode("/Params/SurName1/@Value").Value = lastNameT.Text;
                paramsXML.SelectSingleNode("/Params/SurName2/@Value").Value = lastName2T.Text;
                paramsXML.SelectSingleNode("/Params/CompanyName/@Value").Value = companyNameT.Text;
                paramsXML.SelectSingleNode("/Params/IDType/@Value").Value = custIDTypeT.SelectedValue;
                paramsXML.SelectSingleNode("/Params/IDNumber/@Value").Value = custIDNumT.Text;

                //REset Grid
                resultsGrid.MasterTableView.NoMasterRecordsText = "No hay Resultados";
                resultsGrid.DataSource = new string[] { }; //flush
                
                //Svc Call
                resultsGrid.Visible = true;

                custSearchResults = svc.CustomerSearch(paramsXML);
                if (custSearchResults.Tables.Count > 0)
                {
                    if (
                        (custSearchResults.Tables[0] != null) &&
                        (custSearchResults.Tables[0].Rows.Count > 0)
                        )
                    {
                        resultsGrid.DataSource = custSearchResults.Tables[0];
                    }                
                }
                
                resultsGrid.DataBind();
            }
            catch (Exception x)
            {
                resultsGrid.MasterTableView.NoMasterRecordsText = "Ha ocurrido un error interno en la búsqueda";
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
                        break;
                    }
                case "2":
                    {
                        custIDNumT.Mask = "#-###-######";
                        break;
                    }
                default:
                    {
                        custIDNumT.Mask = "aaaaaaaaaaaaaaaaaaaaaa";
                        custIDNumT.DisplayPromptChar = " ";
                        custIDNumT.PromptChar = " ";
                        break;
                    }
            }
            custIDNumT.Text = "";
        }
    }
}
