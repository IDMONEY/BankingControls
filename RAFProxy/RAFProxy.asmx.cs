using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Text.RegularExpressions;

namespace RAFProxy
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class RAFProxy : System.Web.Services.WebService
    {
        //Start Logger
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        [WebMethod(CacheDuration = 3600)]
        public XmlDocument CustomerInsertParams()
        {

            XmlDocument XDoc = new XmlDocument();
            
            XDoc.LoadXml(@"
                <Params>
                  <Lang Value=""2"" DataType=""Int"" Length="""" Required=""true"" IfEmptyRequires="""" />
                  <Profile Value=""1"" DataType=""Int"" Length="""" Required=""true"" IfEmptyRequires="""" />  
                  <Password Value="""" DataType=""String"" Length=""45"" Required=""true"" IfEmptyRequires="""" />    
                  <Photo Value="""" DataType=""Blob"" Length="""" Required=""false"" IfEmptyRequires="""" />    
                  <FingerRight Value="""" DataType=""String"" Length=""1024"" Required=""false"" IfEmptyRequires="""" />  
                  <FingerLeft Value="""" DataType=""String"" Length=""1024"" Required=""false"" IfEmptyRequires="""" />    
                  <IDNumber Value="""" DataType=""String"" Length=""128"" Required=""true"" IfEmptyRequires="""" />
                  <IDType Value="""" DataType=""Int"" Length="""" Required=""true"" IfEmptyRequires="""" />
                  <IDCountry Value="""" DataType=""Int"" Length="""" Required=""true"" IfEmptyRequires="""" />  
                  <FirstName Value="""" DataType=""String"" Length=""45"" Required=""false"" IfEmptyRequires=""CompanyName"" />  
                  <MiddleName Value="""" DataType=""String"" Length=""45"" Required=""false"" IfEmptyRequires="""" />    
                  <SurName1 Value="""" DataType=""String"" Length=""45"" Required=""false"" IfEmptyRequires="""" />    
                  <SurName2 Value="""" DataType=""String"" Length=""45"" Required=""false"" IfEmptyRequires="""" />      
                  <Suffix Value="""" DataType=""String"" Length=""5"" Required=""false"" IfEmptyRequires="""" />      
                  <Country Value="""" DataType=""Int"" Length="""" Required=""true"" IfEmptyRequires="""" />      
                  <Registrar Value=""1"" DataType=""Int"" Length="""" Required=""true"" IfEmptyRequires="""" />      
                  <CompanyName Value="""" DataType=""String"" Length=""150"" Required=""false"" IfEmptyRequires=""FirstName"" /> 
                </Params>");

            return XDoc;
        }

        private string string2XML(string xml)
        {
            xml = xml.Replace("&lt;", "<");
            xml = xml.Replace("&gt;", ">");
            return xml;
        }

        public string CustomerInsertString(string xmlString)
        {
            XmlDocument XDoc = new XmlDocument();
            XDoc.LoadXml(string2XML(xmlString));
            return CustomerInsert(XDoc).OuterXml;
        }

        [WebMethod]
        public XmlDocument CustomerInsert(XmlDocument Params)
        {

            // Doc for return
            XmlDocument XmlCustomer = new XmlDocument();

            XmlNode root = XmlCustomer.AppendChild(XmlCustomer.CreateNode(XmlNodeType.Element, "CustomerInsert", ""));

            XmlNode sT = root.AppendChild(XmlCustomer.CreateNode(XmlNodeType.Element, "Status", ""));
            XmlNode sTSucc = sT.AppendChild(XmlCustomer.CreateNode(XmlNodeType.Element, "Success", ""));
            sTSucc.InnerText = "false";
            XmlNode sTErr = sT.AppendChild(XmlCustomer.CreateNode(XmlNodeType.Element, "ErrMsg", ""));
            XmlNode sTErr2 = sT.AppendChild(XmlCustomer.CreateNode(XmlNodeType.Element, "IntErrMsg", ""));

            XmlNode Res = root.AppendChild(XmlCustomer.CreateNode(XmlNodeType.Element, "CustomerID", ""));
            Res.InnerText = "0";

            SqlCommand cmdExec = new SqlCommand();
            SqlConnection conn = new SqlConnection();

            try
            {
                //Validate XmlData
                XmlDocument XDocValidate = new XmlDocument();
                XDocValidate.LoadXml(ValidateParamsXML(Params).InnerXml);

                //If Error, Return
                if (
                    (XDocValidate.FirstChild.SelectSingleNode("Error").Attributes["Value"] != null) &&
                    (XDocValidate.FirstChild.SelectSingleNode("Error").Attributes["Value"].Value != "")
                   )
                {
                    sTErr2.InnerText = XDocValidate.FirstChild.SelectSingleNode("Error").Attributes["Value"].Value;
                    //IfError
                    log.Error("Error Validating XML Params. RAFProxy.CustomerInsert()"
                        + Params.ToString()
                    );

                    return XmlCustomer;
                }


                /*************************/
                // DB
                /*************************/

                string RespIdCust = null;
                string RespError = null;
                string RespSuccess = null;

                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbConnectionRAFMain"].ConnectionString;
                cmdExec.Connection = conn;
                cmdExec.CommandType = CommandType.StoredProcedure;
                cmdExec.CommandText = "meta_customerInsertNew";

                cmdExec.Parameters.Add("@p_language", SqlDbType.SmallInt).Value = Params.SelectSingleNode("/Params/Lang").Attributes["Value"].Value;
                cmdExec.Parameters.Add("@p_idprofile", SqlDbType.TinyInt).Value = Convert.ToInt16(Params.SelectSingleNode("/Params/Profile").Attributes["Value"].Value);
                cmdExec.Parameters.Add("@p_password", SqlDbType.VarChar,45).Value = Params.SelectSingleNode("/Params/Password").Attributes["Value"].Value;
                //cmdExec.Parameters.Add("@p_photo", SqlDbType.VarBinary).Value =  Convert.ToByte(Params.SelectSingleNode("/Params/Photo").Attributes["Value"].Value);
                cmdExec.Parameters.Add("@p_fingerprintright", SqlDbType.Text).Value = Params.SelectSingleNode("/Params/FingerRight").Attributes["Value"].Value;
                cmdExec.Parameters.Add("@p_fingerprintleft", SqlDbType.Text).Value = Params.SelectSingleNode("/Params/FingerLeft").Attributes["Value"].Value;
                cmdExec.Parameters.Add("@p_idnumber", SqlDbType.VarChar,128).Value = Params.SelectSingleNode("/Params/IDNumber").Attributes["Value"].Value;
                cmdExec.Parameters.Add("@p_idtype", SqlDbType.TinyInt).Value = Convert.ToInt16(Params.SelectSingleNode("/Params/IDType").Attributes["Value"].Value);
                cmdExec.Parameters.Add("@p_issuingcountry", SqlDbType.SmallInt).Value = Convert.ToInt32(Params.SelectSingleNode("/Params/IDCountry").Attributes["Value"].Value);
                cmdExec.Parameters.Add("@p_firstname", SqlDbType.VarChar,45).Value = Params.SelectSingleNode("/Params/FirstName").Attributes["Value"].Value;
                cmdExec.Parameters.Add("@p_middlename", SqlDbType.VarChar, 45).Value = Params.SelectSingleNode("/Params/MiddleName").Attributes["Value"].Value;
                cmdExec.Parameters.Add("@p_surname1", SqlDbType.VarChar, 45).Value = Params.SelectSingleNode("/Params/SurName1").Attributes["Value"].Value;
                cmdExec.Parameters.Add("@p_surname2", SqlDbType.VarChar, 45).Value = Params.SelectSingleNode("/Params/SurName2").Attributes["Value"].Value;
                cmdExec.Parameters.Add("@p_suffix", SqlDbType.VarChar,5).Value = Params.SelectSingleNode("/Params/Suffix").Attributes["Value"].Value;
                cmdExec.Parameters.Add("@p_country", SqlDbType.SmallInt).Value = Convert.ToInt32(Params.SelectSingleNode("/Params/Country").Attributes["Value"].Value);
                cmdExec.Parameters.Add("@p_registrar", SqlDbType.SmallInt).Value = Convert.ToInt32(Params.SelectSingleNode("/Params/Registrar").Attributes["Value"].Value);
                cmdExec.Parameters.Add("@p_companyname", SqlDbType.VarChar,150).Value = Params.SelectSingleNode("/Params/CompanyName").Attributes["Value"].Value;
                cmdExec.Parameters.Add("@o_cust", SqlDbType.Int).Value = 0;
                cmdExec.Parameters.Add("@o_success", SqlDbType.Bit).Value = 0;
                cmdExec.Parameters.Add("@o_error", SqlDbType.VarChar,1000).Value = "";

                cmdExec.Parameters["@o_cust"].Direction = ParameterDirection.Output;
                cmdExec.Parameters["@o_success"].Direction = ParameterDirection.Output;
                cmdExec.Parameters["@o_error"].Direction = ParameterDirection.Output;

                //Values




                cmdExec.Connection.Open();
                cmdExec.ExecuteNonQuery();

                RespSuccess = cmdExec.Parameters["@o_success"].Value.ToString();
                RespError = cmdExec.Parameters["@o_error"].Value.ToString();
                RespIdCust = cmdExec.Parameters["@o_cust"].Value.ToString();


                //Say we got some values back
                if (
                    RespSuccess != null &&
                    RespError != null &&
                    RespIdCust != null
                    )
                {
                    sTErr.InnerText = RespError;
                    sTErr2.InnerText = RespError;
                    if (RespSuccess.ToLower() == "true" || RespSuccess.ToLower() == "false")
                    {
                        sTSucc.InnerText = RespSuccess;
                    }
                    Regex xp = new Regex(@"[0-9]+");
                    if (xp.IsMatch(RespIdCust))
                    {
                        Res.InnerText = RespIdCust;
                    }

                }
                
            }
            catch (Exception ex)
            {
                XmlCustomer.FirstChild.SelectSingleNode("IdBonus").InnerText = "0";
                XmlCustomer.FirstChild.SelectSingleNode("Error").InnerText = ex.Message;
                log.Error("Error Inserting Customer",ex);
            }
            finally
            {
                if (cmdExec.Connection != null)
                {
                    if (cmdExec.Connection.State != ConnectionState.Closed)
                    {
                        cmdExec.Connection.Close();
                    }
                }
            }

            return XmlCustomer;
        }

        [WebMethod]
        public DataSet CustomerGetDetails(int custID, int langid)
        {
            DataSet customerDS = new DataSet();
            MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbConnectionRAFMain"].ConnectionString;
                string sql1 = "CALL meta_customerGetDetails(?custid,?guiLang);";
                MySqlDataAdapter dadapter = new MySqlDataAdapter();
                dadapter.SelectCommand = new MySqlCommand(sql1, conn);
                dadapter.SelectCommand.Parameters.Add("?custid", MySqlDbType.UInt32).Value = custID;
                dadapter.SelectCommand.Parameters.Add("?guiLang", MySqlDbType.UInt32).Value = langid;
                dadapter.Fill(customerDS);
            }
            catch (Exception ex)
            {
                log.Error("Error Reading Customer Details", ex);
            }
            return customerDS;
        }

        [WebMethod]
        public DataSet CustomerGetAssets(int custID, int langid)
        {
            DataSet customerDS = new DataSet();
            MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbConnectionRAFMain"].ConnectionString;
                string sql1 = "CALL meta_customerGetAssets(?custid,?guiLang);";
                MySqlDataAdapter dadapter = new MySqlDataAdapter();
                dadapter.SelectCommand = new MySqlCommand(sql1, conn);
                dadapter.SelectCommand.Parameters.Add("?custid", MySqlDbType.UInt32).Value = custID;
                dadapter.SelectCommand.Parameters.Add("?guiLang", MySqlDbType.UInt32).Value = langid;
                dadapter.Fill(customerDS);
            }
            catch (Exception ex)
            {
                log.Error("Error Reading Customer Assets", ex);
            }
            return customerDS;
        }

        [WebMethod(CacheDuration = 3600)]
        public XmlDocument CustomerSearchParams()
        {

            XmlDocument XDoc = new XmlDocument();

            XDoc.LoadXml(@"
                <Params>
                  <Lang Value="""" DataType=""Int"" Length="""" Required=""false"" IfEmptyRequires="""" />
                  <Profile Value="""" DataType=""Int"" Length="""" Required=""false"" IfEmptyRequires="""" />  
                  <Password Value="""" DataType=""String"" Length=""45"" Required=""false"" IfEmptyRequires="""" />    
                  <IDNumber Value="""" DataType=""String"" Length=""128"" Required=""false"" IfEmptyRequires="""" />
                  <IDType Value="""" DataType=""Int"" Length="""" Required=""false"" IfEmptyRequires="""" />
                  <FirstName Value="""" DataType=""String"" Length=""45"" Required=""false"" IfEmptyRequires=""CompanyName"" />  
                  <SurName1 Value="""" DataType=""String"" Length=""45"" Required=""false"" IfEmptyRequires="""" />    
                  <SurName2 Value="""" DataType=""String"" Length=""45"" Required=""false"" IfEmptyRequires="""" />      
                  <CompanyName Value="""" DataType=""String"" Length=""150"" Required=""false"" IfEmptyRequires=""FirstName"" /> 
                </Params>");

            return XDoc;
        }
        
        [WebMethod]
        public DataSet CustomerSearchString(string xmlString)
        {
            XmlDocument XDoc = new XmlDocument();
            XDoc.LoadXml(string2XML(xmlString));
            return CustomerSearch(XDoc);
        }

        [WebMethod]
        public DataSet CustomerSearch(XmlDocument Params)
        {
            DataSet customersDS = new DataSet();
            SqlCommand cmdSelect = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            try
            {
                //Validate XmlData
                XmlDocument XDocValidate = new XmlDocument();
                XDocValidate.LoadXml(ValidateParamsXML(Params).InnerXml);

                //If Error, Return
                if (
                    (XDocValidate.FirstChild.SelectSingleNode("Error").Attributes["Value"] != null) &&
                    (XDocValidate.FirstChild.SelectSingleNode("Error").Attributes["Value"].Value != "")
                   )
                {
                    log.Error("Error Validating XML Params. RAFProxy.CustomerInsert()"
                        + Params.ToString()
                    );

                    return customersDS;
                }

                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbConnectionRAFMain"].ConnectionString;
                cmdSelect.Connection = conn;
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.CommandText = "meta_CustomerSearch";

                cmdSelect.Parameters.Add("@p_idtype", SqlDbType.Int);
                cmdSelect.Parameters.Add("@p_idnumber", SqlDbType.VarChar);
                cmdSelect.Parameters.Add("@p_firstname", SqlDbType.VarChar);
                cmdSelect.Parameters.Add("@p_surname1", SqlDbType.VarChar);
                cmdSelect.Parameters.Add("@p_surname2", SqlDbType.VarChar);
                cmdSelect.Parameters.Add("@p_companyname", SqlDbType.VarChar);
                cmdSelect.Parameters.Add("@p_language", SqlDbType.Int);
                cmdSelect.Parameters.Add("@p_idprofile", SqlDbType.Int);
                cmdSelect.Parameters.Add("@p_password", SqlDbType.VarChar);

                cmdSelect.Parameters["@p_idtype"].Value =
                    Params.SelectSingleNode("/Params/IDType").Attributes["Value"].Value == "" ? null : Params.SelectSingleNode("/Params/IDType").Attributes["Value"].Value;
                cmdSelect.Parameters["@p_idnumber"].Value =
                    Params.SelectSingleNode("/Params/IDNumber").Attributes["Value"].Value == "" ? null : Params.SelectSingleNode("/Params/IDNumber").Attributes["Value"].Value;
                cmdSelect.Parameters["@p_firstname"].Value =
                    Params.SelectSingleNode("/Params/FirstName").Attributes["Value"].Value == "" ? null : Params.SelectSingleNode("/Params/FirstName").Attributes["Value"].Value;
                cmdSelect.Parameters["@p_surname1"].Value =
                    Params.SelectSingleNode("/Params/SurName1").Attributes["Value"].Value == "" ? null : Params.SelectSingleNode("/Params/SurName1").Attributes["Value"].Value;
                cmdSelect.Parameters["@p_surname2"].Value =
                    Params.SelectSingleNode("/Params/SurName2").Attributes["Value"].Value == "" ? null : Params.SelectSingleNode("/Params/SurName2").Attributes["Value"].Value;
                cmdSelect.Parameters["@p_companyname"].Value =
                    Params.SelectSingleNode("/Params/CompanyName").Attributes["Value"].Value == "" ? null : Params.SelectSingleNode("/Params/CompanyName").Attributes["Value"].Value;
                cmdSelect.Parameters["@p_language"].Value =
                    Params.SelectSingleNode("/Params/Lang").Attributes["Value"].Value == "" ? null : Params.SelectSingleNode("/Params/Lang").Attributes["Value"].Value;
                cmdSelect.Parameters["@p_idprofile"].Value =
                    Params.SelectSingleNode("/Params/Profile").Attributes["Value"].Value == "" ? null : Params.SelectSingleNode("/Params/Profile").Attributes["Value"].Value;
                cmdSelect.Parameters["@p_password"].Value =
                    Params.SelectSingleNode("/Params/Password").Attributes["Value"].Value == "" ? null : Params.SelectSingleNode("/Params/Password").Attributes["Value"].Value;

                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                da.Fill(customersDS);
                conn.Close();
            }
            catch (Exception ex)
            {
                log.Error("Error Searching for Customers", ex);
            }
            return customersDS;
        }


        [WebMethod(CacheDuration = 3600)]
        public XmlDocument AssetInsertParams()
        {

            XmlDocument XDoc = new XmlDocument();

            XDoc.LoadXml(@"
                <Params>
                  <CustID Value="""" DataType=""Int"" Length="""" Required=""true"" IfEmptyRequires="""" />
                  <IDNumber Value="""" DataType=""String"" Length=""128"" Required=""true"" IfEmptyRequires="""" />
                  <IDType Value="""" DataType=""Int"" Length="""" Required=""true"" IfEmptyRequires="""" />
                </Params>");

            return XDoc;
        }
        [WebMethod]
        public string AssetInsertString(string xmlString)
        {
            XmlDocument XDoc = new XmlDocument();
            XDoc.LoadXml(string2XML(xmlString));
            return AssetInsert(XDoc).OuterXml;
        }
        [WebMethod]
        public XmlDocument AssetInsert(XmlDocument Params)
        {

            // Doc for return
            XmlDocument XmlAsset = new XmlDocument();

            XmlNode root = XmlAsset.AppendChild(XmlAsset.CreateNode(XmlNodeType.Element, "AssetInsert", ""));

            XmlNode sT = root.AppendChild(XmlAsset.CreateNode(XmlNodeType.Element, "Status", ""));
            XmlNode sTSucc = sT.AppendChild(XmlAsset.CreateNode(XmlNodeType.Element, "Success", ""));
            sTSucc.InnerText = "false";
            XmlNode sTErr = sT.AppendChild(XmlAsset.CreateNode(XmlNodeType.Element, "ErrMsg", ""));
            XmlNode sTErr2 = sT.AppendChild(XmlAsset.CreateNode(XmlNodeType.Element, "IntErrMsg", ""));

            XmlNode Res = root.AppendChild(XmlAsset.CreateNode(XmlNodeType.Element, "AssetID", ""));
            Res.InnerText = "0";

            SqlCommand cmdExec = new SqlCommand();
            SqlConnection conn = new SqlConnection();

            try
            {
                //Validate XmlData
                XmlDocument XDocValidate = new XmlDocument();
                XDocValidate.LoadXml(ValidateParamsXML(Params).InnerXml);

                //If Error, Return
                if (
                    (XDocValidate.FirstChild.SelectSingleNode("Error").Attributes["Value"] != null) &&
                    (XDocValidate.FirstChild.SelectSingleNode("Error").Attributes["Value"].Value != "")
                   )
                {
                    sTErr2.InnerText = XDocValidate.FirstChild.SelectSingleNode("Error").Attributes["Value"].Value;
                    //IfError
                    log.Error("Error Validating XML Params. RAFProxy.AssetInsert()"
                        + Params.ToString()
                    );

                    return XmlAsset;
                }


                /*************************/
                // DB
                /*************************/

                int RespIdAsset;
                string RespError = null;
                string RespSuccess = null;

                string storedNumber = null;
                string displayMask = null;
                int assetType = 0;
                bool result = Int32.TryParse(Params.SelectSingleNode("/Params/IDType").Attributes["Value"].Value, out assetType);

                storedNumber = RAFCommon.Assets.AssetGenStoredAssetNum(assetType, Params.SelectSingleNode("/Params/IDNumber").Attributes["Value"].Value);
                displayMask = RAFCommon.Assets.AssetGenDisplayMask(assetType, Params.SelectSingleNode("/Params/IDNumber").Attributes["Value"].Value);


                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbConnectionRAFMain"].ConnectionString;
                cmdExec.Connection = conn;
                cmdExec.CommandType = CommandType.StoredProcedure;
                cmdExec.CommandText = "meta_assetInsertNew";

                cmdExec.Parameters.Add("@customer", SqlDbType.Int).Value = Params.SelectSingleNode("/Params/CustID").Attributes["Value"].Value;
                cmdExec.Parameters.Add("@type", SqlDbType.SmallInt).Value = Params.SelectSingleNode("/Params/IDType").Attributes["Value"].Value;
                cmdExec.Parameters.Add("@idnumber", SqlDbType.VarChar, 255).Value = storedNumber;
                cmdExec.Parameters.Add("@displaymask", SqlDbType.VarChar, 50).Value = displayMask;
                cmdExec.Parameters.Add("@issueent", SqlDbType.Int).Value = 1;
                cmdExec.Parameters.Add("@assetNum", SqlDbType.Int);
                cmdExec.Parameters["@assetNum"].Direction = ParameterDirection.Output;

                cmdExec.Connection.Open();
                cmdExec.ExecuteNonQuery();
                cmdExec.Connection.Close();
 
                //Say we got some values back
                bool result2 = Int32.TryParse(cmdExec.Parameters["@assetNum"].Value.ToString(), out RespIdAsset);


                if (result2)
                {
                    Res.InnerText = RespIdAsset.ToString();
                    sTSucc.InnerText = "true";
                }

            }
            catch (Exception ex)
            {
                XmlAsset.FirstChild.SelectSingleNode("Error").InnerText = ex.Message;
                log.Error("Error Inserting Customer", ex);
            }

            return XmlAsset;
        }


        [WebMethod]
        public string CustomerIDGetMask(Int32 country, Int16 idtype)
        {
            string mask = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            SqlCommand cmdSelect = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            try
            {

                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbConnectionRAFMain"].ConnectionString;
                cmdSelect.Connection = conn;
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.CommandText = "meta_customerIDsGetMaskByCountry";

                cmdSelect.Parameters.Add("@idcountry", SqlDbType.SmallInt).Value = country;
                cmdSelect.Parameters.Add("@idtype", SqlDbType.TinyInt).Value = idtype;
                cmdSelect.Parameters.Add("@mask", SqlDbType.VarChar,50);

                cmdSelect.Parameters["@mask"].Direction = ParameterDirection.Output;

                conn.Open();
                cmdSelect.ExecuteNonQuery();
                conn.Close();
                if (cmdSelect.Parameters["@mask"].Value != null)
                {
                    mask = cmdSelect.Parameters["@mask"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error Searching for Customers", ex);
            }
            return mask;
        }


        [WebMethod]
        public bool testDBCnx()
        {
            bool cnx = false;
            //Check DB Access
            MySqlConnection mysqlCon = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["dbConnectionRAFSecurity"].ConnectionString);
            try
            {
                mysqlCon.Open();
                mysqlCon.Close();
                cnx = true;
            }
            catch (Exception ex)
            {
                log.Fatal("No se puede connectar a base de datos de usuarios.", ex);
            }
            return cnx;
        }

        /***************************************************************/

        private XmlDocument ValidateParamsXML(XmlDocument InputXml)
        {
            XmlDocument XDocValidate = new XmlDocument();
            XmlNode root = XDocValidate.CreateNode(XmlNodeType.Element, "ValidateXML", "");
            XDocValidate.AppendChild(root);
            root.AppendChild(XDocValidate.CreateNode(XmlNodeType.Element, "Valid", ""));
            root.AppendChild(XDocValidate.CreateNode(XmlNodeType.Element, "Error", ""));

            root.SelectSingleNode("Valid").Attributes.SetNamedItem(XDocValidate.CreateNode(XmlNodeType.Attribute, "Value", "")).Value = "";
            root.SelectSingleNode("Error").Attributes.SetNamedItem(XDocValidate.CreateNode(XmlNodeType.Attribute, "Value", "")).Value = "";

            foreach (XmlNode node in InputXml.FirstChild.ChildNodes)
            {
                //Check Empties
                if (
                    (node.Attributes["Required"].Value.ToLower() == "true") &&
                    ((node.Attributes["Value"].Value == null) || (node.Attributes["Value"].Value == ""))
                    )
                {
                    XDocValidate.FirstChild.SelectSingleNode("Valid").Attributes["Value"].Value = "false";
                    XDocValidate.FirstChild.SelectSingleNode("Error").Attributes["Value"].Value = node.Name + " is Required.";
                    break;
                }

                //Check Varchar Lengths
                if (
                    (node.Attributes["DataType"].Value.ToLower() == "varchar") &&
                    (node.Attributes["Value"].Value != null)
                    )
                {
                    if (
                        node.Attributes["Value"].Value.Length >
                        Convert.ToInt32(node.Attributes["Length"].Value)
                        )
                    {
                        XDocValidate.FirstChild.SelectSingleNode("Valid").Attributes["Value"].Value = "false";
                        XDocValidate.FirstChild.SelectSingleNode("Error").Attributes["Value"].Value = node.Name + " is longer than " + node.Attributes["Length"].Value + "characters.";
                        break;
                    }
                }
                //Check Int values
                if (
                    (node.Attributes["DataType"].Value.ToLower() == "int") &&
                    (node.Attributes["Value"].Value != null) &&
                    (node.Attributes["Required"].Value.ToLower() == "true")
                    )
                {
                    int num;
                    bool isInt = Int32.TryParse(node.Attributes["Value"].Value, out num);
                    if (isInt == false)
                    {
                        XDocValidate.FirstChild.SelectSingleNode("Valid").Attributes["Value"].Value = "false";
                        XDocValidate.FirstChild.SelectSingleNode("Error").Attributes["Value"].Value = node.Name + " is not an int.";
                        break;
                    }
                }


            }

            return XDocValidate;
        }

        [WebMethod(CacheDuration = 3600)]
        public XmlDocument guiGetFieldsByLanguage(int languageID, string registrarID, string registrarKey)
        {

            XmlDocument XDoc = new XmlDocument();
            try
            {
                XDoc.Load( Server.MapPath("xml\\guiFields.xml"));
            }
            catch (Exception x)
            {
                x.Message.Trim();
            }
            
            return XDoc;
        }
    }
}
