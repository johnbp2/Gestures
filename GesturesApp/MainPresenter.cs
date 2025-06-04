using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using JohnBPearson.Application.Gestures.Model;
using JohnBPearson.Application.Model;
using JohnBPearson.Windows.Interop;
using JohnBPearson.Application.Gestures.Model.Utility;
using Windows.Management.Deployment;
using System.Windows.Forms;
using Microsoft.Win32;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;
using System.Reflection;
using System.IO;


namespace JohnBPearson.Windows.Forms.Gestures
{
    public interface IPresenterBase : INotifyPropertyChanged
    {

    }


    public class MainPresenter : IPresenter<Main>
    {
        private JohnBPearson.Application.Gestures.Model.ContainerList _containerList;
        public ContainerList ContainerList
        {
            get
            {
                return this._containerList;
            }
        }
        private Main _main;
        public Main Form
        {
            get
            {
                return this._main;
            }
            set
            {
                this._main = value;
            }
        }

        private SaveFileDialog _saveDialog;  

        public SaveFileDialog SaveDialog
        {
            get
            {
                return _saveDialog;
            }
            set
            {
                _saveDialog = value;
            }
        }



        private JohnBPearson.Application.Gestures.Model.IContainer _current;

        public JohnBPearson.Application.Gestures.Model.IContainer Current
        {
            get
            {
               // if(_current == null)
           //     {
                    return this.findKeyBoundValue(this._main.selectedKey);
                //}
            //    return _current;
            }
        }
        public void updateContainer(string newValue, string newDescription, string selectedKey, bool isProtected, string hexString)
        {
            var itemToUpdate = this.findKeyBoundValue(selectedKey);
            if(itemToUpdate != null)
            {
               

                    this.updateContainerInner(itemToUpdate, newValue, newDescription, hexString);
                
            }
            else
            {
                throw new System.ArgumentException($"cannot find object for key: {selectedKey} ", "selectedKey");
            }
        }

        private void updateContainerInner(JohnBPearson.Application.Gestures.Model.IContainer oldItem, string newData, string description, string hexString)
        {
            var newItem = JohnBPearson.Application.Gestures.Model.ContainerFactory.Create(this.ContainerList, oldItem.KeyAsChar, 
                newData, description, oldItem.Data.isProtected, hexString);
            oldItem.Data.Value = newData;
            oldItem.Description.Value = description;
           // this.ContainerList.Replace(oldItem, newItem);
            GlobalHotKey.removeAllRegistration();
            registerHotKeys(ContainerList.Items);
          //  this.Form.bindDropDownKeyValues();
            this.Form.updateUI(oldItem as Application.Gestures.Model.ContainerFactory);

        }

        public int executeSave(bool overrideAutoSaveSetting)
        {
            var strings = this.ContainerList.PrepareDataForSave();
            Properties.Settings.Default.BindableValues = strings.Values;
            Properties.Settings.Default.Descriptions = strings.Descriptions;
          //  Properties.Settings.Default.IsProtected.Clear();
            Properties.Settings.Default.IsProtected = ContainerList.ParseBoolsToStrings(strings.IsProtected);
            Properties.Settings.Default.Protect = ContainerList.ParseBoolsToStrings(strings.Protect);
            var settingsCollection = new System.Collections.Specialized.StringCollection();
            settingsCollection.AddRange(strings.HexStrings.ToArray());
            Properties.Settings.Default.HexStrings = settingsCollection; //strings.HexStrings.
            settingsCollection = new System.Collections.Specialized.StringCollection();
            //var stringLengths = new 
            strings.DataLengths.ForEach(delegate (int length)
            {
                settingsCollection.Add(length.ToString());
            });
            Properties.Settings.Default.DataLength = settingsCollection;
            Properties.Settings.Default.Save();
            this.LoadHotKeyValues();
            GlobalHotKey.removeAllRegistration();
            this.registerHotKeys(this.ContainerList.Items);
            return this.ContainerList.Modified;
        }

        public void executeJsonSave()
        {
            var export = System.Text.Json.JsonSerializer.Serialize<List<JohnBPearson.Application.Gestures.Model.Domain.Entities.ContainerEntity>>(this._containerList.MapToEntities());
            //  System.Windows.Clipboard.SetText(export);

            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            if(this.SaveDialog == null)
            {

                SaveDialog = new System.Windows.Forms.SaveFileDialog();
            }
                SaveDialog.Filter = "json text|*.json";
            SaveDialog.Title = "Save all your key bindings to json File";
            SaveDialog.DefaultExt = "json";
            string currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path = Path.Combine(currentDir, "JsonObjects"); ;
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            SaveDialog.InitialDirectory =path;
            SaveDialog.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if(SaveDialog.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                using(System.IO.FileStream fs =
                      (System.IO.FileStream)SaveDialog.OpenFile())
                {

                    // Saves the Image in the appropriate ImageFormat based upon the
                    // File type selected in the dialog box.
                    // NOTE that the FilterIndex property is one-based.
                    switch(SaveDialog.FilterIndex)
                    {

                        case 1:
                            byte[] exportBytes = new UTF8Encoding(true).GetBytes(export);
                            fs.Write(exportBytes, 0, exportBytes.Length);
                            break;
                    }

                    fs.Close();
                }
            }

        }
        public IEnumerable<string> Keys
        {
            get
            {
                if(this.ContainerList == null)
                {
                    this.LoadHotKeyValues();

                }
                return this.ContainerList.Keys;
            }
        }
        public IEnumerable<JohnBPearson.Application.Gestures.Model.IContainer> Containers
        {
            get
            {
                if(this.ContainerList == null)
                {
                    LoadHotKeyValues();
                }
                return this.ContainerList.Items;
            }

        }


        // TODO: rename to <code>setcurrent(string keyValue)</code> remove the option to not set as current
        private JohnBPearson.Application.Gestures.Model.IContainer findKeyBoundValue(string keyValue)
        {
            var currentItem = this.Containers.ToList().Find((item) => { return item.Key.Value == keyValue; });
          
                this._current = currentItem;
           
            return currentItem;
        }

        public void RefreshData()
        {

            this.LoadHotKeyValues();

            GlobalHotKey.removeAllRegistration();
            this.registerHotKeys(this.Containers);

            this._main.updateUI(Current as JohnBPearson.Application.Gestures.Model.ContainerFactory);
        }
        private void LoadHotKeyValues()
        {
            var strings = new KeyAndDataStringLiterals();
            strings.Values = Properties.Settings.Default.BindableValues;
            strings.Keys = Properties.Settings.Default.BindableKeys;
            strings.Descriptions = Properties.Settings.Default.Descriptions;
            
            strings.Protect = ContainerList.ParseStringsToBools(Properties.Settings.Default.Protect);

            strings.IsProtected = ContainerList.ParseStringsToBools(Properties.Settings.Default.IsProtected);
            strings.DataLengths = ContainerList.paresStringsToInts(Properties.Settings.Default.DataLength);
           strings.HexStrings = Properties.Settings.Default.HexStrings.Cast<string>().ToList();
            string[] arr = new string[26];

            this._containerList = new JohnBPearson.Application.Gestures.Model.ContainerList(strings);
           // return this.ContainerList;
        }



        public void registerHotKeys(IEnumerable<JohnBPearson.Application.Gestures.Model.IContainer> keys)
        {
            GlobalHotKey.removeAllRegistration();
            var result = new StringBuilder();
            // int index = 0;
            foreach(var item in keys)
            {


                var sb = new StringBuilder();
                sb.Append(Properties.Settings.Default.KeyBindingModifiers);
                sb.Append(item.KeyAsChar);
                var del = new KeyBindCallBack(this._main.hotKeyCallBack);
                GlobalHotKey.RegisterHotKey(sb.ToString(), item, del);
                result.Append($"{item.Key}, ");




                // index++;
            }
        }
    }





}
