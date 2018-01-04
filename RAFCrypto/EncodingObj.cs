using System;

namespace RAFCrypto
{
    /// <summary>
    /// Summary description for EncodingObj
    /// </summary>
    public class EncodingObj
    {
        public byte[] GetBytes(string Message, string EncType)
        {
            byte[] array = null;
            try
            {
                if (EncType == "UTF8")
                {
                    System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
                    array = enc.GetBytes(Message);
                }
                if (EncType == "ASCII")
                {
                    System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
                    array = enc.GetBytes(Message);
                }
            }
            catch (Exception ex)
            {
                ex.Message.Trim();
            }
            return array;
        }


        public string GetString(byte[] Message, string EncType)
        {
            string result = null;
            try
            {
                if (EncType == "UTF8")
                {
                    System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
                    result = enc.GetString(Message);
                }
                if (EncType == "ASCII")
                {
                    System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
                    result = enc.GetString(Message);
                }
            }
            catch (Exception ex)
            {
                ex.Message.Trim();
            }
            return result;
        }

    }
}