using System;
using System.Collections.Generic;

namespace RAFCrypto
{
    /// <summary>
    /// Summary description for RAFCommon
    /// </summary>
    public class Common
    {
        public Common()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //public static byte[] HexByte(string str, int offset, int step, int tail)
        //{
        //    byte[] b = new byte[(str.Length - offset - tail) / 2];
        //    byte c1, c2;
        //    int l = str.Length - tail;
        //    int s = step + 1;
        //    for (int y = 0, x = offset; x < l; ++y, x += s)
        //    {
        //        c1 = (byte)str[x];
        //        if (c1 > 0x60) c1 -= 0x57;
        //        else if (c1 > 0x40) c1 -= 0x37;
        //        else c1 -= 0x30;
        //        c2 = (byte)str[++x];
        //        if (c2 > 0x60) c2 -= 0x57;
        //        else if (c2 > 0x40) c2 -= 0x37;
        //        else c2 -= 0x30;
        //        b[y] = (byte)((c1 << 4) + c2);
        //    }
        //    return b;
        //}


        public static byte[] HexByte(string str)
        {
            byte[] b = new byte[(str.Length) / 2];
            byte c1, c2;
            int l = str.Length;
            int s = 0;
            for (int y = 0, x = 0; x < l; ++y, x += s)
            {
                c1 = (byte)str[x];
                if (c1 > 0x60) c1 -= 0x57;
                else if (c1 > 0x40) c1 -= 0x37;
                else c1 -= 0x30;
                c2 = (byte)str[++x];
                if (c2 > 0x60) c2 -= 0x57;
                else if (c2 > 0x40) c2 -= 0x37;
                else c2 -= 0x30;
                b[y] = (byte)((c1 << 4) + c2);
            }
            return b;
        }


        //Converts a byte array into a valid hex string
        public static string HexStr(byte[] data)
        {
            char[] lookup = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            int i = 0, p = 2, l = data.Length;
            char[] c = new char[l * 2 + 2];
            byte d; c[0] = '0'; c[1] = 'x';
            while (i < l)
            {
                d = data[i++];
                c[p++] = lookup[d / 0x10];
                c[p++] = lookup[d % 0x10];
            }
            return new string(c, 0, c.Length);
        }


        public static string HexStringToAscii(string hexString)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i <= hexString.Length - 2; i += 2)
            {
                sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(hexString.Substring(i, 2), System.Globalization.NumberStyles.HexNumber))));
            }
            return sb.ToString();
        }

        static int ParseHexDigit(char c)
        {
            if (c >= '0' && c <= '9')
            {
                return c - '0';
            }
            if (c >= 'a' && c <= 'f')
            {
                return c - 'a' + 10;
            }
            if (c >= 'A' && c <= 'F')
            {
                return c - 'A' + 10;
            }
            throw new ArgumentException("Invalid hex character");
        }

        public static string ParseHex(string hex)
        {
            char[] result = new char[hex.Length / 2];

            int hexIndex = 0;
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (char)(ParseHexDigit(hex[hexIndex++]) * 16 +
                ParseHexDigit(hex[hexIndex++]));
            }
            return new string(result);
        }
        /*ok*/
        public static string ByteArrayToHexString(byte[] barray)
        {
            char[] c = new char[barray.Length * 2];
            byte b;
            for (int i = 0; i < barray.Length; ++i)
            {
                b = ((byte)(barray[i] >> 4));
                c[i * 2] = (char)(b > 9 ? b + 0x37 : b + 0x30);
                b = ((byte)(barray[i] & 0xF));
                c[i * 2 + 1] = (char)(b > 9 ? b + 0x37 : b + 0x30);
            }

            return new string(c);
        }
        /*ok*/
        public static byte[] HexStringToByteArray(string hexString)
        {
            hexString = hexString.ToUpper();
            int hexStringLength = hexString.Length;
            byte[] b = new byte[hexStringLength / 2];
            for (int i = 0; i < hexStringLength; i += 2)
            {
                int topChar = (hexString[i] > 0x40 ? hexString[i] - 0x37 : hexString[i] - 0x30) << 4;
                int bottomChar = hexString[i + 1] > 0x40 ? hexString[i + 1] - 0x37 : hexString[i + 1] - 0x30;
                b[i / 2] = Convert.ToByte(topChar + bottomChar);
            }
            return b;
        }



        //////////////////////////////////////////////

        public static string GetMD5(string assetNum)
        {
            // step 1, calculate MD5 hash from input
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(assetNum);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}