using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.IO; 
using System.Text;
using System.Text.RegularExpressions;
using RafLog;


namespace RafWS
{
    /// <summary>
    /// Summary description for RafQuery
    /// </summary>
    [WebService(Namespace = "http://api.ifar.biz/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[System.ComponentModel.ToolboxItem(false)]
    public class RafQuery : System.Web.Services.WebService
    {

        [WebMethod(CacheDuration = 72000, Description = "Crea el documento XML utilizado para llamar a GetAssetRules / Creates the XMLDocument used to call GetAssetRules")]
        //[System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare), RafWS.TraceExtension()]
        public XmlDocument GetAssetRulesParamsExample()
        {
            RafLog.Log.LogToFile("Call GetAssetRulesParamsExample");
            
            XmlDocument XDoc = new XmlDocument();
            XmlNode root = XDoc.CreateNode(XmlNodeType.Element, "RAF", "");
            XDoc.AppendChild(root);

            XmlNode req = XDoc.CreateNode(XmlNodeType.Element, "Request", "");
            root.AppendChild(req);

            XmlNode log = XDoc.CreateNode(XmlNodeType.Element, "Login", "");
            req.AppendChild(log);

            XmlNode par = XDoc.CreateNode(XmlNodeType.Element, "Parameters", "");
            req.AppendChild(par);

            log.AppendChild((XDoc.CreateNode(XmlNodeType.Element, "user", "")));
            log.AppendChild((XDoc.CreateNode(XmlNodeType.Element, "passphrase", "")));
            
            par.AppendChild((XDoc.CreateNode(XmlNodeType.Element, "prmAssetTypeId", "")));
            par.AppendChild((XDoc.CreateNode(XmlNodeType.Element, "prmAssetId", "")));
            par.AppendChild((XDoc.CreateNode(XmlNodeType.Element, "prmLanguage", "")));

            return XDoc;
        }


        [WebMethod(CacheDuration = 72000, Description = "Crea el documento XML utilizado para llamar a GetAssetRules / Creates the XMLDocument used to call GetAssetRules")]
        //[System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare), RafWS.TraceExtension()]
        public XmlDocument GetCreditRulesParamsExample()
        {
            RafLog.Log.LogToFile("Call GetCreditRulesParamsExample");

            XmlDocument XDoc = new XmlDocument();
            XmlNode root = XDoc.CreateNode(XmlNodeType.Element, "RAF", "");
            XDoc.AppendChild(root);

            XmlNode req = XDoc.CreateNode(XmlNodeType.Element, "Request", "");
            root.AppendChild(req);

            XmlNode log = XDoc.CreateNode(XmlNodeType.Element, "Login", "");
            req.AppendChild(log);

            XmlNode par = XDoc.CreateNode(XmlNodeType.Element, "Parameters", "");
            req.AppendChild(par);

            log.AppendChild((XDoc.CreateNode(XmlNodeType.Element, "user", "")));
            log.AppendChild((XDoc.CreateNode(XmlNodeType.Element, "passphrase", "")));

            par.AppendChild((XDoc.CreateNode(XmlNodeType.Element, "prmCustomerId", "")));
            par.AppendChild((XDoc.CreateNode(XmlNodeType.Element, "prmCustomerIdCountry", "")));
            par.AppendChild((XDoc.CreateNode(XmlNodeType.Element, "prmCreditTypeId", "")));
            par.AppendChild((XDoc.CreateNode(XmlNodeType.Element, "prmLanguage", "")));

            return XDoc;
        }



        [WebMethod(Description = "Consulta las reglas establecidas para un activo. Trata los parametros y la respuesta como strings de texto. / Queries the rules assigned to an asset. Treats input and output as strings. ")]
        public string GetAssetRulesString(string ParametersString)
        {
            XmlDocument XDoc = new XmlDocument();
            XDoc.LoadXml(string2XML(ParametersString));
            return GetAssetRules(XDoc,true,false).OuterXml;
        }

        //[WebMethod(CacheDuration = 3600, Description = "Consulta las reglas establecidas para un activo / Queries the rules assigned to an asset")]
        [WebMethod(Description = "Consulta las reglas establecidas para un activo / Queries the rules assigned to an asset")]
        public XmlDocument GetAssetRules(XmlDocument Parameters)
        {
            return GetAssetRules(Parameters, true, false);
        }

        private string string2XML(string xml)
        {
            xml = xml.Replace("&lt;", "<");
            xml = xml.Replace("&gt;", ">");
            return xml;
        }

        /*
        private string xml2string(string xml)
        {
            xml = xml.Replace("<","&lt;");
            xml = xml.Replace(">","&gt;");
            return xml;
        }
        */

        [WebMethod]
        public XmlDocument GetAssetRulesNoEnc(XmlDocument Parameters)
        {
          return GetAssetRules(Parameters,true,false);
        }

        [WebMethod]
        public string GetAssetRulesNoEncString(string Parameters)
        {
            XmlDocument XDoc = new XmlDocument();
            XDoc.LoadXml(string2XML(Parameters));
            return GetAssetRules(XDoc, true, false).OuterXml;
        }


        private XmlDocument GetAssetRules(XmlDocument Params, bool doSchemaVal, bool doEnc )
        {
            RafLog.Log.LogToFile("Call GetAssetRules");
            RafLog.Log.LogToFile("Requesting  IP: " + HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
            RafLog.Log.LogToFile("Forwarded For IP: " + HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
            //Log("ParamsString: " + ParamsString);
            if (Params.OuterXml != null)
            {
                RafLog.Log.LogToFile("ParamsString: " + Params.OuterXml);
            }
            else 
            {
                RafLog.Log.LogToFile("ParamsString: Empty");
            }

            #region Docs
            // Doc for return
            XmlDocument XmlResponse = new XmlDocument();

            XmlNode root = XmlResponse.AppendChild(XmlResponse.CreateNode(XmlNodeType.Element, "RAF", ""));

            XmlNode Req = root.AppendChild(XmlResponse.CreateNode(XmlNodeType.Element, "Request", ""));
            XmlNode Par = Req.AppendChild(XmlResponse.CreateNode(XmlNodeType.Element, "Parameters", ""));

            XmlNode Res = root.AppendChild(XmlResponse.CreateNode(XmlNodeType.Element, "Response", ""));
            XmlNode ResID = Res.AppendChild(XmlResponse.CreateNode(XmlNodeType.Element, "ResponseID", ""));
            XmlNode sT = Res.AppendChild(XmlResponse.CreateNode(XmlNodeType.Element, "Status", ""));
            XmlNode sTSucc = sT.AppendChild(XmlResponse.CreateNode(XmlNodeType.Element, "Success", ""));
            sTSucc.InnerText = "false";
            XmlNode ErrCode = sT.AppendChild(XmlResponse.CreateNode(XmlNodeType.Element, "ErrorCode", ""));
            ErrCode.InnerText = "0";
            XmlNode ErrName = sT.AppendChild(XmlResponse.CreateNode(XmlNodeType.Element, "ErrorName", ""));
            ErrName.InnerText = "DEFAULT_ERROR";
            XmlNode ErrMsg = sT.AppendChild(XmlResponse.CreateNode(XmlNodeType.Element, "ErrorMessage", ""));
            ErrMsg.InnerText = "Unknown Error";

            XmlNode Asset = Res.AppendChild(XmlResponse.CreateNode(XmlNodeType.Element, "Asset", ""));

            //Docs for getting the sp results
            string stringResp = "";
            XmlDocument dbResponse = new XmlDocument();
            //XmlDocument Params = new XmlDocument();
            XmlDocument assetRulesXml = new XmlDocument();

            //Docs for Validating
            XmlDocument XDocValidate = new XmlDocument();
            XmlDocument XDocValidate2 = new XmlDocument();
            
            #endregion
            //////////////////////////////////////////////////////////////////

            RafLog.Log.LogToFile("CleanXml");
            #region CleanXml
            try{
                if (Params.FirstChild.Attributes["xmlns"] != null) 
                {
                    string tmpX = Params.OuterXml;
                    Regex RegexObj = new Regex("\\s?xmlns=\".+?\"");
                    Params.InnerXml = RegexObj.Replace(tmpX, "");
                    RafLog.Log.LogToFile("Cleaned: " + tmpX);
                }
            }
            catch (Exception x1)
            {
                RafLog.Log.LogToFile("Failed cleaning XML. Error: " + x1.Message);
            }
            #endregion
            RafLog.Log.LogToFile("A");
            try
            {
                RafLog.Log.LogToFile("A1");

                //Validate XmlData
                if (doSchemaVal)
                {
                    XDocValidate = ValXML.validateAssetRulesCall(Params);

                    RafLog.Log.LogToFile("A2");

                    //If Error, Return
                    if (
                        (XDocValidate.FirstChild.SelectSingleNode("Error").Attributes["Value"] != null) &&
                        (XDocValidate.FirstChild.SelectSingleNode("Error").Attributes["Value"].Value != "")
                       )
                    {
                        RafLog.Log.LogToFile("A3");
                        ErrCode.InnerText = "100";
                        ErrName.InnerText = "INVALID_XML_CALL";
                        ErrMsg.InnerText = XDocValidate.FirstChild.SelectSingleNode("Error").Attributes["Value"].Value;
                        //IfError
                        //
                        RafLog.Log.LogToFile("Invalid XML");
                        RafLog.Log.LogToFile(XmlResponse.OuterXml);
                        return XmlResponse;
                    }

                }
                
                RafLog.Log.LogToFile("B");

                Par.InnerXml = Params.SelectSingleNode("/RAF/Request/Parameters").InnerXml;

                string connStr = ConfigurationManager.ConnectionStrings["dbConnectionRAFMain"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    RafLog.Log.LogToFile("C");
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "proc_getAssetRules";
                    cmd.Parameters.Add("@p_asset", SqlDbType.VarChar).Value = Params.SelectSingleNode("/RAF/Request/Parameters/prmAssetId").InnerText;
                    cmd.Parameters.Add("@p_assettype", SqlDbType.SmallInt).Value =  Convert.ToInt32(Params.SelectSingleNode("/RAF/Request/Parameters/prmAssetTypeId").InnerText);
                    cmd.Parameters.Add("@p_lang", SqlDbType.Char, 2).Value = Params.SelectSingleNode("/RAF/Request/Parameters/prmLanguage").InnerText;
                    cmd.Parameters.Add("@p_user", SqlDbType.VarChar).Value =  Params.SelectSingleNode("/RAF/Request/Login/user").InnerText;
                    cmd.Parameters.Add("@p_passphrase", SqlDbType.VarChar).Value = Params.SelectSingleNode("/RAF/Request/Login/passphrase").InnerText;
                    RafLog.Log.LogToFile("C9");

                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                    }
                    RafLog.Log.LogToFile("C1");
                    SqlDataReader rdr = cmd.ExecuteReader();
                    RafLog.Log.LogToFile("C2");
                    if (rdr.Read())
                    {
                        if (rdr.FieldCount > 0 && !rdr.IsDBNull(0)) stringResp = rdr.GetString(0);

                    }
                    if (cmd.Connection.State != ConnectionState.Closed)
                    {
                        cmd.Connection.Close();
                    }
                }

                RafLog.Log.LogToFile("D");
                RafLog.Log.LogToFile("DB Response : " + stringResp);

                //Validate Asset Rules
                //First lets see if its an xml
                try {
                    RafLog.Log.LogToFile("D1");
                    dbResponse.LoadXml(stringResp);
                }
                catch (XmlException xx){
                    RafLog.Log.LogToFile("D2");
                    ErrName.InnerText = "MALFORMED_XML_FROM_DB";
                    ErrCode.InnerText = "200";
                    ErrMsg.InnerText = "Invalid Rules";
                    RafLog.Log.LogToFile("MALFORMED_XML_FROM_DB");
                    RafLog.Log.LogToFile(XmlResponse.OuterXml);
                    RafLog.Log.LogToFile("D3");

                }
                catch (Exception xx2)
                {
                    RafLog.Log.LogToFile("D4");
                    ErrName.InnerText = "MALFORMED_XML_FROM_DB";
                    ErrCode.InnerText = "200";
                    ErrMsg.InnerText = "Invalid Rules";
                    RafLog.Log.LogToFile("MALFORMED_XML_FROM_DB");
                    RafLog.Log.LogToFile(XmlResponse.OuterXml);
                    RafLog.Log.LogToFile("D5");
                }
                
                RafLog.Log.LogToFile("FLOW1");

                RafLog.Log.LogToFile("ErrCode.InnerText " + ErrCode.InnerText);

                
                //Now Load the status into our main xml to catch any errors the Sp might have produced
                if (ErrCode.InnerText == "0")
                {
                    RafLog.Log.LogToFile("EA");
                    if (dbResponse.SelectSingleNode("/Response/Status") != null)
                    {
                        RafLog.Log.LogToFile("E");
                        if (dbResponse.SelectSingleNode("/Response/Status/ErrorName") != null)
                        {
                            RafLog.Log.LogToFile("E1");
                            ErrName.InnerText = dbResponse.SelectSingleNode("/Response/Status/ErrorName").InnerText;
                        }
                        if (dbResponse.SelectSingleNode("/Response/Status/ErrorCode") != null)
                        {
                            RafLog.Log.LogToFile("E2");
                            ErrCode.InnerText = dbResponse.SelectSingleNode("/Response/Status/ErrorCode").InnerText;
                        }
                        if (dbResponse.SelectSingleNode("/Response/Status/ErrorMessage") != null)
                        {
                            RafLog.Log.LogToFile("E3");
                            ErrMsg.InnerText = dbResponse.SelectSingleNode("/Response/Status/ErrorMessage").InnerText;
                        }
                    }
                }

                RafLog.Log.LogToFile("FLOW2");

                //Validate XmlData
                if (ErrCode.InnerText == "0")
                {
                    RafLog.Log.LogToFile("F1");
                    assetRulesXml.LoadXml(dbResponse.SelectSingleNode("/Response/Asset/ValidChannels").OuterXml);
                    
                    XDocValidate2 = ValXML.validateAssetRules(assetRulesXml);

                    //If Error, Return
                    if (
                        (XDocValidate2.FirstChild.SelectSingleNode("Error").Attributes["Value"] != null) &&
                        (XDocValidate2.FirstChild.SelectSingleNode("Error").Attributes["Value"].Value != "")
                       )
                    {
                        RafLog.Log.LogToFile("F2");
                        ErrName.InnerText = "MALFORMED_RULES";
                        ErrCode.InnerText = "201";
                        ErrMsg.InnerText = XDocValidate2.FirstChild.SelectSingleNode("Error").Attributes["Value"].Value;

                        //try to respond something at least
                        Asset.InnerXml = assetRulesXml.InnerXml;

                        //IfError
                        //
                        RafLog.Log.LogToFile("MALFORMED_RULES");
                        RafLog.Log.LogToFile(XmlResponse.OuterXml);
                        RafLog.Log.LogToFile("F3");
                        return XmlResponse;
                    }
                }

                RafLog.Log.LogToFile("FLOW3");

                if (ErrCode.InnerText == "0")
                {
                    RafLog.Log.LogToFile("G1");
                    if (dbResponse.SelectSingleNode("/Response/ResponseID") != null)
                    {
                        ResID.InnerText = dbResponse.SelectSingleNode("/Response/ResponseID").InnerText;
                    }
                    Asset.InnerXml = assetRulesXml.InnerXml;
                    //Status
                    sTSucc.InnerText = "true";
                }

                RafLog.Log.LogToFile("FLOW4");

                //IfError
                if (ErrCode.InnerText != "0")
                {
                    RafLog.Log.LogToFile(XmlResponse.OuterXml);
                }

                RafLog.Log.LogToFile("FLOW5");

            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
                ErrCode.InnerText = "1";
                RafLog.Log.LogToFile("ERROR: " + ex.Message);
            }
            RafLog.Log.LogToFile("XmlResponse: " + XmlResponse.OuterXml);
            return XmlResponse;
        }

        //////////////

        [WebMethod(Description = "Confirma el resultado de una transacción luego de que las voluntades fueron consultadas. Trata los parametros y la respuesta como strings de texto. / Reports back to RAF the outcome of a client transaction after the asset rules were requested. Treats input and output as strings. ")]
        public void ReportTranOutcome(XmlDocument report)
        {
            RafLog.Log.LogToFile("ReportTranOutcome");
            RafLog.Log.LogToFile(report.OuterXml);
        }


        [WebMethod(Description = "Confirma el resultado de una transacción luego de que las voluntades fueron consultadas. Trata los parametros y la respuesta como strings de texto. / Reports back to RAF the outcome of a client transaction after the asset rules were requested. Treats input and output as strings. ")]
        public void ReportTranOutcomeString(string reportString)
        {
            XmlDocument XDoc = new XmlDocument();
            XDoc.LoadXml(string2XML(reportString));
            ReportTranOutcome(XDoc);
        }





        [WebMethod]
        public XmlDocument GetCreditRulesNoEnc(XmlDocument Parameters)
        {
            return GetCreditRules(Parameters, true, false);
        }

        [WebMethod]
        public string GetCreditRulesNoEncString(string Parameters)
        {
            XmlDocument XDoc = new XmlDocument();
            XDoc.LoadXml(string2XML(Parameters));
            return GetCreditRules(XDoc, true, false).OuterXml;
        }

        [WebMethod]
        public string GetCreditRulesString(string Parameters)
        {
            XmlDocument XDoc = new XmlDocument();
            XDoc.LoadXml(string2XML(Parameters));
            return GetCreditRules(XDoc, true, false).OuterXml;
        }

        private XmlDocument GetCreditRules(XmlDocument Params, bool doSchemaVal, bool doEnc)
        {
            RafLog.Log.LogToFile("Call GetCreditRules");
            RafLog.Log.LogToFile("Requesting  IP: " + HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
            RafLog.Log.LogToFile("Forwarded For IP: " + HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
            //Log("ParamsString: " + ParamsString);
            if (Params.OuterXml != null)
            {
                RafLog.Log.LogToFile("ParamsString: " + Params.OuterXml);
            }
            else
            {
                RafLog.Log.LogToFile("ParamsString: Empty");
            }

            #region Docs
            // Doc for return
            XmlDocument XmlResponse = new XmlDocument();

            XmlNode root = XmlResponse.AppendChild(XmlResponse.CreateNode(XmlNodeType.Element, "RAF", ""));

            XmlNode Req = root.AppendChild(XmlResponse.CreateNode(XmlNodeType.Element, "Request", ""));
            XmlNode Par = Req.AppendChild(XmlResponse.CreateNode(XmlNodeType.Element, "Parameters", ""));

            XmlNode Res = root.AppendChild(XmlResponse.CreateNode(XmlNodeType.Element, "Response", ""));
            XmlNode ResID = Res.AppendChild(XmlResponse.CreateNode(XmlNodeType.Element, "ResponseID", ""));
            XmlNode sT = Res.AppendChild(XmlResponse.CreateNode(XmlNodeType.Element, "Status", ""));
            XmlNode sTSucc = sT.AppendChild(XmlResponse.CreateNode(XmlNodeType.Element, "Success", ""));
            sTSucc.InnerText = "false";
            XmlNode ErrCode = sT.AppendChild(XmlResponse.CreateNode(XmlNodeType.Element, "ErrorCode", ""));
            ErrCode.InnerText = "0";
            XmlNode ErrName = sT.AppendChild(XmlResponse.CreateNode(XmlNodeType.Element, "ErrorName", ""));
            ErrName.InnerText = "DEFAULT_ERROR";
            XmlNode ErrMsg = sT.AppendChild(XmlResponse.CreateNode(XmlNodeType.Element, "ErrorMessage", ""));
            ErrMsg.InnerText = "Unknown Error";

            XmlNode Credit = Res.AppendChild(XmlResponse.CreateNode(XmlNodeType.Element, "Credit", ""));

            //Docs for getting the sp results
            string stringResp = "";
            XmlDocument dbResponse = new XmlDocument();
            //XmlDocument Params = new XmlDocument();
            XmlDocument creditRulesXml = new XmlDocument();

            //Docs for Validating
            XmlDocument XDocValidate = new XmlDocument();
            XmlDocument XDocValidate2 = new XmlDocument();

            #endregion
            //////////////////////////////////////////////////////////////////

            RafLog.Log.LogToFile("CleanXml");
            #region CleanXml
            try
            {
                if (Params.FirstChild.Attributes["xmlns"] != null)
                {
                    string tmpX = Params.OuterXml;
                    Regex RegexObj = new Regex("\\s?xmlns=\".+?\"");
                    Params.InnerXml = RegexObj.Replace(tmpX, "");
                    RafLog.Log.LogToFile("Cleaned: " + tmpX);
                }
            }
            catch (Exception x1)
            {
                RafLog.Log.LogToFile("Failed cleaning XML. Error: " + x1.Message);
            }
            #endregion
            RafLog.Log.LogToFile("A");
            try
            {
                RafLog.Log.LogToFile("A1");

                //Validate XmlData
                if (doSchemaVal)
                {
                    XDocValidate = ValXML.validateCreditRulesCall(Params);

                    RafLog.Log.LogToFile("A2");

                    //If Error, Return
                    if (
                        (XDocValidate.FirstChild.SelectSingleNode("Error").Attributes["Value"] != null) &&
                        (XDocValidate.FirstChild.SelectSingleNode("Error").Attributes["Value"].Value != "")
                       )
                    {
                        RafLog.Log.LogToFile("A3");
                        ErrCode.InnerText = "100";
                        ErrName.InnerText = "INVALID_XML_CALL";
                        ErrMsg.InnerText = XDocValidate.FirstChild.SelectSingleNode("Error").Attributes["Value"].Value;
                        //IfError
                        //
                        RafLog.Log.LogToFile("Invalid XML");
                        RafLog.Log.LogToFile(XmlResponse.OuterXml);
                        return XmlResponse;
                    }

                }

                RafLog.Log.LogToFile("B");

                Par.InnerXml = Params.SelectSingleNode("/RAF/Request/Parameters").InnerXml;

                string connStr = ConfigurationManager.ConnectionStrings["dbConnectionRAFMain"].ConnectionString;
                using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr))
                {
                    RafLog.Log.LogToFile("C");
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                    cmd.Connection = conn;
                    //cmd.CommandText = "CALL proc_getAssetRules(?p_xml, ?p_asset, ?p_assettype , ?p_lang , ?p_user , ?p_passphrase);Select @p_xml;";
                    //cmd.Parameters.Add("@p_xml", MySqlDbType.VarChar);
                    cmd.CommandText = "CALL proc_getCreditRules(?p_creditType, ?p_customerID, ?p_country , ?p_lang , ?p_user , ?p_passphrase);";

                    cmd.Parameters.Add("?p_creditType", MySqlDbType.UInt16).Value = Convert.ToInt32(Params.SelectSingleNode("/RAF/Request/Parameters/prmCreditTypeId").InnerText);
                    cmd.Parameters.Add("?p_customerID", MySqlDbType.VarChar).Value = Params.SelectSingleNode("/RAF/Request/Parameters/prmCustomerId").InnerText;
                    cmd.Parameters.Add("?p_country", MySqlDbType.VarChar).Value = Params.SelectSingleNode("/RAF/Request/Parameters/prmCustomerIdCountry").InnerText;
                    
                    cmd.Parameters.Add("?p_lang", MySqlDbType.VarChar).Value = Params.SelectSingleNode("/RAF/Request/Parameters/prmLanguage").InnerText;
                    cmd.Parameters.Add("?p_user", MySqlDbType.VarChar).Value = Params.SelectSingleNode("/RAF/Request/Login/user").InnerText;
                    cmd.Parameters.Add("?p_passphrase", MySqlDbType.VarChar).Value = Params.SelectSingleNode("/RAF/Request/Login/passphrase").InnerText;
                    RafLog.Log.LogToFile("C9");

                    cmd.Connection.Open();
                    RafLog.Log.LogToFile("C1");
                    MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();
                    RafLog.Log.LogToFile("C2");
                    if (rdr.Read())
                    {
                        if (rdr.FieldCount > 0 && !rdr.IsDBNull(0)) stringResp = rdr.GetString(0);

                    }
                }

                RafLog.Log.LogToFile("D");
                RafLog.Log.LogToFile("DB Response : " + stringResp);

                //Validate Credit Rules
                //First lets see if its an xml
                try
                {
                    RafLog.Log.LogToFile("D1");
                    dbResponse.LoadXml(stringResp);
                }
                catch (XmlException xx)
                {
                    RafLog.Log.LogToFile("D2");
                    ErrName.InnerText = "MALFORMED_XML_FROM_DB";
                    ErrCode.InnerText = "200";
                    ErrMsg.InnerText = "Invalid Rules";
                    RafLog.Log.LogToFile("MALFORMED_XML_FROM_DB");
                    RafLog.Log.LogToFile(XmlResponse.OuterXml);
                    RafLog.Log.LogToFile("D3");

                }
                catch (Exception xx2)
                {
                    RafLog.Log.LogToFile("D4");
                    ErrName.InnerText = "MALFORMED_XML_FROM_DB";
                    ErrCode.InnerText = "200";
                    ErrMsg.InnerText = "Invalid Rules";
                    RafLog.Log.LogToFile("MALFORMED_XML_FROM_DB");
                    RafLog.Log.LogToFile(XmlResponse.OuterXml);
                    RafLog.Log.LogToFile("D5");
                }

                RafLog.Log.LogToFile("FLOW1");

                RafLog.Log.LogToFile("ErrCode.InnerText " + ErrCode.InnerText);


                //Now Load the status into our main xml to catch any errors the Sp might have produced
                if (ErrCode.InnerText == "0")
                {
                    RafLog.Log.LogToFile("EA");
                    if (dbResponse.SelectSingleNode("/Response/Status") != null)
                    {
                        RafLog.Log.LogToFile("E");
                        if (dbResponse.SelectSingleNode("/Response/Status/ErrorName") != null)
                        {
                            RafLog.Log.LogToFile("E1");
                            ErrName.InnerText = dbResponse.SelectSingleNode("/Response/Status/ErrorName").InnerText;
                        }
                        if (dbResponse.SelectSingleNode("/Response/Status/ErrorCode") != null)
                        {
                            RafLog.Log.LogToFile("E2");
                            ErrCode.InnerText = dbResponse.SelectSingleNode("/Response/Status/ErrorCode").InnerText;
                        }
                        if (dbResponse.SelectSingleNode("/Response/Status/ErrorMessage") != null)
                        {
                            RafLog.Log.LogToFile("E3");
                            ErrMsg.InnerText = dbResponse.SelectSingleNode("/Response/Status/ErrorMessage").InnerText;
                        }
                    }
                }

                RafLog.Log.LogToFile("FLOW2");

                //Validate XmlData
                if (ErrCode.InnerText == "0")
                {
                    RafLog.Log.LogToFile("F1");
                    creditRulesXml.LoadXml(dbResponse.SelectSingleNode("/Response/Credit").OuterXml);

                    XDocValidate2 = ValXML.validateCreditRules(creditRulesXml);

                    //If Error, Return
                    if (
                        (XDocValidate2.FirstChild.SelectSingleNode("Error").Attributes["Value"] != null) &&
                        (XDocValidate2.FirstChild.SelectSingleNode("Error").Attributes["Value"].Value != "")
                       )
                    {
                        RafLog.Log.LogToFile("F2");
                        ErrName.InnerText = "MALFORMED_RULES";
                        ErrCode.InnerText = "201";
                        ErrMsg.InnerText = XDocValidate2.FirstChild.SelectSingleNode("Error").Attributes["Value"].Value;

                        //try to respond something at least
                        Credit.InnerXml = creditRulesXml.InnerXml;

                        //IfError
                        //
                        RafLog.Log.LogToFile("MALFORMED_RULES");
                        RafLog.Log.LogToFile(XmlResponse.OuterXml);
                        RafLog.Log.LogToFile("F3");
                        return XmlResponse;
                    }
                }

                RafLog.Log.LogToFile("FLOW3");

                if (ErrCode.InnerText == "0")
                {
                    RafLog.Log.LogToFile("G1");
                    if (dbResponse.SelectSingleNode("/Response/ResponseID") != null)
                    {
                        ResID.InnerText = dbResponse.SelectSingleNode("/Response/ResponseID").InnerText;
                    }
                    Credit.InnerXml = creditRulesXml.FirstChild.InnerXml;
                    //Status
                    sTSucc.InnerText = "true";
                }

                RafLog.Log.LogToFile("FLOW4");

                //IfError
                if (ErrCode.InnerText != "0")
                {
                    RafLog.Log.LogToFile(XmlResponse.OuterXml);
                }

                RafLog.Log.LogToFile("FLOW5");

            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
                ErrCode.InnerText = "1";
                RafLog.Log.LogToFile("ERROR: " + ex.Message);
            }
            RafLog.Log.LogToFile("XmlResponse: " + XmlResponse.OuterXml);
            return XmlResponse;
        }




    }



}
