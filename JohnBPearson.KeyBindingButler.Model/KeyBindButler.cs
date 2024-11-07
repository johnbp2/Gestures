using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JohnBPearson.com.Utility;

namespace JohnBPearson.Application.Model
{

    public enum ToastOptions
    {
    All,
    Save,
    Hotkey,
    None
    }



   


    public class KeyBindingButler : ButlerBase
    {

        private Parser _userSettingsParser;
        private List<IContainer> _items = new List<IContainer>();

        public KeyBindingButler(KeyAndDataStringLiterals strings, string hisName, IContainerList dataList = null) : base(hisName)
        {

            if(dataList != null)
            {

                this._userSettingsParser = new Parser(strings, dataList);
                this._items = this._userSettingsParser.Items;
            }
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
        public IEnumerable<IContainer> Items
        { get { return this._items; } }

        

        public KeyAndDataStringLiterals PrepareDataForSave()
        {
            var sbKeys = new StringBuilder();
            var sbData = new StringBuilder();
            int count = 0;
            foreach (var item in _items)
            {
             //   if (item.IsDirty) count++;

                sbKeys.Append(item.Key.ToString());
                sbData.Append(item.Data.ToString());
            }
            var result = new KeyAndDataStringLiterals();
            result.Values = sbData.ToString();
            result.Keys = sbKeys.ToString();
            result.ItemsUpdated = count;
            return result;
        }
    }
}

