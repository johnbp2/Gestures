using System;
using JohnBPearson.Application.Gestures.Model;
using JohnBPearson.Application.Gestures.Model;



namespace JohnBPearson.Windows.Forms.Gestures
{

    public partial class BaseForm : System.Windows.Forms.Form
    {

        protected virtual void form_load(object sender, EventArgs args)
        {
        
        }

      //  protected . notifier = new PopupNotifier();


        protected void notify(string title, string content, bool flash= false, ToastOptions toastType = ToastOptions.None, int flashCount = 0)
       {

            NotificationService.notify(this, title, content, flash, toastType);
        //    if (toastType == ToastOptions.None)
        //    {
        //        return;
        //    }


        //    if (Properties.Settings.Default.ToastOption == ((int)toastType) || Properties.Settings.Default.ToastOption == (int)ToastOptions.All)
        //    {
        //        Bitmap bmp = new Bitmap(@".\Butler.png");

        //        var popupNotifier = Notification.Create(title, content, bmp);

        //        //((System.Drawing.Image)(resources.GetObject("popupNotifier1.Image")));1
        //        using (popupNotifier as IDisposable)
        //        {

        //            popupNotifier.Popup();

        //        }
        //        if (flash)
        //        {
        //            FlashWindow.TrayAndWindow(this);
        //        }
        //    }
       }
    }

    }
