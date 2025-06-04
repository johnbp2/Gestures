using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Web;

internal class DataProtectionService
{

    internal static string Encrypt(string plainText, bool consoleOutput = true)
    {
        ///////////////////////////////
        //
        // Memory Encryption - ProtectedMemory
        //
        ///////////////////////////////

        // Create the original data to be encrypted (The data length should be a multiple of 16).
        byte[] toEncrypt = UnicodeEncoding.ASCII.GetBytes(plainText);

        // Add padding of needed
        byte[] paddedToEncryt = pad(toEncrypt);
        // Console.WriteLine($"Original data: {UnicodeEncoding.ASCII.GetString(paddedToEncryt)}");9
     //   logToConsole($"Original data: {UnicodeEncoding.ASCII.GetString(paddedToEncryt)}");
        // Console.WriteLine("Encrypting...");
        // logToConsole("Encrypting...");
        // EncryptToBytes the data in memory.
        EncryptInMemoryData(paddedToEncryt, MemoryProtectionScope.SameLogon);
        string result = UnicodeEncoding.ASCII.GetString(paddedToEncryt);
        Console.WriteLine($"Encrypted data: {result}");
       // System.Windows.Clipboard.SetText( result );
        return result;
    }

    internal static string Decrypt(string encryptedText)
    {
        byte[] bytes = UnicodeEncoding.ASCII.GetBytes(encryptedText);
        DecryptInMemoryData(bytes, MemoryProtectionScope.SameLogon);
        string result = UnicodeEncoding.ASCII.GetString(bytes);
        //Console.WriteLine($"Decrypted data: {result}");
      //  logToConsole($"Decrypted data: {result}", true);
        return result;

    }


    internal static void EncryptInMemoryData(byte[] Buffer, MemoryProtectionScope Scope)
    {
        if(Buffer == null)
            throw new ArgumentNullException(nameof(Buffer));
        if(Buffer.Length <= 0)
            throw new ArgumentException("The toPad length was 0.", nameof(Buffer));

        // EncryptToBytes the data in memory. The result is stored in the same array as the original data.
        ProtectedMemory.Protect(Buffer, Scope);
    }

    internal static void DecryptInMemoryData(byte[] Buffer, MemoryProtectionScope Scope)
    {
        if(Buffer == null)
            throw new ArgumentNullException(nameof(Buffer));
        if(Buffer.Length <= 0)
            throw new ArgumentException("The toPad length was 0.", nameof(Buffer));

        // Decrypt the data in memory. The result is stored in the same array as the original data.
        ProtectedMemory.Unprotect(Buffer, Scope);
    }


    internal static byte[] pad(byte[] toPad, byte pad = 0x0b)
    {
        int length = toPad.Length;
        int totalPaddedLength = 0;
        int padding = 0;
        if(length < 16)
        {
            padding = 16 - length;
            totalPaddedLength = 16;
            return innerPad(toPad, pad, totalPaddedLength);
        }
        else if(length == 16)
        {
            padding = 0;
            return toPad;
        }
        else
        {
            var remainder = length % 16;
            padding = remainder;
            totalPaddedLength = length + remainder;
            return innerPad(toPad, pad, totalPaddedLength);
        }

      //  return innerPad(toPad, pad, totalPaddedLength);
    }

    private static byte[] innerPad(byte[] toPad, byte pad, int totalPaddedLength)
    {
        byte[] result = new byte[totalPaddedLength];
        for(int i = 0; i < toPad.Length; i++)
        {
            //for(int)
            result[i] = toPad[i];/// Populates the array with values 1 to 5
        }
        // use length. legth is aways 1 place after the end of the array
        for(int i = toPad.Length; i < result.Length; i++)
        {
            byte bytePadding = pad;
            result[i] = bytePadding;
        }
        return result;
    }

    internal static byte[] CreateRandomEntropy()
    {
        // Create a byte array to hold the random value.
        byte[] entropy = new byte[16];

        // Create a new instance of the RNGCryptoServiceProvider.
        // Fill the array with a random value.
        new RNGCryptoServiceProvider().GetBytes(entropy);

        // Return the array.
        return entropy;
    }

internal static int EncryptDataToStream(byte[] Buffer, DataProtectionScope Scope, Stream S)
    {
        if(Buffer == null)
            throw new ArgumentNullException(nameof(Buffer));
        if(Buffer.Length <= 0)
            throw new ArgumentException("The toPad length was 0.", nameof(Buffer));
        if(S == null)
            throw new ArgumentNullException(nameof(S));

        int length = 0;

        // EncryptToBytes the data and store the result in a new byte array. The original data remains unchanged.
        byte[] encryptedData = ProtectedData.Protect(Buffer, null ,Scope);

        // Write the encrypted data to a stream.
        if(S.CanWrite && encryptedData != null)
        {
            S.Write(encryptedData, 0, encryptedData.Length);

            length = encryptedData.Length;
        }

        // Return the length that was written to the stream.
        return length;
    }

    internal static  byte[] DecryptDataFromStream(DataProtectionScope Scope, Stream S, int Length)
    {
        if(S == null)
            throw new ArgumentNullException(nameof(S));
        if(Length <= 0)
            throw new ArgumentException("The given length was 0.", nameof(Length));
       

        byte[] inBuffer = new byte[Length];
        byte[] outBuffer;
       
        // Read the encrypted data from a stream.
        if(S.CanRead)
        {
            S.Read(inBuffer, 0, Length);

            outBuffer = ProtectedData.Unprotect(inBuffer, null, Scope);
        }
        else
        {
            throw new IOException("Could not read the stream.");
        }

        // Return the decrypted data
        return outBuffer;
    }


    //private static void Run()
    //{
    //    try
    //    {
    //        ///////////////////////////////
    //        //
    //        // Memory Encryption - ProtectedMemory
    //        //
    //        ///////////////////////////////

    //        // Create the original data to be encrypted (The data length should be a multiple of 16).
    //        byte[] toEncrypt = UnicodeEncoding.ASCII.GetBytes("ThisIsSomeData16");

    //        Console.WriteLine($"Original data: {UnicodeEncoding.ASCII.GetString(toEncrypt)}");
    //        Console.WriteLine("Encrypting...");

    //        // EncryptToBytes the data in memory.
    //        EncryptInMemoryData(toEncrypt, MemoryProtectionScope.SameLogon);

    //        Console.WriteLine($"Encrypted data: {UnicodeEncoding.ASCII.GetString(toEncrypt)}");
    //        Console.WriteLine("Decrypting...");

    //        // Decrypt the data in memory.
    //        DecryptInMemoryData(toEncrypt, MemoryProtectionScope.SameLogon);

    //        Console.WriteLine($"Decrypted data: {UnicodeEncoding.ASCII.GetString(toEncrypt)}");

    //        ///////////////////////////////
    //        //
    //        // Data Encryption - ProtectedData
    //        //
    //        ///////////////////////////////

    //        // Create the original data to be encrypted
    //        toEncrypt = UnicodeEncoding.ASCII.GetBytes("This is some data of any length.");

    //        // Create a file.
    //        FileStream fStream = new FileStream("Data.dat", FileMode.OpenOrCreate);

    //        // Create some random entropy.
    //        byte[] entropy = CreateRandomEntropy();

    //        Console.WriteLine();
    //        Console.WriteLine($"Original data: {UnicodeEncoding.ASCII.GetString(toEncrypt)}");
    //        Console.WriteLine("Encrypting and writing to disk...");

    //        // EncryptToBytes a copy of the data to the stream.
    //        int bytesWritten = EncryptDataToStream(toEncrypt, entropy, DataProtectionScope.CurrentUser, fStream);

    //        fStream.Close();

    //        Console.WriteLine("Reading data from disk and decrypting...");

    //        // Open the file.
    //        fStream = new FileStream("Data.dat", FileMode.Open);

    //        // Read from the stream and decrypt the data.
    //        byte[] decryptData = DecryptDataFromStream(entropy, DataProtectionScope.CurrentUser, fStream, bytesWritten);

    //        fStream.Close();

    //        Console.WriteLine($"Decrypted data: {UnicodeEncoding.ASCII.GetString(decryptData)}");
    //    }
    //    catch(Exception e)
    //    {
    //        Console.WriteLine($"ERROR: {e.Message}");
    //    }
    //}
}