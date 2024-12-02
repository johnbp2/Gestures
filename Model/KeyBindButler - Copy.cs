using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JohnBPearson.com.Utility;

namespace JohnBPearson.KeyBindingButler.Model
{

    public class KeyBindingButler : ButlerBase
    {

        private Parser _userSettingsHelper;
        private List<IKeyBoundValue> _items = new List<IKeyBoundValue>();

        public KeyBindingButler(KeyAndValuesStringLiterals strings, string hisName) : base(hisName)
        {
            this._userSettingsHelper = new Parser(strings);
            this._items = this._userSettingsHelper.Items;

        }

        public IEnumerable<string> Keys
        {
            get
            {
                if (this._userSettingsHelper != null)
                {
                    return this._userSettingsHelper.Keys;
                }
                else return null;
            }
        }
        public IEnumerable<IKeyBoundValue> Items
        { get { return this._items; } }

        public void Replace(IKeyBoundValue newItem, IKeyBoundValue oldItem)
        {


            var newKeyBoundValue = KeyBoundValue.CreateForReplace(newItem.Value, oldItem);
            var index = this._items.IndexOf(oldItem);
            this._items.RemoveAt(index);
            this._items[index] = newItem;
            //  return this._items;
        }

        public KeyAndValuesStringLiterals PrepareDataForSave()
        {
            var sbKeys = new StringBuilder();
            var sbValues = new StringBuilder();
            int count = 0;
            foreach (var item in _items)
            {
                if (item.IsDirty) count++;

                sbKeys.Append(item.Key.ToString());
                sbValues.Append(item.Value.ToString());
            }
            var result = new KeyAndValuesStringLiterals();
            result.Values = sbValues.ToString();
            result.Keys = sbKeys.ToString();
            result.ItemsUpdated = count;
            return result;
        }
    }
}

