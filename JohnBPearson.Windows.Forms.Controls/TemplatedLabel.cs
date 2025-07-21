using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace JohnBPearson.Windows.Forms.Controls
{
    public class TemplatedLabel: System.Windows.Forms.Label
    {

		private string _template = string.Empty;
		
        [Browsable(true)]
        public string Template
		{
			get { return _template; }
			set {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _template = value;
                }
			if(ValuesToApply != null && ValuesToApply.Count >0 && !string.IsNullOrWhiteSpace(_template))
				{

                    updateText();

                }
			}
		}

		

		private List<string> _templateValues = new List<string>();
        [Browsable(true)]
        public List<string> ValuesToApply
		{ get { return _templateValues; } set {
                if(value != null)
                {
                    _templateValues = value;
                }
            } }

        [Browsable(false)]
        public new string Text { get => base.Text; private set => base.Text = value; }

        private void updateText()
        {
            try
            {
                base.Text = String.Format(Template, ValuesToApply.ToArray<string>());
            }
            catch (FormatException ex)
            {

                //throw ex;
            }
        }
        public void ClearAndReplace(params string[] args)
        {
            if (this._templateValues != null)
            {
                this._templateValues.Clear();
                foreach (string arg in args)
                {
                    this.ValuesToApply.Add(arg);
                }
                updateText();
            }
        }
    }
}
