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
        private JohnBPearson.Application.Gestures.Model.IContainer _current;

        public JohnBPearson.Application.Gestures.Model.IContainer Current
        {
            get
            {
                return _current;
            }
        }
        public void updateContainer(string newValue, string newDescription, string selectedKey, bool protect)
        {
            var itemToUpdate = this.findKeyBoundValue(selectedKey);
            if(itemToUpdate != null)
            {
                if(itemToUpdate.Description.Value != newDescription || itemToUpdate.Data.Value != newValue
                    )
                {

                    this.updateContainerInner(itemToUpdate, newValue, newDescription, protect);
                }
            }
            else
            {
                throw new System.ArgumentException($"cannot find object for key: {selectedKey} ", "selectedKey");
            }
        }

        private void updateContainerInner(JohnBPearson.Application.Gestures.Model.IContainer oldItem, string newData, string description, bool protect)
        {
            var newItem = JohnBPearson.Application.Gestures.Model.Container.Create(this.ContainerList, oldItem.KeyAsChar, newData, description, oldItem.Data.isProtected, protect);

            this.ContainerList.Replace(oldItem, newItem);
            GlobalHotKey.removeAllRegistration();
            registerHotKeys(ContainerList.Items);
            this.Form.bindDropDownKeyValues();
            this.Form.updateUIByKey(newItem.KeyAsChar);

        }

        public int executeSave(bool overrideAutoSaveSetting)
        {
            var strings = this.ContainerList.PrepareDataForSave();
            Properties.Settings.Default.BindableValues = strings.Values;
            Properties.Settings.Default.Descriptions = strings.Descriptions;
            Properties.Settings.Default.IsProtected.Clear();
            Properties.Settings.Default.IsProtected = ContainerList.ParseBoolsToStrings(strings.IsProtected);
            Properties.Settings.Default.Protect = ContainerList.ParseBoolsToStrings(strings.Protect);
            Properties.Settings.Default.Save();
            this.LoadHotKeyValues();
            GlobalHotKey.removeAllRegistration();
            this.registerHotKeys(this.ContainerList.Items);
            return 0;
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



        public JohnBPearson.Application.Gestures.Model.IContainer findKeyBoundValue(string keyValue, bool setToCurrent = false)
        {
            var currentItem = this.Containers.ToList().Find((item) => { return item.Key.Value == keyValue; });
            if(setToCurrent)
            {
                this._current = currentItem;
            }
            return currentItem;
        }

        public void RefreshData()
        {

            this.LoadHotKeyValues();

            GlobalHotKey.removeAllRegistration();
            this.registerHotKeys(this.Containers);
        }
        private ContainerList LoadHotKeyValues()
        {
            var strings = new KeyAndDataStringLiterals();
            strings.Values = Properties.Settings.Default.BindableValues;
            strings.Keys = Properties.Settings.Default.BindableKeys;
            strings.Descriptions = Properties.Settings.Default.Descriptions;

            strings.Protect = ContainerList.ParseStringsToBools(Properties.Settings.Default.Protect);

            strings.IsProtected = ContainerList.ParseStringsToBools(Properties.Settings.Default.IsProtected);
            strings.DataLengths = ContainerList.paresStringsToInts(Properties.Settings.Default.DataLength);
            strings.ByteStrings = Properties.Settings.Default.ByteStrings.Cast<string>().ToList();
            string[] arr = new string[26];

            this._containerList = new JohnBPearson.Application.Gestures.Model.ContainerList(strings);
            return this.ContainerList;
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
