using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using JohnBPearson.Windows.Forms.Gestures.Properties;
using JohnBPearson.Windows.Interop;
using JohnBPearson.Application.Gestures.Model;
using System.Windows.Media.Animation;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Media.TextFormatting;
using Microsoft.Win32;

namespace JohnBPearson.Windows.Forms.Gestures
{
    public partial class Main : BaseForm
    {

        #region private fields
        private JohnBPearson.Windows.Forms.Controls.SomewhatBetterButton btnTest;
        private DataTable keyIndexTable;
        //  private string hotkeyModifiers = Properties.Settings.Def

        private MainPresenter presenter;
        private IValueObjectFactory currentItem;

        private ContextMenu contextMenuIcon;
        private MenuItem menuItemIcon;


        public string selectedKey
        {
            get
            {
                if(cbHotkeySelection.SelectedItem != null)
                {
                    // this.presenter.findKeyBoundValue(cbHotkeySelection.SelectedItem.ToString(), true);
                    return cbHotkeySelection.SelectedItem as string;

                }
                else
                {
                    return null;
                }
            }

        }

        //  private IPresenter<Form> presenter;
        #endregion

        public Main() : base()
        {
        }
        public Main(MainPresenter presenter) : base()
        {
            this.presenter = presenter;
            presenter.Form = this;
            InitializeComponent();

            // var reminderForm = new RemindersForm();
            //this.presenter = presenter;
            //this.presenter.Form = this;
            //this._containerList.Items;]
            base.statusStrip1.Refresh();

            this.setupTryIconMenu();
        }





        #region private methods




        public void hotKeyCallBack(JohnBPearson.Application.Gestures.Model.IValueObjectFactory item)
        {
            var data = item.Data.Value;
            System.Windows.Forms.Clipboard.SetDataObject(data, true, 10, 100);
            //System.Windows.Clipboard.SetText(data);

            this.lblKey.ClearAndReplace(item.Key.Value.ToLower());
            this.cbHotkeySelection.SelectedItem = item.Key.Value.ToLower();
            updateUI(item as ValueObjectFactory);
          //  this.presenter.Current=  
            Settings.Default.LastBoundKeyPressed = item.Key.Value;
            Settings.Default.Save();
            base.notify(this, "Copied: ", $"{item.Description.Value} to the clipboard", Properties.Settings.Default.FlashWindow, ToastOptions.Hotkey);
            //  messages.raiseEvent(key, item);
        }



        private void CopyValueToClipBoard(IValueObjectFactory data)
        {

            try
            {


                Clipboard.SetDataObject(data.Data.Value, true);
            }
            catch(Exception ex)
            {
                Clipboard.SetDataObject(data.Data.Value, true);
            }


        }

       

   



        public void bindDropDownKeyValues()
        {



            this.cbHotkeySelection.DataSource = this.presenter.Keys;
            //1  var currentHotKeyGuildAd = Properties.Settings.Default.UserHotKeyGuildAd.ToString();



        }



        private void setupTryIconMenu()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuIcon = new System.Windows.Forms.ContextMenu();
            this.menuItemIcon = new System.Windows.Forms.MenuItem();

            // Initialize contextMenu1
            this.contextMenuIcon.MenuItems.AddRange(
                        new System.Windows.Forms.MenuItem[] { this.menuItemIcon });

            // Initialize menuItem1
            this.menuItemIcon.Index = 0;
            this.menuItemIcon.Text = "E&xit";
            this.menuItemIcon.Click += new System.EventHandler(this.menuItemIcon_Click);







            // The ContextMenu property sets the menu that will
            // appear when the systray icon is right clicked.
            notifyIcon1.ContextMenu = this.contextMenuIcon;

            // The Text property sets the text that will be displayed,
            // in a tooltip, when the mouse hovers over the systray icon  
        }








        private void presenterSave(bool overrideAutoSaveSetting)
        {
            var result = this.presenter.executeSave(overrideAutoSaveSetting);
           
                notifyDerived("Success", $"Saved. Items that were modified  {result}", Properties.Settings.Default.FlashWindow);
           



        }

        private void notifyDerived(string title, string content, bool flash = false, ToastOptions toastType = ToastOptions.None, uint flashCount = 10)
        {
            base.notify(this, title, content, flash, ToastOptions.Save);
            base.setStatus("Saved");

        }

        public void updateUI(ValueObjectFactory currentItem)
        {

            //var currentItem = this.presenter.Current;// this.presenter.findKeyBoundValue(key.ToString());
            tbValue.Text = currentItem.Data.Value;
            tbDesc.Text = currentItem.Description.Value;
            cbProtect.Checked = currentItem.Data.isProtected;

            this.lblKey.ClearAndReplace(currentItem.Key.Value.ToLower());
           // this.cbHotkeySelection.SelectedItem = currentItem.Key.Value.ToLower();
          //  this.updateUI(data.Key.Key);

         //   Settings.Default.LastBoundKeyPressed = currentItem.Key.Value;


        }

        #endregion


        #region Events

        private void menuItemIcon_Click(object Sender, EventArgs e)
        {
            // Close the form, which closes the application.
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            presenterSave(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            presenterSave(true);

        }

        private void Main_Resize(object sender, EventArgs e)
        {     //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if(this.WindowState == FormWindowState.Minimized && Properties.Settings.Default.MinimizeToTray)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
            else
            {
                this.ShowInTaskbar = true;
            }

            //  this.Size = new Size()
        }

        private void notifyIcon1_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void Main_Load(object sender, EventArgs e)
        {

            //.  this.cbHotkeySelection.ValueMember
            var actions = new List<Action<string>>();
            this.presenter.registerHotKeys(this.presenter.Containers);

           // this.presenter.EntityFactory
            this.bindDropDownKeyValues();
            this.lblKey.Template = "Alt + Shift + {0}";
            this.lblKey.ValuesToApply.Add("a");



        }


        private void tbValue_TextChanged(object sender, EventArgs e)
        {
            if(this.selectedKey != null)
            {
              

                this.presenter.updateContainer(this.tbValue.Text, this.tbDesc.Text, this.selectedKey, this.cbProtect.Checked, this.presenter.Current.Data.HexString);

            }
        }






        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settings = new SettingsDialog();
            settings.FormClosed += this.Settings_FormClosed;
            settings.ShowDialog();


        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            //  Properties.Settings.Default.Reload();
            this.BackColor = Properties.Settings.Default.BgColor;
        }

        private void Main_Activated(object sender, EventArgs e)
        {
            FlashWindow.Stop(this);
        }

        //private void notBetterButton2_Click(object sender, EventArgs e)
        //{
        //    this.btnSave_Click(sender, e);

        //}



        private void cbHotkeySelection_SelectedValueChanged(object sender, EventArgs e)
        {
            if(this.selectedKey != null)
            {
                this.updateUI(this.presenter.Current as ValueObjectFactory);

            }

            this.lblKey.ClearAndReplace(cbHotkeySelection.Text);
        }

        private void tbValue_Leave(object sender, EventArgs e)
        {
            this.presenter.updateContainer(tbValue.Text, tbDesc.Text, selectedKey, this.cbProtect.Checked, 
                this.presenter.Current.Data.HexString);
        }



        private void cbHotkeySelection_TextUpdate(object sender, EventArgs e)
        {
            if(this.selectedKey != null)
            {
                tbValue.Text = this.presenter.Current.Data.Value;
                this.updateUI(this.presenter.Current as ValueObjectFactory);
            }
            var control = (System.Windows.Forms.ComboBox)sender;
            //if (control.Text.Lengths == 1)
            //{
           
            //  }
            this.lblKey.ClearAndReplace(cbHotkeySelection.Text);
        }


         

        private void tbDesc_Leave(object sender, EventArgs e)
        {
            this.presenter.updateContainer(tbValue.Text, tbDesc.Text, this.selectedKey, this.cbProtect.Checked,this.presenter.Current.Data.HexString);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            this.presenter.RefreshData();

            this.notifyDerived("Reload", "Completed");
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if(this.cbHotkeySelection.SelectedIndex > -1)
            {
                var item = this.cbHotkeySelection.Items[this.cbHotkeySelection.SelectedIndex];
                if(item != null)
                {
                  //  var ikbv = this.presenter.findKeyBoundValue(item.ToString());
                    this.CopyValueToClipBoard(this.presenter.Current);
                    base.notify(this, "Copied", this.presenter.Current.Data.Value);
                    this.updateUI(this.presenter.Current as ValueObjectFactory);
                }
                //this.CropValueToClipBoard();
            }




        }

        //private void cbSecure_CheckedChanged(object sender, EventArgs e)
        //{
        //    this.presenter.updateContainer(this.tbValue.Text, this.tbDesc.Text, this.selectedKey);
        //    // private void updateKeyBoundData(string newValue, string newDescription)
        //}

        private void listViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ListView(this.presenter.ContainerList, this.presenter);
            form.ShowDialog();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboot = new AboutBox1();
            aboot.ShowDialog();
        }

    

        private void cbProtect_CheckedChanged(object sender, EventArgs e)
        {
            if(cbProtect.Checked && !this.presenter.Current.Data.isProtected)
            {

                this.presenter.Current.Data.encryptValue(this.presenter.Current.Data.Value);
                return;
            }
            else if(!cbProtect.Checked && this.presenter.Current.Data.isProtected)
            {
                this.presenter.Current.Data.RemoveEncryption();
            }
           // this.presenter.updateContainer(this.tbValue.Text, this.tbDesc.Text, this.selectedKey, this.cbProtect.Checked);
        }

      

        private void btnSaveJson_Click(object sender, EventArgs e)
        {
            this.presenter.SaveDialog = saveFileDialog1;
            this.presenter.executeJsonSave();

        }

        #endregion

        protected override void WndProc(ref Message message)
        {
            if(message.Msg == SingleInstance.WM_SHOWFIRSTINSTANCE)
            {
                ShowWindow();
            }
            base.WndProc(ref message);
        }

        public void ShowWindow()
        {
            // Insert code here to make your form show itself.
            WinApi.ShowToFront(this.Handle);
        }

    }
}
