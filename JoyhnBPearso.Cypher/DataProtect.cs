using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Cypher
{
    public class DataProtect
    {

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
            DataProtectionService.logToConsole($"Original data: {UnicodeEncoding.ASCII.GetString(paddedToEncryt)}");
            // Console.WriteLine("Encrypting...");
            DataProtectionService.logToConsole("Encrypting...");
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
            DataProtectionService.logToConsole($"Decrypted data: {result}", true);
            return result;

        }

    }
}
