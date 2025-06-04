using System;
using System.Text;

namespace JohnBPearson.Application.Gestures.Model.Utility
{
    public class ByteHexHelper
    {




        public static string ToHexString(byte[] bytes)
        {
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach(byte b in bytes)
            {
                hex.AppendFormat("{0:X2}", b);
            }
            return hex.ToString();
        }

        public static string ToHexString2(byte[] bytes)
        {
            return string.Join("", Array.ConvertAll(bytes, b => b.ToString("X2")));
        }

        public static string ToHexString3(byte[] bytes)
        {
            string hex = BitConverter.ToString(bytes);
            return hex.Replace("-", "");
        }
    
}
}
