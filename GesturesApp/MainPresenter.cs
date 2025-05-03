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


namespace JohnBPearson.Windows.Forms.Gestures
{
    public interface IPresenterBase : INotifyPropertyChanged
    {

    }


    public class MainPresenter : IPresenter<Main>
    {
        private JohnBPearson.Application.Gestures.Model.ContainerList _containerList;
        private Main _main;
        public Main Form { get { return this._main; } set { this._main = value; } }

        public ContainerList ContainerList { get { return this._containerList; } }
        public void updateContainer(string newValue, string newDescription, string selectedKey, bool isSecured = false)
        {
            var itemToUpdate = this.findKeyBoundValue(selectedKey);
            if(itemToUpdate != null)
            {
                if(itemToUpdate.Description.Value != newDescription || itemToUpdate.Data.Value != newValue
                    || itemToUpdate.IsDataSecured != isSecured)
                {

                    this.updateContainerInner(itemToUpdate, newValue, newDescription, isSecured);
                }
            }
            else
            {
                throw new System.ArgumentException($"cannot find object for key: {selectedKey} ", "selectedKey");
            }
        }

        private void updateContainerInner(JohnBPearson.Application.Gestures.Model.IContainer oldItem, string newData, string description, bool isSecured)
        {
            oldItem.Update(ref newData, description, isSecured);
            GlobalHotKey.removeAllRegistration();
            registerHotKeys(ContainerList.Items);
        }

        public int executeSave(bool overrideAutoSaveSetting)
        {
            var strings = this.ContainerList.PrepareDataForSave();
            Properties.Settings.Default.BindableValues = strings.Values;
            Properties.Settings.Default.Descriptions = strings.Descriptions;
            Properties.Settings.Default.IsProtected.Clear();
            Properties.Settings.Default.IsProtected.AddRange(strings.IsProtected.ToArray());
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
        public IEnumerable<JohnBPearson.Application.Gestures.Model.IContainer> Containers
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



        public JohnBPearson.Application.Gestures.Model.IContainer findKeyBoundValue(string keyValue)
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
            var protectValues = Properties.Settings.Default.Protect;
         strings.Protect =   parseStringsToBools(protectValues);
            var isProtectedValues = Properties.Settings.Default.IsProtected;
            strings.IsProtected = =parseStringsToBools(isProtectedValues);
            string[] arr = new string[26];
            Properties.Settings.Default.IsProtected.CopyTo(arr, 0);
            strings.IsProtected = arr.AsEnumerable<string>();
            this._containerList = new JohnBPearson.Application.Gestures.Model.ContainerList(strings);
            return this.ContainerList;
        }

        private static List<bool> parseStringsToBools(System.Collections.Specialized.StringCollection protectedValues)
        {
            List<bool> listBool = new List<bool>();
            foreach(string booleanValue in protectedValues)
            {
                bool temp = false;
                if(bool.TryParse(booleanValue, out temp))
                {
                    listBool.Add(temp);
                }
                else
                {

                    listBool.Add(false);

                }
            }
            return listBool;
        }

        public void registerHotKeys(IEnumerable<JohnBPearson.Application.Gestures.Model.IContainer> keys)
        {
            GlobalHotKey.removeAllRegistration();
32            var result = new StringBuilder();
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
        IEnumerable<JohnBPearson.Application.Gestures.Model.IContainer> Containers { get; }
        int executeSave(bool overrideAutoSaveSetting);

        void updateContainer(string newData, string description, string key, bool isSecured);


        JohnBPearson.Application.Gestures.Model.IContainer findKeyBoundValue(string keyValue);
    }





}
