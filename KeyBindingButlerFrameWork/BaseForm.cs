using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JohnBPearson.Application.Model;
using JohnBPearson.Windows.Forms.Controls;
using JohnBPearson.Windows.Interop;
using Microsoft.Toolkit.Uwp.Notifications;
using Tulpep.NotificationWindow;


namespace JohnBPearson.Windows.Forms.KeyBindingButler
{

    public partial class BaseForm : System.Windows.Forms.Form
    {

        protected virtual void form_load(object sender, EventArgs args)
        {
        
        }

        protected PopupNotifier notifier = new PopupNotifier();


        protected void notify(string title, string content, bool flash= false, ToastOptions toastType = ToastOptions.None)
       {

            Notifier.notify(this, title, content, flash, toastType);
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
