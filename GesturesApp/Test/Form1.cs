using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.UI.Xaml.Controls;
using System.IO;
using System.Security.Cryptography;
using Extension;

namespace JohnBPearson.Windows.Forms.Gestures.Test
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AESRam ramClass = new AESRam();
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            var fetchCryptDialog = new OpenFileDialog();
            fetchCryptDialog.CheckFileExists = true;
            fetchCryptDialog.InitialDirectory = "C:\\";
            fetchCryptDialog.Multiselect = false;
            if(fetchCryptDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fetchCryptDialog.FileName;
            }
        }

        private void Encrypt_Click(object sender, EventArgs e)
        {
            var fileToEncrypt = textBox1.Text;
            var password = "123456789ABCDEFG!@#$%^&*()_+";

       

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
                    File.WriteAllBytes(fileToEncrypt.Replace(".json", ".dat"), finalBuffer);

                }
            }
        }

        private static byte[] getInitVecrorBytes()
        {
            var initVector = "HR$2pIjHR$2pIj12HR$2pIjHR$2pIj12";
            Byte[] iv = new byte[32];
            Encoding.Default.GetBytes(initVector).CopyTo(iv, 0);
            return iv;
        }

        private void Decrypt_Click(object sender, EventArgs e)
        {
            var fileToDecrypt = textBox1.Text.Replace(".json", ".dat");
            var password = "123456789ABCDEFG!@#$%^&*()_+";
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
                    var finalBuffer = new Byte[appendBuffer.Length - 1];
                    appendBuffer.CopyTo(finalBuffer, 0);
                    
                    File.WriteAllBytes(fileToDecrypt, finalBuffer);

                }
            }
        }
    }
    //    Imports System.IO
    //Imports System.Security.Cryptography
    //Imports System.Text

    //Public Class Form1


    //    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    //        Dim ramClass As New AESRam()
    //    End Sub

    //    Private Sub Browse_Click(sender As Object, e As EventArgs) Handles Browse.Click

    //        'Allows you to access files from folders
    //        Dim fetchCryptDialog As New OpenFileDialog With {
    //            .CheckFileExists = True,
    //            .InitialDirectory = "C:\",
    //        .Multiselect = False
    //        }

    //    If fetchCryptDialog.ShowDialog = DialogResult.OK Then

    //        TextBox1.Text = fetchCryptDialog.FileName

    //    End If


    //End Sub


    //Private Sub Encrypt_Click(sender As Object, e As EventArgs) Handles Encrypt.Click

    //        'File path goes to textbox
    //        Dim Rythorian77 As String = TextBox1.Text

    //        'This password can be whater you want.

    //    Dim password As String = "123456789ABCDEFG!@#$%^&*()_+"

    //        'A data type is the characteristic of a variable that determines what kind of data it can hold.
    //        'Data types include those in the following table as well as user-defined types and specific types of objects.

    //    Dim key As Byte() = New Byte(31)
    //    {
    //    }

    //        'When overridden in a derived class, encodes a set of characters into a sequence of bytes.
    //        Encoding.Default.GetBytes(password).CopyTo(key, 0)

    //        'RijndaelManaged still works but is considered obsolete in todays world so we use AES
    //        'Represents the abstract base class from which all implementations of the Advanced Encryption Standard (AES) must inherit.
    //        'https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.aes?view=net-6.0
    //        Dim aes As New RijndaelManaged() With
    //            {
    //                .Mode = CipherMode.CBC,
    //                .KeySize = 256,
    //                .BlockSize = 256,
    //                .Padding = PaddingMode.Zeros
    //}

    //'Reads a sequence of bytes from the current memory stream and advances the position within the memory stream by the number of bytes read. 
    //        Using mnemonicData As New MemoryStream

    //            'Defines a stream that links data streams to cryptographic transformations.
    //            Using cStream As New CryptoStream(mnemonicData, aes.CreateEncryptor(key, key), CryptoStreamMode.Write)
    //                Dim buffer As Byte() = File.ReadAllBytes(Rythorian77)
    //                cStream.Write(buffer, 0, buffer.Length)
    //                Dim appendBuffer As Byte() = mnemonicData.ToArray()
    //                Dim finalBuffer As Byte() = New Byte(appendBuffer.Length - 1) {}
    //                appendBuffer.CopyTo(finalBuffer, 0)
    //                File.WriteAllBytes(Rythorian77, finalBuffer)

    //            End Using
    //        End Using

    //    End Sub
    // 'The above code notes compliment the same
    //    Private Sub Decrypt_Click(sender As Object, e As EventArgs) Handles Decrypt.Click
    //        Dim Rythorian77 As String = TextBox1.Text

    //        Dim password As String = "123456789ABCDEFG!@#$%^&*()_+"

    //        Dim key As Byte() = New Byte(31) {}

    //        Encoding.Default.GetBytes(password).CopyTo(key, 0)

    //        Dim aes As New RijndaelManaged() With
    //            {
    //                .Mode = CipherMode.CBC,
    //                .KeySize = 256,
    //                .BlockSize = 256,
    //                .Padding = PaddingMode.Zeros
    //            }

    //        Using mnemonicData As New MemoryStream
    //            '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>    < aes.CreateDecryptor > is the only change from above aes.CreateEncryptor
    //            Using cStream As New CryptoStream(mnemonicData, aes.CreateDecryptor(key, key), CryptoStreamMode.Write)
    //                Dim buffer As Byte() = File.ReadAllBytes(Rythorian77)
    //                cStream.Write(buffer, 0, buffer.Length)
    //                Dim appendBuffer As Byte() = mnemonicData.ToArray()
    //                Dim finalBuffer As Byte() = New Byte(appendBuffer.Length - 1) {}
    //                appendBuffer.CopyTo(finalBuffer, 0)
    //                File.WriteAllBytes(Rythorian77, finalBuffer)

    //            End Using
    //        End Using

    //    End Sub

    //End Class



    //**Add this separate Class:**

    //Imports System.Runtime.InteropServices

    //Public Class AESRam

    //    'This controls the amount of RAM that your process uses, it doesn't otherwise have any affect on the virtual memory size of your process. 
    //    'Sets the minimum and maximum working set sizes for the specified process.
    //    'This will cut memory usage in half.
    //    <DllImport("KERNEL32.DLL", EntryPoint:= "SetProcessWorkingSetSize", SetLastError:= True, CallingConvention:= CallingConvention.StdCall)>
    //    Friend Shared Function SetProcessWorkingSetSize(pProcess As IntPtr, dwMinimumWorkingSetSize As Integer, dwMaximumWorkingSetSize As Integer) As Boolean
    //    End Function

    //    'Retrieves a pseudo handle for the current process.
    //    <DllImport("KERNEL32.DLL", EntryPoint:= "GetCurrentProcess", SetLastError:= True, CallingConvention:= CallingConvention.StdCall)>
    //    Friend Shared Function GetCurrentProcess() As IntPtr
    //    End Function

    //    'See Above
    //    Public Sub New()
    //        Dim pHandle As IntPtr = GetCurrentProcess()
    //        SetProcessWorkingSetSize(pHandle, -1, -1)
    //    End Sub

    //End Class


}
