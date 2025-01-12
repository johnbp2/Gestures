using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using JohnBPearson.Windows.Forms.Gestures.Properties;
using JohnBPearson.Windows.Interop;
using JohnBPearson.Application.Gestures.Model;

namespace JohnBPearson.Windows.Forms.Gestures
{
    public partial class Main : BaseForm
    {

        #region private fields
        private JohnBPearson.Windows.Forms.Controls.SomewhatBetterButton btnTest;
        private DataTable keyIndexTable;
        //  private string hotkeyModifiers = Properties.Settings.Def

        private MainPresenter presenter;
        private IContainer currentItem;

        private ContextMenu contextMenuIcon;
        private MenuItem menuItemIcon;


        private string selectedKey
        {
            get { if (cbHotkeySelection.SelectedItem != null) {
                    return cbHotkeySelection.SelectedItem as string;

                } else
                {
                    return null;
                }
            }

        }

        //  private IPresenter<Form> presenter;
        #endregion
        public Main(MainPresenter presenter)
        {
            this.presenter = presenter;
            presenter.Form = this;
            InitializeComponent();
            
            // var reminderForm = new Reminders();
            //this.presenter = presenter;
            //this.presenter.Form = this;
            //this._containerList.Items;]

            this.setupTryIconMenu();
        }





        #region private methods




        public void hotKeyCallBack(JohnBPearson.Application.Gestures.Model.IContainer item)
        {
            var data = item.Data.Value;
            System.Windows.Forms.Clipboard.SetDataObject(data, true, 10, 100);
            //System.Windows.Clipboard.SetText(data);

            this.lblKey.ClearAndReplace(item.Key.Value.ToLower());
            this.cbHotkeySelection.SelectedItem = item.Key.Value.ToLower();
            updateUIByKey(item.Key.Key);

            Settings.Default.LastBoundKeyPressed = item.Key.Value;
            Settings.Default.Save();
            base.notify("Copied: ", $"{item.Description.Value} to the clipboard", Properties.Settings.Default.FlashWindow, ToastOptions.Hotkey);
            //  messages.raiseEvent(key, item);
        }



        private void CopyValueToClipBoard(IContainer data)
        {

            if (data.IsDataSecured)
            {
                //   System.Windows.Clipboard.SetText(data.Secured.Value);
                Clipboard.SetDataObject(data.Data.Value, true);
            }
            else
            {
                Clipboard.SetDataObject(data.Data.Value, true);
            }
            this.lblKey.ClearAndReplace(data.Key.Value.ToLower());
            this.cbHotkeySelection.SelectedItem = data.Key.Value.ToLower();
            this.updateUIByKey(data.Key.Key);

            Settings.Default.LastBoundKeyPressed = data.Key.Value;
            Settings.Default.Save();

        }

        //private void registerHotKeys(IEnumerable<JohnBPearson.Application.Model.IKeyBoundData> keys)
        //{
           
        //    base.notify("Registered keys complete!", $"Registered keys: {result}", false, ToastOptions.All);
        //}



        private void bindDropDownKeyValues()
        {



            this.cbHotkeySelection.Items.Clear();
            this.cbHotkeySelection.DataSource = this.presenter.Keys;
            //1  var currentHotKeyGuildAd = Properties.Settings.Default.UserHotKeyGuildAd.ToString();



        }



        private void setupTryIconMenu() {
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
            var result = this.presenter.executeAutoSave(overrideAutoSaveSetting, Properties.Settings.Default.ParseListToFindPassword, Properties.Settings.Default.StringProtection);
            if (result == 0)
            {


                base.notify("Success", "Saved", Properties.Settings.Default.FlashWindow, ToastOptions.Save);

                if (Properties.Settings.Default.FlashWindow)
                {
                    FlashWindow.TrayAndWindow(this);
                }
            }



        }

        private void updateUIByKey(char key) {

            var currentItem = this.presenter.findKeyBoundValue(key.ToString());
            tbValue.Text = currentItem.Data.Value;
            tbDesc.Text = currentItem.Description.Value;
            cbSecure.Checked = currentItem.IsDataSecured;
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
            if (this.WindowState == FormWindowState.Minimized && Properties.Settings.Default.MinimizeToTray)
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



            this.bindDropDownKeyValues();
            this.lblKey.Template = "Alt + Shift + {0}";
            this.lblKey.ValuesToApply.Add("a");



        }


        private void tbValue_TextChanged(object sender, EventArgs e)
        {
            if (this.selectedKey != null) {
                var itemToUpdate = this.presenter.findKeyBoundValue(this.selectedKey);

                this.presenter.updateContainer(tbValue.Text, itemToUpdate.Description.Value,this.selectedKey, this.cbSecure.Checked);

            }
        }






        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settings = new SettingsDialog();
            settings.Show();
            this.BgColor = Properties.Settings.Default.BgColor;
        }




        private void Main_Activated(object sender, EventArgs e)
        {
            FlashWindow.Stop(this);
        }

        private void notBetterButton2_Click(object sender, EventArgs e)
        {
            this.btnSave_Click(sender, e);

        }



        private void cbHotkeySelection_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.selectedKey != null)
            {
                this.updateUIByKey(this.selectedKey.ToCharArray()[0]);

            }

            this.lblKey.ClearAndReplace(cbHotkeySelection.Text);
        }

        private void tbValue_Leave(object sender, EventArgs e)
        {
            this.presenter.updateContainer(tbValue.Text, tbDesc.Text, selectedKey, cbSecure.Checked);
        }

      

        private void cbHotkeySelection_TextUpdate(object sender, EventArgs e)
        {
            if (this.selectedKey != null)
            {
                tbValue.Text = this.presenter.findKeyBoundValue(this.selectedKey.ToString()).Data.Value;

            }
            var control = (System.Windows.Forms.ComboBox)sender;
            //if (control.Text.Length == 1)
            //{
            this.updateUIByKey(control.Text.ToCharArray()[0]);
            //  }
            this.lblKey.ClearAndReplace(cbHotkeySelection.Text);
        }




        private void tbDesc_Leave(object sender, EventArgs e)
        {
            this.presenter.updateContainer(tbValue.Text, tbDesc.Text, this.selectedKey, this.cbSecure.Checked);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            this.presenter.registerHotKeys(this.presenter.Containers);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (this.cbHotkeySelection.SelectedIndex > -1)
            {
                var item = this.cbHotkeySelection.Items[this.cbHotkeySelection.SelectedIndex];
                if (item != null) {
                var ikbv = this.presenter.findKeyBoundValue(item.ToString());
                    this.CopyValueToClipBoard(ikbv);
                }
                //this.CropValueToClipBoard();
            }




        }

        private void cbSecure_CheckedChanged(object sender, EventArgs e)
        {
            this.presenter.updateContainer(this.tbValue.Text, this.tbDesc.Text, this.selectedKey,this.cbSecure.Checked);
            // private void updateKeyBoundData(string newValue, string newDescription)
        }

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

        #endregion
    }
}
