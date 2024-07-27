using JohnBPearson.Windows.Interop;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Tulpep.NotificationWindow;
using JohnBPearson.KeyBindingButler.Model;
using JohnBPearson.Windows.Forms.Controls;
using System.Runtime.CompilerServices;
using System.Drawing;
using System.Linq;
using JohnBPearson.Windows.Forms.KeyBindingButler.Properties;
using Windows.Media.Protection.PlayReady;
using Windows.UI.Xaml.Controls;
using System.ComponentModel.Design;

namespace JohnBPearson.Windows.Forms.KeyBindingButler
{
    public partial class Main : BaseForm
    {


        #region private fields
        private JohnBPearson.Windows.Forms.Controls.NotBetterButton btnTest;
        private DataTable keyIndexTable;
        //  private string hotkeyModifiers = Properties.Settings.Default.HotkeyModifiers;
       // private Parser userSettingsHelper;

    private MainPresenter presenter;
        private JohnBPearson.KeyBindingButler.Model.IKeyBoundData currentItem;

        private ContextMenu contextMenuIcon;
        private MenuItem menuItemIcon;
 

        public string selectedKeyBoundValue
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
            //this.keyBoundValueList.Items;]
          
            this.setupTryIconMenu();
        }


       


        #region private methods



    
        public void hotKeyCallBack(IKeyBoundData item)
        {
            var data = item.Data.Value;
            if (Properties.Settings.Default.stringProtection)
            {
                var list = new SettingToList(Properties.Settings.Default.parseListToFindPassword).List;
                foreach (var compare in list)
                {
                    if (item.Description.Value.Contains(compare))
                    {
                        data = Cypher.Aes.AesCypher.UnlockString(item.Description.Value);
                           break;
                    }
                }
            }
            System.Windows.Clipboard.SetText(data);
           
            this.lblKey.ClearAndReplace(item.Key.Value.ToLower());
            this.cbHotkeySelection.SelectedItem = item.Key.Value.ToLower();
            updateUIByKey(item.Key.Key);

            Settings.Default.LastBoundKeyPressed = item.Key.Value;
            Settings.Default.Save();
            base.notify($"Sir your data: {item.Description.Value}", "Is in the clipboard", false ,ToastOptions.Hotkey);
          //  messages.raiseEvent(key, item);
        }





        private void registerHotKeys(IEnumerable<JohnBPearson.KeyBindingButler.Model.IKeyBoundData> keys)
        {
            var index = 0;
            GlobalHotKey.removeAllRegistration();
            foreach (var item in keys)
            {

                
                var sb = new StringBuilder();
                sb.Append(Properties.Settings.Default.KeyBindingModifiers);
                sb.Append(item.KeyAsChar);
                var del = new KeyBindCallBack(hotKeyCallBack);
                    GlobalHotKey.RegisterHotKey(sb.ToString(), item , del);





                index++;
            }
               }

        

        private void bindDropDownKeyValues()
        {



            this.cbHotkeySelection.Items.Clear();
            this.cbHotkeySelection.DataSource = this.presenter.Keys;
            //1  var currentHotKeyGuildAd = Properties.Settings.Default.UserHotKeyGuildAd.ToString();
       
      

        }


        
        private void setupTryIconMenu()        {
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
                  var result =  this.presenter.executeAutoSave(overrideAutoSaveSetting, Properties.Settings.Default.parseListToFindPassword, Properties.Settings.Default.stringProtection);
                    if (result == 0)
                    {

                
                    base.notify(Properties.Settings.Default.ServantName, "Saved", false, ToastOptions.Save);

                        FlashWindow.TrayAndWindow(this); 
                    }
                

            
        }

        private void updateUIByKey(char key) {

            var currentItem = this.presenter.findKeyBoundValue(key.ToString());
            tbValue.Text = currentItem.Data.Value;
            tbDesc.Text = currentItem.Description.Value;

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
        { 
                //if the form is minimized  
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
            this.registerHotKeys(this.presenter.HotKeyValues);


            
            this.bindDropDownKeyValues();
            this.lblKey.Template = "Alt + Shift + {0}";
            this.lblKey.TemplateValues.Add("a");
        
          

        }


        private void tbValue_TextChanged(object sender, EventArgs e)
        {
            if (this.selectedKeyBoundValue != null) {
                var itemToUpdate = this.presenter.findKeyBoundValue(this.selectedKeyBoundValue);
              
                this.presenter.updateItem(itemToUpdate, tbValue.Text, itemToUpdate.Description.Value);
         
            }
        }






        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settings = new SettingsDialog();
            settings.Show();
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
            if (this.selectedKeyBoundValue != null)
            {
                this.updateUIByKey(this.selectedKeyBoundValue.ToCharArray()[0]);
              
            }

            this.lblKey.ClearAndReplace(cbHotkeySelection.Text);
        }

        private void tbValue_Leave(object sender, EventArgs e)
        {
            updateKeyBoundData(tbValue.Text, "");
        }

        private void updateKeyBoundData(string newValue, string newDescription)
        {
            if (this.selectedKeyBoundValue != null)
            {
                var itemToUpdate = this.presenter.findKeyBoundValue(this.selectedKeyBoundValue);

                this.presenter.updateItem(itemToUpdate, newValue, newDescription);

            }
        }

        private void cbHotkeySelection_TextUpdate(object sender, EventArgs e)
        {
            if (this.selectedKeyBoundValue != null)
            {
                tbValue.Text = this.presenter.findKeyBoundValue(this.selectedKeyBoundValue.ToString()).Data.Value;

            }
            var control = (System.Windows.Forms.ComboBox)sender;
            //if (control.Text.Length == 1)
            //{
                   this.updateUIByKey(control.Text.ToCharArray()[0]);
            //  }
            this.lblKey.ClearAndReplace(cbHotkeySelection.Text);
        }
       

        private void tbDesc_TextChanged(object sender, EventArgs e)
        {

        }

        #endregion

        private void tbDesc_Leave(object sender, EventArgs e)
        {
            updateKeyBoundData("", tbDesc.Text);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            this.registerHotKeys(this.presenter.HotKeyValues);
        }
    }
}
