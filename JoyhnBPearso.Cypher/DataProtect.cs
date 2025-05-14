using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Cypher
{
    public class DataProtect
    {

        public byte[] Encrypt(string plainText)
        {
            ///////////////////////////////
            //
            // Memory Encryption - ProtectedMemory
            //
            ///////////////////////////////

            // Create the original data to be encrypted (The data length should be a multiple of 16).
            byte[] toEncrypt = UnicodeEncoding.ASCII.GetBytes(plainText);

            // Add padding of needed
            byte[] paddedToEncryt = DataProtectionService.pad(toEncrypt);
            // Console.WriteLine($"Original data: {UnicodeEncoding.ASCII.GetString(paddedToEncryt)}");9
          // Logger.logToConsole($"Original data: {UnicodeEncoding.ASCII.GetString(paddedToEncryt)}");
            // Console.WriteLine("Encrypting...");
          //  Logger.logToConsole("Encrypting...");
            // Encrypt the data in memory.
            DataProtectionService.EncryptInMemoryData(paddedToEncryt, MemoryProtectionScope.SameLogon);
            string result = UnicodeEncoding.ASCII.GetString(paddedToEncryt);
          //  Console.WriteLine($"Encrypted data: {result}");
            // System.Windows.Clipboard.SetText( result );
            return paddedToEncryt;
        }

        public string Encrypt(string plainText, bool consoleOutput = true)
        {
            ///////////////////////////////
            //
            // Memory Encryption - ProtectedMemory
            //
            ///////////////////////////////

            // Create the original data to be encrypted (The data length should be a multiple of 16).
            byte[] toEncrypt = UnicodeEncoding.ASCII.GetBytes(plainText);

            // Add padding of needed
            byte[] paddedToEncryt = DataProtectionService.pad(toEncrypt);
            // Console.WriteLine($"Original data: {UnicodeEncoding.ASCII.GetString(paddedToEncryt)}");9
            Logger.logToConsole($"Original data: {UnicodeEncoding.ASCII.GetString(paddedToEncryt)}");
            // Console.WriteLine("Encrypting...");
            Logger.logToConsole("Encrypting...");
            // Encrypt the data in memory.
            DataProtectionService.EncryptInMemoryData(paddedToEncryt, MemoryProtectionScope.SameLogon);
            string result = UnicodeEncoding.ASCII.GetString(paddedToEncryt);
            Console.WriteLine($"Encrypted data: {result}");
            // System.Windows.Clipboard.SetText( result );
            return result;
        }

        public string Decrypt(string encryptedText)
        {
            byte[] bytes = UnicodeEncoding.ASCII.GetBytes(encryptedText);
            DataProtectionService.DecryptInMemoryData(bytes, MemoryProtectionScope.SameLogon);
            string result = UnicodeEncoding.ASCII.GetString(bytes);
            //Console.WriteLine($"Decrypted data: {result}");
            Logger.logToConsole($"Decrypted data: {result}", true);
            return result;

        }

        public int encryptToFile(string plainText, DirectoryInfo path, string fileName, bool consoleOutput = true)
        {

            // Create the original data to be encrypted
            byte[] toEncrypt = UnicodeEncoding.ASCII.GetBytes(plainText);

            // Create a file.
            
            FileStream fStream = new FileStream(System.IO.Path.Combine(path.FullName, fileName), FileMode.OpenOrCreate);

            if(consoleOutput)
            {
                Logger.logToConsole("");
                Logger.logToConsole($"Original data: {UnicodeEncoding.ASCII.GetString(toEncrypt)}");
                Logger.logToConsole("Encrypting and writing to disk...");
            }
            // Encrypt a copy of the data to the stream.
            int bytesWritten = DataProtectionService.EncryptDataToStream(toEncrypt, DataProtectionScope.CurrentUser, fStream);

            fStream.Close();
            return bytesWritten;

        }

        public string decryptFromFile(FileInfo file,int length, bool consoleOutput = true)
        {
            Console.WriteLine("Reading data from disk and decrypting...");

            // Open the file.
          var  fStream = new FileStream(file.FullName, FileMode.Open);
            using(fStream) {
                // Read from the stream and decrypt the data.
                byte[] decryptData = DataProtectionService.DecryptDataFromStream(DataProtectionScope.CurrentUser, fStream, length);
                fStream.Close();
                var result = UnicodeEncoding.ASCII.GetString(decryptData);
                if(consoleOutput)
                {
                    Console.WriteLine($"Decrypted data: {result}");
                }

                return result ;
               
            }
        }

        public string bytesToString(byte[] bytes)
        {
            string bytesString = "";
            foreach(byte b in bytes)
            {
                bytesString += b.ToString() + ",";
            }
            return bytesString;
        }

    }
}
