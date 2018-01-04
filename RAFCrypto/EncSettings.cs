using System;
using System.Collections.Generic;

namespace RAFCrypto
{
    /// <summary>
    /// A vendor`s settings for encription
    /// </summary>
    public class EncSettings
    {
        public string ChiperMode = "CBC";
        public string PaddingMode = "ANSIX923";
        public string Encoding = "UTF8";


        private string fullKey = "0123456789ABCDEFFEDCBA987654321089ABCDEF01234567";
        private byte[] vector = new byte[0];

        private string vectorString = "        ";

        public string Key
        {
            get
            {
                return fullKey;
            }
            set
            {
                fullKey = value;
            }
        }

        public byte[] IVector
        {
            get
            {
                if (vector.Length == 0)
                {
                    //Get IV from string
                    if (vectorString.Length > 0)
                    {
                        EncodingObj enc = new EncodingObj();
                        vector = enc.GetBytes(vectorString, Encoding);
                    }
                    return vector;
                }
                else { return vector; }
            }
            set
            {
                vector = value;
            }
        }


        public EncSettings()
        {

        }

        private enum CipherModeValues
        {
            CBC = 1,
            ECB = 2,
            OFB = 3,
            CFB = 4,
            CTS = 5,
        }

        private enum PaddingModeValues
        {
            None = 1,
            PKCS7 = 2,
            Zeros = 3,
            ANSIX923 = 4,
            ISO10126 = 5,
        }

        private enum EncodingValues
        {
            ASCII = 1,
            UTF8 = 2
        }


    }
}