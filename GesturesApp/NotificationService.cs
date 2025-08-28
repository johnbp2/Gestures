using System;
using System.Drawing;
using JohnBPearson.Windows.Forms.Controls;
using JohnBPearson.Windows.Interop;
using JohnBPearson.Application.Gestures.Model;
using JohnBPearson.Windows.Forms.Gestures.Properties;
using System.Reflection;
using System.IO;

namespace JohnBPearson.Windows.Forms.Gestures
{
    public static class NotificationService
    {

     

        

      public  static void notify(System.Windows.Forms.Form window, string title = "", string content ="", bool flash = false, ToastOptions toastType = ToastOptions.None)
        {
            if (toastType == ToastOptions.None)
            {
                return;
            }


            if (Properties.Settings.Default.ToastOption == ((int)toastType) || Properties.Settings.Default.ToastOption == (int)ToastOptions.All)
            {

                
                Bitmap bmp = new Bitmap(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ok.bmp")));

                var popupNotifier = Notification.Create(title, content, bmp);
                
                if (flash)
                {
                    FlashWindow.Flash(window, 10);
                }
                //((System.Drawing.Image)(resources.GetObject("popupNotifier1.Image")));1
                //using (var popupnotifier = Notification.Create(title, content, bmp) as IDisposable)
                //{

                    popupNotifier.Popup();

                //}
               
            }
        }
    }
}
