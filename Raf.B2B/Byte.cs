using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using RafLog;

namespace Raf.B2B
{
    public class Byte
    {
        public static void NofifyEnrollment(XmlDocument enrollment)
        {
            string assetTypeId = "";
            string assetId = "";
            string operation = "";
            bool result = false;
            bool retSpec = false;
            RafLog.Log.LogToFile("NofifyEnrollment");
            try
            {
                assetTypeId = enrollment.FirstChild.SelectSingleNode("AssetType").InnerText;
                assetId = enrollment.FirstChild.SelectSingleNode("AssetID").InnerText;
                operation = enrollment.FirstChild.SelectSingleNode("Operation").InnerText;

                ByteEnrolSvc.ByteRafWS bSvc = new ByteEnrolSvc.ByteRafWS();
                
                bSvc.RafNotify(assetTypeId, assetId, operation, out result, out retSpec );
                RafLog.Log.LogToFile("Result: " + result.ToString() + " retSpec: " + retSpec.ToString());
                RafLog.Log.LogToDB("RafB2B",'M',"RafNotify","",enrollment.OuterXml,result.ToString());

            }
            catch (Exception ex)
            {
                RafLog.Log.LogToFile(ex.Message);
            }
        }


        public static XmlDocument NofifyEnrollmentXml()
        {
            XmlDocument xml = new XmlDocument();

            XmlNode root = xml.CreateNode(XmlNodeType.Element, "Enrollment","");
            xml.AppendChild(root);

            XmlNode at = root.AppendChild(xml.CreateNode(XmlNodeType.Element, "AssetType", ""));
            XmlNode ai = root.AppendChild(xml.CreateNode(XmlNodeType.Element, "AssetID", ""));
            XmlNode o = root.AppendChild(xml.CreateNode(XmlNodeType.Element, "Operation", ""));
            //"A"(Alta) = Enroll / "B" (Baja) = Delist
            o.InnerText = "A";
            return xml;
        }

        public void RafNotifyCompleted(object e, EventArgs a)
        {
            string r = a.GetType().ToString();
        }
        
    }
}
