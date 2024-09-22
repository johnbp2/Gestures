using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using JohnBPearson.com.Utility;

namespace JohnBPearson.KeyBindingButler.Model
{
    public class KeyBoundDataList : IKeyBoundDataList
    {

        private Parser _userSettingsParser;
        private List<IKeyBoundData> _items = new List<IKeyBoundData>();
        private const string deliminater = "|";

        public KeyBoundDataList(KeyAndDataStringLiterals strings)
        {
            this._userSettingsParser = new Parser(strings, this);
            this._items = this._userSettingsParser.Items;

        }

        public IEnumerable<string> Keys
        {
            get
            {
                if (this._userSettingsParser != null)
                {
                    return this._userSettingsParser.Keys;
                }
                else return null;
            }
        }
        public IEnumerable<IKeyBoundData> Items
        { get { return this._items; } }

        //public void Replace(IKeyBoundData newItem, IKeyBoundData oldItem)
        //{


        //    var newKeyBoundValue = KeyBoundData.CreateForReplace(newItem.Data, oldItem);
        //    var index = this._items.IndexOf(oldItem);
        //    this._items.RemoveAt(index);
        //    this._items[index] = newItem;
        //    //  return this._items;
        //}

        public KeyAndDataStringLiterals PrepareDataForSave(string encryptionFlags, bool encrypt)
        {

            var values = new StringBuilder();
            var descriptions = new StringBuilder();
            int count = 0;
            foreach (var item in _items)
            {//if (item.IsDirty) count++;                        
                var data = item.Data.Value;
                if (encrypt)2
                {
                    var list = new SettingToList(encryptionFlags).List;
                    foreach (var compare in list)
                    {
                        if ()
                        {
                            data = Cypher.Aes.AesCypher.LockString(item.Description.Value);
                            break;
                        }
                    }
                }
                descriptions.Append(item.Description.GetDeliminated());
                values.Append(BaseData.GetDeliminatedData(data));
                if(item.ObjectState == ObjectState.Mutated)
                {
                    count++;
                }

            }
            var result = new KeyAndDataStringLiterals();
            result.Values = values.ToString();
            result.Descriptions = descriptions.ToString();
            result.ItemsUpdated = count;
            return result;
        }

        public string PrepareDataToSaveAsOneSetting()
        {
            var sbOneString = new StringBuilder();
            foreach (var item in _items)
            {
                sbOneString.Append(this.buildSaveString(item));


            }
            return sbOneString.ToString();
        }

        private string buildSaveString(IKeyBoundData item)
        {
            return String.Concat(item.Key.GetDeliminated(), item.Data, KeyBoundDataList.deliminater);
        }

        internal int findIndex(KeyBoundData searchItem)
        {
            return this._items.FindIndex((itemToCheck) => { return itemToCheck.Equals(searchItem); });

        }
    }
}