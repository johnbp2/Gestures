using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace JohnBPearson.Windows.Forms.Controls
{ public interface INotification
    {
        void Popup(int index);
        void Popup();
    }
    public class Notification :JohnBPearson.Windows.Forms.Alert.PopupNotifier,  IDisposable
    {
        private List<Tuple<string, string>> _notifications = new List<Tuple<string, string>>();
            
        private Bitmap _bitmap;
        public new void Popup()
        {
            this.ContentPadding = new Padding(10, 10, 10, 10);
            this.Popup(0);
        }
        public void Popup(int index)
        {
            base.AnimationDuration = 2000;
            base.AnimationInterval = 10;
            base.TitleText = _notifications[index].Item1;
            base.ContentText = _notifications[index].Item2;
            base.Image = this._bitmap;
            base.Popup();
        }
        protected Notification(List<Tuple<string, string>> notifications, System.Drawing.Bitmap icon) : base()
        {
            this._bitmap = icon;
            this.InitializeComponent();
          
            this._notifications = notifications;
        }

       public static Notification Create(List<Tuple<string, string>> notifications, System.Drawing.Bitmap icon)
        {

            return new Notification(notifications, icon);
        }

        public static Notification Create(string title, string message, Bitmap bgImage)
        {
            
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            list.Add(new Tuple<string, string>(title, message));
            return new Notification(list, bgImage);
        }

        private void InitializeComponent()
        {
            // 
            // Notification
            // 
            this.AnimationDuration = 2000;

        }
        
    }
}
