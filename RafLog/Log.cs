using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace RafLog
{
    public class Log
    {
        public static void LogToFile(string Message)
        {
            bool useLog = doUseLog();
            string logLoc = "";
            if (useLog)
            {
                //try
                //{                
                    logLoc = getLogFileName();
                    if (logLoc != "")
                    {
                        string fileName = logLoc + DateTime.Now.ToString("yyyyMMdd") + "_log.txt";
     
                        //Create the file myself if it doesnt exist
                        // cant trust the .net or mono implementation to 
                        // create the file on File.AppendText()
                        //try
                        //{
                            //if (!System.IO.File.Exists(fileName))
                            //{
                            //    System.IO.File.Create(fileName);
                            //    System.IO.File.
                            //}
                        //}
                        //catch (System.IO.IOException e)
                        //{
                        //    e.Message.Trim();
                        //}

                        TextWriter tw = File.AppendText(fileName);
                        tw.WriteLine(DateTime.Now.ToShortTimeString() + ": " + Message);
                        tw.Close();
                    }
                //}
                //catch (Exception ex)
                //{
                //    ex.Message.Trim();
                //}
            }
        }

        public static void LogToSOAPFile(string Message)
        {
            bool useLog = doUseLog();
            if (useLog)
            {
                string logLoc = "";
                logLoc = getLogFileName();
                if (logLoc != "")
                {
                    TextWriter tw = File.AppendText(logLoc + DateTime.Now.ToString("yyyyMMdd") + "_log.txt");
                    tw.WriteLine(DateTime.Now.ToShortTimeString() + ": " + Message);
                    tw.Close();
                }
            }
        }
        public static bool doUseLog()
        {
            bool logFileUse = true;
            //Use the log file?
            string useLogString = ConfigurationManager.AppSettings.Get("logFileUse");
            if ((useLogString != null) && ((useLogString == "true") || (useLogString == "false")))
            {
                logFileUse = Convert.ToBoolean(useLogString);
            }
            return logFileUse;
        }

        public static string getLogFileName()
        {
            string logLoc = "";
            string logLocString = ConfigurationManager.AppSettings.Get("logFileLocation");
            if (logLocString != null)
            {
                logLoc = logLocString;
            }
            return logLoc;
        }

        public static string getSOAPLogFileName()
        {
            string logLoc = "";
            string logLocString = ConfigurationManager.AppSettings.Get("logSOAPFileLocation");
            if (logLocString != null)
            {
                logLoc = logLocString;
            }
            return logLoc;
        }

        public static bool doUseSOAPLog()
        {
            bool logFileUse = true;
            //Use the log file?
            string useLogString = ConfigurationManager.AppSettings.Get("logSOAPFileUse");
            if ((useLogString != null) && ((useLogString == "true") || (useLogString == "false")))
            {
                logFileUse = Convert.ToBoolean(useLogString);
            }
            return logFileUse;
        }


        public static void LogToDB(string className, Exception ex)
        {
            LogToDB(className, 'E',"Exception","","",ex.Message);
        }

        
        public static void LogToDB(string className, char logType, string keyname, string value, string param, string result)
        {
            SqlCommand cmdExec = new SqlCommand();
            SqlConnection conn = new SqlConnection();

            try
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["rafLogConnectionString"].ConnectionString;
                cmdExec.Connection = conn;
                cmdExec.CommandType = CommandType.StoredProcedure;
                cmdExec.CommandText = "dbo.LogInsert";

                cmdExec.Parameters.Add("@class", SqlDbType.VarChar).Value = className;
                cmdExec.Parameters.Add("@type", SqlDbType.VarChar).Value = logType;
                cmdExec.Parameters.Add("@keyname", SqlDbType.VarChar).Value = keyname;
                cmdExec.Parameters.Add("@value", SqlDbType.VarChar).Value = value;
                cmdExec.Parameters.Add("@params", SqlDbType.VarChar).Value = param;
                cmdExec.Parameters.Add("@result", SqlDbType.VarChar).Value = result;

                cmdExec.Connection.Open();
                cmdExec.ExecuteNonQuery();
                cmdExec.Connection.Close();
            }
            catch (Exception x)
            {
                LogToFile(x.Message);
            }
        }


////////
    }
}
