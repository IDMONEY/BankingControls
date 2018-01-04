using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;



/// <summary>
/// Summary description for TripleDES
/// </summary>
/// 
namespace RAFCrypto
{
    public class TripleDES
    {
        public static string EncryptString(string Message, EncSettings settings)
        {

            byte[] Results;
            string ResultsString = "";

            EncodingObj enc = new EncodingObj();

            byte[] keyHex = Common.HexStringToByteArray(settings.Key);

            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Setup the encoder
            TDESAlgorithm.Mode = StringToEnum<CipherMode>(settings.ChiperMode);
            TDESAlgorithm.Key = keyHex;
            TDESAlgorithm.Padding = StringToEnum<PaddingMode>(settings.PaddingMode);
            TDESAlgorithm.IV = settings.IVector;

            // Convert the input string to a byte[]
            byte[] DataToEncrypt = enc.GetBytes(Message, settings.Encoding);

            // Attempt to encrypt the string
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);

                ResultsString = Common.ByteArrayToHexString(Results);
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
            }
            catch (Exception ex)
            {
                ex.Message.Trim();
            }
            return ResultsString;
        }

        public static string DecryptString(string Message, EncSettings settings)
        {
            byte[] Results;
            string ResultsString = "";

            EncodingObj enc = new EncodingObj();

            byte[] keyHex = Common.HexStringToByteArray(settings.Key);

            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Setup the decoder
            TDESAlgorithm.Mode = StringToEnum<CipherMode>(settings.ChiperMode);
            TDESAlgorithm.Key = keyHex;
            TDESAlgorithm.Padding = StringToEnum<PaddingMode>(settings.PaddingMode);
            TDESAlgorithm.IV = settings.IVector;

            // Convert the input string to a byte[]
            byte[] DataToDecrypt = Common.HexStringToByteArray(Message);

            // Attempt to decrypt the string
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
                // Convert the decrypted string to UTF8 format
                ResultsString = enc.GetString(Results, settings.Encoding);
                // Clear the TripleDes services of any sensitive information
                TDESAlgorithm.Clear();
            }
            catch (Exception ex)
            {
                ex.Message.Trim();
            }
            return ResultsString;
        }


        //public static string encBadKey()
        //{
        //    TripleDES tripleDESalg = TripleDES.Create();
        //    byte[] EmptyKey = new byte[0x18];
        //    byte[] EmptyIV = new byte[8];
        //    TripleDESCryptoServiceProvider sm = tripleDESalg as TripleDESCryptoServiceProvider;
        //    MethodInfo mi = sm.GetType().GetMethod("_NewEncryptor", BindingFlags.NonPublic | BindingFlags.Instance);
        //    object[] Par = { EmptyKey, sm.Mode, IV, sm.FeedbackSize, 0 };
        //    ICryptoTransform trans = mi.Invoke(sm, Par) as ICryptoTransform;

        
        //}


            private static byte[] ToByteArray(String HexString)
            {

                if (HexString.Length % 2 != 0) throw new ArgumentException("Hex string is of odd length");
                Regex re = new Regex(@"[^0-9A-Fa-f]");
                if (re.IsMatch(HexString)) throw new ArgumentException("Hex string contains invalid characters");

                int NumberChars = HexString.Length;
                byte[] bytes = new byte[NumberChars / 2];
                for (int i = 0; i < NumberChars; i += 2)
                {
                  bytes[i / 2] = Convert.ToByte(HexString.Substring(i, 2), 16);
                }
                return bytes;
            }

            public static T StringToEnum<T>(string name)
            {
                return (T)Enum.Parse(typeof(T), name);
            }

            public static string GetMD5Hash(string input)
            {
                System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
                bs = x.ComputeHash(bs);
                System.Text.StringBuilder s = new System.Text.StringBuilder();
                foreach (byte b in bs)
                {
                    s.Append(b.ToString("x2").ToLower());
                }
                return s.ToString();
            }

            public static string GetSha1(string input)
            {

                System.Security.Cryptography.SHA1CryptoServiceProvider x = new System.Security.Cryptography.SHA1CryptoServiceProvider();
                byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
                bs = x.ComputeHash(bs);
                System.Text.StringBuilder s = new System.Text.StringBuilder();
                foreach (byte b in bs)
                {
                    s.Append(b.ToString("x2").ToLower());
                }
                return s.ToString();
            }
            public static string GetHex(string input)
            {
                StringBuilder sb = new StringBuilder();
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                foreach (byte b in inputBytes)
                {
                    sb.Append(string.Format("{0:x2}", b));
                }

                return sb.ToString();
            }
            //public static string GetHex(string Data)
            //{
            //    Data = Data.Substring(0, 8);

            //    string Data1 = "";

            //    string sData = "";

            //    while (Data.Length > 0)

            //    //first take two hex value using substring.

            //    //then convert Hex value into ascii.

            //    //then convert ascii value into character.
            //    {
            //        Data1 = System.Convert.ToChar(System.Convert.ToUInt32(Data.Substring(0, 2), 16)).ToString();

            //        sData = sData + Data1;

            //        Data = Data.Substring(2, Data.Length - 2);

            //    }
            //    return sData;
            //}



    }
}