using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Windows.Forms.Gestures
{
    partial class BaseForm
    {
      
        private System.ComponentModel.IContainer components;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
        
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
           
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "BaseForm";
            this.Load += new System.EventHandler(this.form_load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BaseForm_Paint);
            this.ResumeLayout(false);

        }
    }
}
