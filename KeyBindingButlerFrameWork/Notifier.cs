using JohnBPearson.KeyBindingButler.Model;
using JohnBPearson.Windows.Interop;
using System;
using System.Drawing;
using JohnBPearson.Windows.Forms.Controls;
using Tulpep.NotificationWindow;

namespace JohnBPearson.Windows.Forms.KeyBindingButler
{
    public static class Notifier
    {

     

        

      public  static void notify(System.Windows.Forms.Form window, string title = "", string content ="", bool flash = false, ToastOptions toastType = ToastOptions.None)
        {
            if (toastType == ToastOptions.None)
            {
                return;
            }


            if (Properties.Settings.Default.ToastOption == ((int)toastType) || Properties.Settings.Default.ToastOption == (int)ToastOptions.All)
            {
                Bitmap bmp = new Bitmap(@".\Butler.png");

                var popupNotifier = Notification.Create(title, content, bmp);
                if (flash)
                {
                    FlashWindow.TrayAndWindow(window);
                }
                //((System.Drawing.Image)(resources.GetObject("popupNotifier1.Image")));1
                using (popupNotifier as IDisposable)
                {

                    popupNotifier.Popup();

                }
               
            }
        }
    }
}
