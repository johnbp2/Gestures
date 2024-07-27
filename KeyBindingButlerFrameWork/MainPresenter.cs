using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Navigation;
using JohnBPearson.KeyBindingButler.Model;
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


        public void updateItem(IKeyBoundData oldItem, string newData, string description)
        {
            oldItem.Update(newData, description);
            GlobalHotKey.removeAllRegistration();
            registerHotKeys(keyBoundValueList.Items);
        }
        
        public int executeAutoSave(bool overrideAutoSaveSetting, string encryptionFlags, bool encrypt)
        {
            var strings = this.keyBoundValueList.PrepareDataForSave(encryptionFlags, encrypt);
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
        private KeyBoundDataList LoadHotKeyValues()
        {
            var strings = new KeyAndDataStringLiterals();
            strings.Values = Properties.Settings.Default.BindableValues;
            strings.Keys = Properties.Settings.Default.BindableKeys;
            strings.Descriptions = Properties.Settings.Default.Descriptions;
            this.keyBoundValueList = new JohnBPearson.KeyBindingButler.Model.KeyBoundDataList(strings);
            return this.keyBoundValueList;
        }


        private void registerHotKeys(IEnumerable<JohnBPearson.KeyBindingButler.Model.IKeyBoundData> keys)
        {
            var index = 0;
            foreach (var item in keys)
            {


                var sb = new StringBuilder();
                sb.Append(Properties.Settings.Default.KeyBindingModifiers);
                sb.Append(item.KeyAsChar);
                var callBack = new KeyBindCallBack(_main.hotKeyCallBack);
                GlobalHotKey.RegisterHotKey(sb.ToString(), item, callBack);





                index++;
            }
        }
    }



    public interface IPresenter<T>
    {
        T Form { get; }

        int executeAutoSave(bool overrideAutoSaveSetting, string encryptionFlags, bool encrypt);
    }





}
