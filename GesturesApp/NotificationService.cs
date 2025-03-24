using System;
using System.Drawing;
using JohnBPearson.Windows.Forms.Controls;
using JohnBPearson.Windows.Interop;
using JohnBPearson.Application.Gestures.Model;

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
                Bitmap bmp = new Bitmap(@".\ok.bmp");

                var popupNotifier = Notification.Create(title, content, bmp);
                if (flash)
                {
                    FlashWindow.Flash(window, 10);
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
