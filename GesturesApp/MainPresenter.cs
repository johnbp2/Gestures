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
using System.Collections.Specialized;
using JohnBPearson.Windows.Forms.Gestures.Properties;



namespace JohnBPearson.Windows.Forms.Gestures
{
    public interface IPresenterBase : INotifyPropertyChanged
    {

    }


    public class MainPresenter : IPresenter<Main>
    {
        private bool _loadJson;
        public bool LoadJson
        {
            get
            {
                return _loadJson;
            }
            set
            {
                _loadJson = value;
            }
        }

        private JohnBPearson.Application.Gestures.Model.GestureFactory _containerList;
        public GestureFactory ContainerList
        {
            get
            {
                if(this._containerList == null)
                {
                    if(this.LoadJson)
                    {

                        this._containerList = new GestureFactory();
                      string test =   Properties.Settings.Default.UsedLastSavedNextSession ? Properties.Settings.Default.LastSavedFileLocation : "";
                        JsonService.Import(this._containerList, test);
                    }
                    else
                    {
                        this.mapSettingsToDto();
                    }


                }
                return this._containerList;
            }
            set
            {
                this._containerList = value;
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
        // NEEDS TO be set by caller
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



        private JohnBPearson.Application.Gestures.Model.IGestureObject _current;

        public JohnBPearson.Application.Gestures.Model.IGestureObject Current
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
        public void updateContainer(string newValue, string newDescription, string selectedKey)
        {
            var itemToUpdate = this.findKeyBoundValue(selectedKey);
            if(itemToUpdate != null)
            {


                this.updateContainerInner(itemToUpdate, newValue, newDescription);

            }
            else
            {
                throw new System.ArgumentException($"cannot find object for key: {selectedKey} ", "selectedKey");
            }
        }

        private void updateContainerInner(JohnBPearson.Application.Gestures.Model.IGestureObject oldItem, string newData, string description)
        {
            //var newItem = JohnBPearson.Application.Gestures.Model.GestureObject.Create(this.ContainerList, oldItem.KeyAsChar,
            //    newData, description, oldItem.Data.isProtected, hexString);
            oldItem.Data.Value = newData;
            oldItem.Description.Value = description;
           
            // this.GestureFactory.Replace(oldItem, newItem);
            GlobalHotKey.removeAllRegistration();
            registerHotKeys(ContainerList.Items);
            //  this.Form.bindDropDownKeyValues();
            this.Form.updateUI(oldItem as Application.Gestures.Model.GestureObject);

        }

        private int executeSaveAsUserSettings(bool overrideAutoSaveSetting)
        {
            var strings = this.ContainerList.PrepareDataForSave();
            //  Properties.Settings.Default.DataValues = strings.Values;
            // Properties.Settings.Default.Descriptions = strings.Descriptions;
            //  Properties.Settings.Default.IsProtected.Clear();
            Properties.Settings.Default.IsProtected = GestureFactory.ParseBoolsToStrings(strings.IsProtected);
            //  Properties.Settings.Default.Protect = GestureFactory.ParseBoolsToStrings(strings.Protect);
            //var settingsCollection = new System.Collections.Specialized.StringCollection();
            //  settingsCollection.AddRange(strings.HexStrings.ToArray());
            Properties.Settings.Default.HexStrings = this.copyGenericListToSpecCol<string>(strings.HexStrings); //strings.HexStrings.
                                                                                                                // settingsCollection = new System.Collections.Specialized.StringCollection();
                                                                                                                //var stringLengths = new 
                                                                                                                //strings.DataLengths.ForEach(delegate (int length)                                                                                                                                                                                                                                                                                                                                                                          bb
                                                                                                                //{
                                                                                                                //    settingsCollection.Add(length.ToString());
                                                                                                                //});
            Properties.Settings.Default.DataLength = this.copyGenericListToSpecCol<int>(strings.DataLengths);
            Properties.Settings.Default.Data = this.copyGenericListToSpecCol<string>(strings.Data);
            Properties.Settings.Default.Description = this.copyGenericListToSpecCol<string>(strings.Description);
            Properties.Settings.Default.Save();
            this.mapSettingsToDto();
            GlobalHotKey.removeAllRegistration();
            this.registerHotKeys(this.ContainerList.Items);
            return this.ContainerList.Modified;
        }

        private StringCollection copyGenericListToSpecCol<T>(IList<T> arr)
        {
            //var stringLengths = new 
            var settingsCollection = new System.Collections.Specialized.StringCollection();
            arr.ToList<T>().ForEach(action: delegate (T length)
            {
                settingsCollection.Add(length.ToString());
            });
            return settingsCollection;
        }
        public void save()
        {
            if(Properties.Settings.Default.JsonSave)
            {
                this.executeJsonSave();
            }
            else
            {
                this.executeSaveAsUserSettings(false);
            }
        
        }

        private void executeJsonSave()
        {
        Properties.Settings.Default.LastSavedFileLocation =   JsonService.Export(this.ContainerList);
            Properties.Settings.Default.Save();
        }

        //public void executeJsonSave()
        //{
        //            var export = System.Text.Json.JsonSerializer.Serialize<List<JohnBPearson.Application.Gestures.Model.Domain.Entities.GestureDTO>>(this._containerList.MapToEntities());
        //            //  System.Windows.Clipboard.SetText(export);

        //            // Displays a SaveFileDialog so the user can save the Image
        //            // assigned to Button2.
        //            if(this.SaveDialog == null)
        //            {

        //                SaveDialog = new System.Windows.Forms.SaveFileDialog();
        //            }
        //            SaveDialog.Filter = "json text|*.json";
        //            SaveDialog.Title = "Save all your key bindings to json File";
        //            SaveDialog.DefaultExt = "json";
        //            string currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //            string path = Path.Combine(currentDir, "JsonObjects");

        //    if(!Directory.Exists(path))
        //    {
        //        Directory.CreateDirectory(path);
        //    }
        //    SaveDialog.InitialDirectory = path;
        //    SaveDialog.ShowDialog();

        //    // If the file name is not an empty string open it for saving.
        //    if(SaveDialog.FileName != "")
        //    {
        //        // Saves the Image via a FileStream created by the OpenFile method.
        //        using(System.IO.FileStream fs =
        //              (System.IO.FileStream)SaveDialog.OpenFile())
        //        {

        //            // Saves the Image in the appropriate ImageFormat based upon the
        //            // File type selected in the dialog box.
        //            // NOTE that the FilterIndex property is one-based.
        //            switch(SaveDialog.FilterIndex)
        //            {

        //                case 1:
        //                    byte[] exportBytes = new UTF8Encoding(true).GetBytes(export);
        //                    fs.Write(exportBytes, 0, exportBytes.Length);
        //                    break;
        //            }

        //            fs.Close();
        //        }
        //    }

        //}
        public IEnumerable<string> Keys
        {
            get
            {
               
                return this.ContainerList.Keys;
            }
        }
        public IEnumerable<JohnBPearson.Application.Gestures.Model.IGestureObject> Containers
        {
            get
            {
              
                return this.ContainerList.Items;
            }

        }
        public void setCommandArgs(string[] args)
        {
            if(args != null && args.Length > 0 && args[0] == "-j")
            {
                this._loadJson = true;
                            }
        }

        // TODO: rename to <code>setcurrent(string keyValue)</code> remove the option to not set as current
        private JohnBPearson.Application.Gestures.Model.IGestureObject findKeyBoundValue(string keyValue)
        {
            var currentItem = this.Containers.ToList().Find((item) => { return item.Key.Value == keyValue; });

            this._current = currentItem;

            return currentItem;
        }

        public void RefreshData()
        {

            this.mapSettingsToDto();

            GlobalHotKey.removeAllRegistration();
            this.registerHotKeys(this.Containers);

            this._main.updateUI(Current as JohnBPearson.Application.Gestures.Model.GestureObject);
        }
        private void mapSettingsToDto()
        {

            var dto = Mapper.mapToDto(Properties.Settings.Default.IsProtected, Settings.Default.DataLength, Settings.Default.HexStrings, Settings.Default.Description, Settings.Default.Data);
            this._containerList = new GestureFactory(dto);
            // return this.GestureFactory;
        }



        public void registerHotKeys(IEnumerable<JohnBPearson.Application.Gestures.Model.IGestureObject> keys)
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
