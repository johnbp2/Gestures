using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Colore.Data;
using Windows.Networking.Sockets;

namespace JohnBPearson.Windows.Forms.KeyBindingButler
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            ////string original = "PASSWORD";
            ////using(AesManaged myAes = new AesManaged())
            ////{
            ////    Encrypt the string to an array of bytes.
            ////    byte[] encrypted = JohnBPearson.Cypher.Aes.AesCypher.EncryptStringToBytes_Aes(original, myAes.Key, myAes.IV);
            ////    var str = System.Text.Encoding.Default.GetString(encrypted);

            ////    Decrypt the bytes to a string.
            ////    string roundtrip = JohnBPearson.Cypher.Aes.AesCypher.DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);

            ////    Display the original data and the decrypted data.
            ////    Console.WriteLine("Original:   {0}", original);
            ////    Console.WriteLine("Encrypted:  {0}", str);
            ////    Console.WriteLine("Round Trip: {0}", roundtrip);
            ////}
            Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

            // Add handler for UI thread exceptions
            Application.ThreadException += new ThreadExceptionEventHandler(UIThreadException);

            // Force all WinForms errors to go through handler
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // This handler is for catching non-UI thread exceptions
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            if (Program.IsFirstInstance())
            {
                var main = new Main(new MainPresenter());
                Application.Run(main);
            } else {
                System.Windows.MessageBox.Show("Instance of the Key Binding Butler is already running!");
                Application.Exit();
        } }

        private static void CurrentDomain_UnhandledException(Object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                MessageBox.Show("Unhadled domain exception:\n\n" + ex.Message);
            }
            catch (Exception exc)
            {
                try
                {
                    MessageBox.Show("Fatal exception happend inside UnhadledExceptionHandler: \n\n"
                        + exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }

            // It should terminate our main thread so Application.Exit() is unnecessary here
        }

        private static void UIThreadException(object sender, ThreadExceptionEventArgs t)
        {
            try
            {
                MessageBox.Show("Unhandled exception catched.\n Application is going to close now.");
            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal exception happend inside UIThreadException handler",
                        "Fatal Windows Forms Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }

            // Here we can decide if we want to end our application or do something else
            Application.Exit();
        }

        static bool IsFirstInstance()
        {
            // First attempt to open existing mutex, using static method: Mutex.OpenExisting
            // It would fail and raise an exception, if mutex cannot be opened (since it didn't exist)
            // And we'd know this is FIRST instance of application, would thus return 'true'

            try
            {
                Mutex SingleInstanceMutex = Mutex.OpenExisting("SingleInstanceApp");
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                // Success! This is the first instance
                // Initial owner doesn't really matter in this case...
                Mutex SingleInstanceMutex = new Mutex(false, "SingleInstanceApp");

                return true;
            }

            // No exception? That means mutex ALREADY existed!
            return false;
        }
    }
}
