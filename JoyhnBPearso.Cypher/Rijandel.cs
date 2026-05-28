using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace JohnBPearson.Cypher
{
    
    public class Rijandel
    {
        private const string password = "123456789ABCDEFG!@#$%^&*()_+";

        private static byte[] getInitVecrorBytes()
        {
            var initVector = "HR$2pIjHR$2pIj12HR$2pIjHR$2pIj12";
            Byte[] iv = new byte[32];
            Encoding.Default.GetBytes(initVector).CopyTo(iv, 0);
            return iv;
        }

        public static void Encrypt(string filePath)
        {
            var fileToEncrypt = filePath;
          //  var password = Rijandel.password;



            Byte[] key = new byte[31];
            Encoding.Default.GetBytes(password).CopyTo(key, 0);
            var aes = new RijndaelManaged() { Mode = CipherMode.CBC, KeySize = 256, BlockSize = 256, Padding = PaddingMode.Zeros };


            var mnemonicData = new MemoryStream();
            using(mnemonicData)
            {
                using(CryptoStream cStream = new CryptoStream(mnemonicData, aes.CreateEncryptor(key, getInitVecrorBytes()), CryptoStreamMode.Write))
                {
                    var buffer = File.ReadAllBytes(fileToEncrypt);
                    cStream.Write(buffer, 0, buffer.Length);
                    var appendBuffer = mnemonicData.ToArray();
                    var finalBuffer = new Byte[appendBuffer.Length];
                    appendBuffer.CopyTo(finalBuffer, 0);
                    File.WriteAllBytes(fileToEncrypt, finalBuffer);

                }
            }
        }

        public static string Decrypt(string filePath)
        {
            var fileToDecrypt = filePath;// textBox1.Text.Replace(".json", ".dat");
           // var password = Rijandel.password;
            Byte[] key = new byte[31];
            Encoding.Default.GetBytes(password).CopyTo(key, 0);
            var aes = new RijndaelManaged() { Mode = CipherMode.CBC, KeySize = 256, BlockSize = 256, Padding = PaddingMode.Zeros };


            var mnemonicData = new MemoryStream();
            using(mnemonicData)
            {
                using(CryptoStream cStream = new CryptoStream(mnemonicData, aes.CreateDecryptor(key, getInitVecrorBytes()), CryptoStreamMode.Write))
                {
                    var buffer = File.ReadAllBytes(fileToDecrypt);
                    cStream.Write(buffer, 0, buffer.Length);
                  
                    var appendBuffer = mnemonicData.ToArray();
                    var finalBuffer = new Byte[appendBuffer.Length];
                    appendBuffer.CopyTo(finalBuffer, 0);
                    var resut = Encoding.Default.GetString(finalBuffer);
                    
                    File.WriteAllBytes(fileToDecrypt, finalBuffer);
                    return resut;

                }
            }
        }
    }
}
