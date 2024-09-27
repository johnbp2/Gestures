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
        private JohnBPearson.KeyBindingButler.Model.KeyBoundDataList keyBoundValueList;
        private Main _main;
        public Main Form { get { return this._main; }  set { this._main = value; } }


        public void updateItem(IKeyBoundData oldItem, string newData, string description,bool isSecured)
        {
                          oldItem.Update(ref newData, description, isSecured);
            GlobalHotKey.removeAllRegistration();
            registerHotKeys(keyBoundValueList.Items);
        }
        
        public int executeAutoSave(bool overrideAutoSaveSetting, string encryptionFlags, bool encrypt)
        {
            var strings = this.keyBoundValueList.PrepareDataForSave();
            Properties.Settings.Default.BindableValues = strings.Values;
            Properties.Settings.Default.Descriptions = strings.Descriptions;
            Properties.Settings.Default.Save();
            this.LoadHotKeyValues();
            GlobalHotKey.removeAllRegistration();
            this.registerHotKeys(this.keyBoundValueList.Items);
            return 0;
        }
        public IEnumerable<string> Keys
        {
            get
            {
                if (this.keyBoundValueList == null)
                {
                    this.LoadHotKeyValues();

                }
                return this.keyBoundValueList.Keys;
            }
        }
        public IEnumerable<JohnBPearson.KeyBindingButler.Model.IKeyBoundData> HotKeyValues
        {
            get
            {
                if (this.keyBoundValueList == null)
                {
                    LoadHotKeyValues();
                }
                return this.keyBoundValueList.Items;
            }

        }



        public IKeyBoundData findKeyBoundValue(string keyValue)
        {
          return  this.HotKeyValues.ToList<IKeyBoundData>().Find((item) => { return item.Key.Value == keyValue; });

        }

        public void RefreshData()
        {
            
            this.LoadHotKeyValues();

            GlobalHotKey.removeAllRegistration();
            this.registerHotKeys(this.HotKeyValues);
        }
        private KeyBoundDataList LoadHotKeyValues()
        {
            var strings = new KeyAndDataStringLiterals();
            strings.Values = Properties.Settings.Default.BindableValues;
            strings.Keys = Properties.Settings.Default.BindableKeys;
            strings.Descriptions = Properties.Settings.Default.Descriptions;
            this.keyBoundValueList = new JohnBPearson.KeyBindingButler.Model.KeyBoundDataList(strings);
            return this.keyBoundValueList;
        }


        public void registerHotKeys(IEnumerable<JohnBPearson.KeyBindingButler.Model.IKeyBoundData> keys)
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
         IEnumerable<JohnBPearson.KeyBindingButler.Model.IKeyBoundData> HotKeyValues { get; }
        int executeAutoSave(bool overrideAutoSaveSetting, string encryptionFlags, bool encrypt);

        void updateItem(IKeyBoundData oldItem, string newData, string description, bool isSecured);


        IKeyBoundData findKeyBoundValue(string keyValue);
    }
    




}
