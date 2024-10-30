using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace JohnBPearson.Windows.Forms.Controls
{
    public class TransparentTextBox :  TextBox
    {

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
                return cp;
            }
        }

        public void setFontColor(System.Drawing.Color fontColor)
        { 
            this.ForeColor = fontColor;
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }
    }
}
