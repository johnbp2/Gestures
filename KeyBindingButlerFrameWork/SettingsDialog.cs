﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JohnBPearson.Windows.Forms.KeyBindingButler
{
    public partial class SettingsDialog : Form
    {
        public SettingsDialog()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.popupNotifier1.Popup();
           
        Properties.Settings.Default.autoSave = rbAutoSaveOn.Checked;
         

                Properties.Settings.Default.MinimizeToTray = rbMinimizeToTrayOn.Checked;
            Properties.Settings.Default.ServantName = tbServantName.Text;

            Properties.Settings.Default.Save();
        }

        private void SettingsDialog_Load(object sender, EventArgs e)
        {
            this.rbAutoSaveOff.Checked = !Properties.Settings.Default.autoSave;
            this.rbAutoSaveOn.Checked = Properties.Settings.Default.autoSave;

            this.rbMinimizeToTrayOn.Checked = Properties.Settings.Default.MinimizeToTray;
            this.rbMinimizeToTrayOff.Checked = !Properties.Settings.Default.MinimizeToTray;

            tbServantName.Text = Properties.Settings.Default.ServantName;
            popupNotifier1.ContentText = $"{tbServantName.Text} has saved your settings you can close settings dialog now";


            // "2011-03-21 13:26";
         //   var test = DateTime.Now.CompareTo(DateTime.ParseExact($"{DateTime.Today.Year}-{DateTime.Today.Month}-{DateTime.Today.Day} 12:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture));
            popupNotifier1.TitleText = Properties.Settings.Default.ServantName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
