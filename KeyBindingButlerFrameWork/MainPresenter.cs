using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using JohnBPearson.KeyBindingButler.Model;
using JohnBPearson.KeyBindingButler.Model.KeyBinding;
using JohnBPearson.Windows.Interop;


namespace JohnBPearson.Windows.Forms.KeyBindingButler
{
    public interface IPresenterBase : INotifyPropertyChanged
    {

    }


    public class MainPresenter : IPresenter<Main>
    {
        private JohnBPearson.KeyBindingButler.Model.ContainerList _containerList;
        private Main _main;
        public Main Form { get { return this._main; } set { this._main = value; } }

        public ContainerList ContainerList { get { return this._containerList; } }
        public void updateContainer(string newValue, string newDescription, string selectedKey, bool isSecured = false)
        {
            var itemToUpdate = this.findKeyBoundValue(selectedKey);
            if (itemToUpdate != null)
            {
                this.updateItem(itemToUpdate, newValue, newDescription, isSecured);
            }
            else
            {
                throw new System.ArgumentException($"cannot find object for key: {selectedKey} ", "selectedKey");
            }
        }

        private void updateItem(JohnBPearson.KeyBindingButler.Model.IContainer oldItem, string newData, string description, bool isSecured)
        {
            oldItem.Update(ref newData, description, isSecured);
            GlobalHotKey.removeAllRegistration();
            registerHotKeys(ContainerList.Items);
        }

        public int executeAutoSave(bool overrideAutoSaveSetting, string encryptionFlags, bool encrypt)
        {
            var strings = this.ContainerList.PrepareDataForSave();
            Properties.Settings.Default.BindableValues = strings.Values;
            Properties.Settings.Default.Descriptions = strings.Descriptions;
            Properties.Settings.Default.isSecured.Clear();
            Properties.Settings.Default.isSecured.AddRange(strings.Secured.ToArray());
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
                if (this.ContainerList == null)
                {
                    this.LoadHotKeyValues();

                }
                return this.ContainerList.Keys;
            }
        }
        public IEnumerable<JohnBPearson.KeyBindingButler.Model.IContainer> Containers
        {
            get
            {
                if (this.ContainerList == null)
                {
                    LoadHotKeyValues();
                }
                return this.ContainerList.Items;
            }

        }



        public JohnBPearson.KeyBindingButler.Model.IContainer findKeyBoundValue(string keyValue)
        {
            return this.Containers.ToList().Find((item) => { return item.Key.Value == keyValue; });

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
            string[] arr = new string[26];
            Properties.Settings.Default.isSecured.CopyTo(arr, 0);
            strings.Secured = arr.AsEnumerable<string>();
            this._containerList = new JohnBPearson.KeyBindingButler.Model.ContainerList(strings);
            return this.ContainerList;
        }


        public void registerHotKeys(IEnumerable<JohnBPearson.KeyBindingButler.Model.IContainer> keys)
        {
            GlobalHotKey.removeAllRegistration();

            var index = 0;
            GlobalHotKey.removeAllRegistration();
            var result = new StringBuilder();
            foreach (var item in keys)
            {


                var sb = new StringBuilder();
                sb.Append(Properties.Settings.Default.KeyBindingModifiers);
                sb.Append(item.KeyAsChar);
                var del = new KeyBindCallBack(this._main.hotKeyCallBack);
                GlobalHotKey.RegisterHotKey(sb.ToString(), item, del);
                result.Append($"{item.Key}, ");




                index++;
            }
        }
    }



    public interface IPresenter<T>
    {
        T Form { get; }
        IEnumerable<JohnBPearson.KeyBindingButler.Model.IContainer> Containers { get; }
        int executeAutoSave(bool overrideAutoSaveSetting, string encryptionFlags, bool encrypt);

        void updateContainer(string newData, string description, string key, bool isSecured);


        JohnBPearson.KeyBindingButler.Model.IContainer findKeyBoundValue(string keyValue);
    }





}
