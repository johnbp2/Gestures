using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Cypher
{
    public static class Base64Url
    {
        public static string Encode(string text)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(text)).TrimEnd('=').Replace('+', '-')
                .Replace('/', '_');
        }

        public static string Decode(string text)
        {
            text = text.Replace('_', '/').Replace('-', '+');
            switch (text.Length % 4)
            {
                case 2:
                    text += "==";
                    break;
                case 3:
                    text += "=";
                    break;
            }
            return Encoding.UTF8.GetString(Convert.FromBase64String(text));
        }
    }   
}
