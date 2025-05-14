using System;
using System.Drawing;
using System.Windows.Forms;
using JohnBPearson.Application.Gestures.Model;
using JohnBPearson.Application.Gestures.Model;



namespace JohnBPearson.Windows.Forms.Gestures
{

    public partial class BaseForm : System.Windows.Forms.Form
    {


        protected BaseForm()
        {
            this.InitializeComponent();
        }

        public ToolStripStatusLabel MyProperty
        {
            get
            {
                return toolStripStatusLabel1;
            }

        }


        //public  Color BgColor
        //{
        //    get
        //    {
        //        return this.BackColor;
        //    }
        //    set
        //    {
        //        this.BackColor = value;
        //    }
        //}

        protected virtual void form_load(object sender, EventArgs args)
        {

        }

        //  protected . notifier = new PopupNotifier();


        protected void notify(Form form, string title, string content, bool flash = false, ToastOptions toastType = ToastOptions.All, int flashCount = 0)
        {

            NotificationService.notify(form, title, content, flash, toastType);
            this.toolStripStatusLabel1.Text = content;
            //    if (toastType == ToastOptions.None)
            //    {
            //        return;
            //    }


            //    if (Properties.Settings.Default.ToastOption == ((int)toastType) || Properties.Settings.Default.ToastOption == (int)ToastOptions.All)
            //    {
            //        Bitmap bmp = new Bitmap(@".\Butler.png");1

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

        protected void setStatus(string text)
        {
            this.toolStripStatusLabel1.Text = text;

        }



        private void BaseForm_PaddingChanged(object sender, EventArgs e)
        {

        }

        private void BaseForm_SizeChanged(object sender, EventArgs e)
        {

        }

        private void BaseForm_Paint(object sender, PaintEventArgs e)
        {
            if(this.InvokeRequired)
            {

                this.Invoke(new MethodInvoker(delegate
                {
                    this.BackColor = Properties.Settings.Default.BgColor;
                }));
            }
            else
            {
                this.BackColor = Properties.Settings.Default.BgColor;
            }
        }
    }

}
