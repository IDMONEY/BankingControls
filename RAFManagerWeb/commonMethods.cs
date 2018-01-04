using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Data;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace RAFClientDemo
{
    class commonMethods
    {
        public static string GetSetting(string Setting, string Default)
        {
            string value = "";
            try
            {
                if (System.Configuration.ConfigurationManager.AppSettings[Setting] != null)
                {
                    value = System.Configuration.ConfigurationManager.AppSettings[Setting];
                }
                if (value == "")
                {
                    value = Default;
                }
            }
            catch (Exception ex)
            {
                value = Default;
            }
            return value;
        }

        //public static DataTable getGuiDSData(string node)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        XmlNode selFields = MDIParent1.guiFieldsXml.SelectSingleNode("/guiFields/" + node);
        //        using (XmlNodeReader xnr = new XmlNodeReader(selFields))
        //        {
        //            ds.ReadXml(xnr);
        //        }
        //        DataRow emptyRow = ds.Tables[0].NewRow(); ;
        //        ds.Tables[0].Rows.InsertAt(emptyRow, 0);

        //    }
        //    catch (Exception x)
        //    {
        //        DataTable dt = new DataTable("fields");
        //        ds.Tables.Add(dt); 
               
        //        x.Message.Trim();
        //    }
        //    return ds.Tables[0];
        //}

        //bool isLuhnValid(string s)
        //{
        //    return s.Reverse().SelectMany((c, i) => ((c - '0') << (i & 1)).ToString()).Sum(c => (c - '0')) % 10 == 0;
        //}


        public int insertLog()
        {
            int entry;
            entry = 0;
            return entry;
        }
    }
}
