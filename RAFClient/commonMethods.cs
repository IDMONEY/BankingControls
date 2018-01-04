using System;
using System.Collections.Generic;
using System.Text;

namespace RAFClient
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

        public int insertLog()
        {
            int entry;
            entry = 0;
            return entry;
        }
    }
}
