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


                    this._containerList = new GestureFactory();
                    string test = Properties.Settings.Default.UsedLastSavedNextSession ? Properties.Settings.Default.LastSavedFile : "";
                    this.Form.FileLabelText = JsonService.Import(this._containerList, test.Length == 0);



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

        // public List<Message> Messages = new List<Message>();

        public Messaging.Message createMessage(string message, Messaging.MessageType type)
        {
            message = $"{type.ToString()} - {message} - {DateTime.Now}";
            return new Messaging.Message { type = type, message = message };
        }


        public void setCommandArgs(string[] args)
        {
            if(args != null && args.Length > 0 && args[0] == "-j")
            {
                this._loadJson = true;

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

        public int executeSaveAsUserSettings(bool overrideAutoSaveSetting)
        {
            return -1;
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
            JsonService.Export(this.ContainerList);
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
                if(this.ContainerList == null || this.ContainerList.Items.Count() != 26)
                {


                    this._containerList = new GestureFactory();
                    JsonService.Import(this._containerList);



                }
                return this.ContainerList.Items;
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



            GlobalHotKey.removeAllRegistration();
            this.registerHotKeys(this.Containers);

            this._main.updateUI(Current as JohnBPearson.Application.Gestures.Model.GestureObject);
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
