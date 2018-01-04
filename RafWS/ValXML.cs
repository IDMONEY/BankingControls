using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.Xml.Schema;
using System.Configuration;
using System.IO;
using System.Text;
using RafLog;

namespace RafWS
{
    public class ValXML
    {
        public static XmlDocument validateAssetRulesCall(XmlDocument InputXml)
        {
            string xsd = "svcCall.xsd";
            return validateXml(InputXml,xsd);
        }

        public static XmlDocument validateAssetRules(XmlDocument InputXml)
        {
            string xsd = "svcAssetRules.xsd";
            return validateXml(InputXml, xsd);
        }

        public static XmlDocument validateCreditRulesCall(XmlDocument InputXml)
        {
            string xsd = "svcCreditRulesCall.xsd";
            return validateXml(InputXml, xsd);
        }

        public static XmlDocument validateCreditRules(XmlDocument InputXml)
        {
            string xsd = "svcCreditRules.xsd";
            return validateXml(InputXml, xsd);
        }

        private static XmlDocument validateXml(XmlDocument InputXml, string xsd)
        {
            XmlDocument XDocValidate = new XmlDocument();
            XmlNode root = XDocValidate.CreateNode(XmlNodeType.Element, "ValidateXML", "");
            XDocValidate.AppendChild(root);
            root.AppendChild(XDocValidate.CreateNode(XmlNodeType.Element, "Valid", ""));
            root.AppendChild(XDocValidate.CreateNode(XmlNodeType.Element, "Error", ""));

            root.SelectSingleNode("Valid").Attributes.SetNamedItem(XDocValidate.CreateNode(XmlNodeType.Attribute, "Value", "")).Value = "";
            root.SelectSingleNode("Error").Attributes.SetNamedItem(XDocValidate.CreateNode(XmlNodeType.Attribute, "Value", "")).Value = "";

            XDocValidate.FirstChild.SelectSingleNode("Valid").Attributes["Value"].Value = "false";
            XDocValidate.FirstChild.SelectSingleNode("Error").Attributes["Value"].Value = "Unkown Error.";

            bool isError = false;

            try
            {
                //XML Location
                string xmlLoc = ConfigurationManager.AppSettings.Get("xmlLocation");
                
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
                settings.Schemas.Add(null, xmlLoc + xsd);
                settings.ValidationEventHandler += delegate(object sender, ValidationEventArgs vargs)
                {
                    XDocValidate.FirstChild.SelectSingleNode("Error").Attributes["Value"].Value = 
                        vargs.Message + " Character Position: " + vargs.Exception.LinePosition;
                    isError = true;
                    //RafLog.Log.LogToFile();

                };
               byte[] byteArray = Encoding.UTF8.GetBytes( InputXml.OuterXml );
               MemoryStream stream = new MemoryStream( byteArray );

               using (XmlReader reader = XmlReader.Create(stream, settings))
               {
                   while (reader.Read()) { }
               }

               if (isError == false)
               {
                   XDocValidate.FirstChild.SelectSingleNode("Valid").Attributes["Value"].Value = "true";
                   XDocValidate.FirstChild.SelectSingleNode("Error").Attributes["Value"].Value = "";
               }
            }
            catch (XmlException XmlExp)
            {
                XDocValidate.FirstChild.SelectSingleNode("Error").Attributes["Value"].Value = XmlExp.Message;
            }
            catch (XmlSchemaException XmlSchExp)
            {
                XDocValidate.FirstChild.SelectSingleNode("Error").Attributes["Value"].Value = XmlSchExp.Message;
            }
            catch (Exception GenExp)
            {
                GenExp.Message.Trim();
            }

            return XDocValidate;
        }

    }
}
