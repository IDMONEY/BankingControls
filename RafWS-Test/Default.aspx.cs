using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace RafWS_Test
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private string string2XML(string xml)
        {
            xml = xml.Replace("&lt;", "<");
            xml = xml.Replace("&gt;", ">");
            return xml;
        }
        private string xml2string(string xml)
        {
            xml = xml.Replace("<","&lt;");
            xml = xml.Replace(">","&gt;");
            return xml;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (RafWS_Test.RafWS.RafQuery ls = new RafWS_Test.RafWS.RafQuery())
            {
             //Xdoc
/*
                 XmlDocument XDoc = new XmlDocument();
                 XDoc.LoadXml(string2XML(TextBox1.Text));

                 XmlDocument Resp = new XmlDocument();
                 //Resp.InnerXml = ls.GetAssetRules(TextBox1.Text).OuterXml;
                 Resp.InnerXml = ls.GetAssetRules(XDoc).OuterXml;
                 Xml1.Document = Resp;
*/
            //String
                String XML = "<RAF><Request><Login><user>BanSolCR01</user><passphrase>1bb094a47dcca0d2e8cd5b26c1</passphrase></Login><Parameters><prmAssetTypeId>300</prmAssetTypeId><prmAssetId>123</prmAssetId><prmLanguage>es</prmLanguage></Parameters></Request></RAF>";
                
                    
                XmlDocument Resp = new XmlDocument();
                Resp.InnerXml = ls.GetAssetRulesString(XML);
                Xml1.Document = Resp;



            }

        }
    }
}
