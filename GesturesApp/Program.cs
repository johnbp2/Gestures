using System;
using System.Threading;
using System.Windows.Forms;

namespace JohnBPearson.Windows.Forms.Gestures
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

          
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            // Add handler for UI thread exceptions
            System.Windows.Forms.Application.ThreadException += new ThreadExceptionEventHandler(UIThreadException);

            // Force all WinForms errors to go through handler
            System.Windows.Forms.Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // This handler is for catching non-UI thread exceptions
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            if (Program.IsFirstInstance())
            {
                var main = new Main(new MainPresenter());
                main.setBgColor(Properties.Settings.Default.BgColor);
                System.Windows.Forms.Application.Run(main);
            } else {
                System.Windows.MessageBox.Show("Instance of the InputKey Binding Butler is already running!");
                System.Windows.Forms.Application.Exit();
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
                    System.Windows.Forms.Application.Exit();
                }
            }

            // It should terminate our main thread so Application.Exit() is unnecessary here
        }

        private static void UIThreadException(object sender, ThreadExceptionEventArgs t)
        {
            try
            {
                  MessageBox.Show($"Unhandled exception catched.\n Application is going to close now. {t.Exception.Message}");
            }
            catch(Exception ex)
            {
                try
                {
                    MessageBox.Show($"Fatal exception happend inside UIThreadException handler; {ex.Message}",
                        "Fatal Windows Forms Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                finally
                {
                    System.Windows.Forms.Application.Exit();
                }
            }

            // Here we can decide if we want to end our application or do something else
            System.Windows.Forms.Application.Exit();
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
