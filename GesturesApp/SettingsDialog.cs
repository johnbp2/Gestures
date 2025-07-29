using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JohnBPearson.Application.Gestures.Model;
using Windows.ApplicationModel.Background;

namespace JohnBPearson.Windows.Forms.Gestures
{
    public partial class SettingsDialog : BaseForm
    {
        public SettingsDialog()
        {
            InitializeComponent();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            Properties.Settings.Default.autoSave = rbAutoSaveOn.Checked;


            Properties.Settings.Default.MinimizeToTray = rbMinimizeToTrayOn.Checked;
            //  Properties.Settings.Default.ServantName = tbServantName.Text;
            ToastOptions toastOpt;
            if(System.Enum.TryParse(cbToastOptions.SelectedItem.ToString(), out toastOpt))
            {


                Properties.Settings.Default.ToastOption = ((int)toastOpt);
            }
            else
            {
                System.Diagnostics.Debugger.Log(10, "butler", cbToastOptions.SelectedItem.ToString());

            }
            Properties.Settings.Default.FlashWindow = this.rbFlashOn.Checked;
            Properties.Settings.Default.JsonSave = this.rbJsonOn.Checked;// Properties.Settings.Default. = 
            Properties.Settings.Default.UsedLastSavedNextSession = this.rbLastSavedOn.Checked;
            Properties.Settings.Default.Save();
            this.notify(this, "Settings save", "Was successful", this.rbFlashOn.Checked, toastOpt);
            this.Close();
        }

        private void SettingsDialog_Load(object sender, EventArgs e)
        {
            this.somewhatBetterButton1.StartColor = Properties.Settings.Default.BgColor;
            this.somewhatBetterButton1.ForeColor = Properties.Settings.Default.BgColor;
            this.rbAutoSaveOff.Checked = !Properties.Settings.Default.autoSave;
            this.rbAutoSaveOn.Checked = Properties.Settings.Default.autoSave;

            this.rbMinimizeToTrayOn.Checked = Properties.Settings.Default.MinimizeToTray;
            this.rbMinimizeToTrayOff.Checked = !Properties.Settings.Default.MinimizeToTray;
            this.rbLastSavedOn.Checked = Properties.Settings.Default.UsedLastSavedNextSession;
            this.rbLastSavedOff.Checked = !Properties.Settings.Default.UsedLastSavedNextSession;
            //  tbServantName.Text = Properties.Settings.Default.ServantName;
            // popupNotifier1.ContentText = $"You settings have been. you can close settings dialog now. or it will close in 15 seconds.";
            cbToastOptions.SelectedIndex = Properties.Settings.Default.ToastOption;

            if(Properties.Settings.Default.FlashWindow)
            {
                rbFlashOn.Checked = true;
            }
            else
            {
                rbFlashOff.Checked = true;
            }
            if(Properties.Settings.Default.JsonSave)
            {
                rbJsonOn.Checked = true;
            }
            else
            {
                rbJsonOff.Checked = true;
            }
            // "2011-03-21 13:26";
            //   var test = DateTime.Now.CompareTo(DateTime.ParseExact($"{DateTime.Today.Year}-{DateTime.Today.Month}-{DateTime.Today.Day} 12:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture));
            // popupNotifier1.TitleText = Properties.Settings.Default.ServantName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void somewhatBetterButton1_Click(object sender, EventArgs e)
        {
            this.colorDialog1 = new ColorDialog();
            var result = this.colorDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                Properties.Settings.Default.BgColor = this.colorDialog1.Color;
                this.BackColor = this.colorDialog1.Color;
                this.somewhatBetterButton1.ForeColor = this.colorDialog1.Color;
            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void somewhatBetterButton2_Click(object sender, EventArgs e)
        {
            using(this.openFileDialog1)
            {
                this.openFileDialog1.Filter = "json text|*.json";

                {
                    openFileDialog1.Filter = "json text|*.json";
                    openFileDialog1.RestoreDirectory = true;
                    openFileDialog1.ShowDialog();


                    if(openFileDialog1.FileName != string.Empty)
                    {
                        if(File.Exists(openFileDialog1.FileName))
                        {
                            tbFile.Text = Path.GetDirectoryName(openFileDialog1.FileName);
                            Properties.Settings.Default.LastSavedFileLocation = tbFile.Text;
                            return;
                        }
                    }
                    throw new System.IO.FileNotFoundException();

                }
            }
        }
    }
}
