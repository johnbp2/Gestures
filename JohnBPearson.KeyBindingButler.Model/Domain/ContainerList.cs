using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using JohnBPearson.com.Utility;

namespace JohnBPearson.Application.Model
{
    public class ContainerList : IContainerList
    {

        private Parser _userSettingsParser;
        private List<IContainer> _items = new List<IContainer>();
        private const string deliminater = "|";
        private List<IContainer> _importBackUpItems;

        public ContainerList(KeyAndDataStringLiterals strings)
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
        public IEnumerable<IContainer> Items
        { get { return this._items; } }


        public IList<IContainer> GetItems() { return this._items; }
        //public void Replace(IKeyBoundData newItem, IKeyBoundData oldItem)
        //{


        //    var newKeyBoundValue = Container.CreateForReplace(newItem.Data, oldItem);
        //    var index = this.items.IndexOf(oldItem);
        //    this.items.RemoveAt(index);
        //    this.items[index] = newItem;
        //    //  return this.items;
        //}

        public KeyAndDataStringLiterals ImportForSave(IEnumerable<IContainer> items)
        {
            this._importBackUpItems = new List<IContainer>(items);
       return this.prepareForSaveInner(items);
        }

        public KeyAndDataStringLiterals PrepareDataForSave()
        {
            return prepareForSaveInner();
        }

        private KeyAndDataStringLiterals prepareForSaveInner()
        {
            return prepareForSaveInner(_items);
        }

        private KeyAndDataStringLiterals prepareForSaveInner(IEnumerable<IContainer> items)
        {
            var values = new StringBuilder();
            var descriptions = new StringBuilder();
            var secured = new List<string>();
            int count = 0;
            foreach(var item in items)

            {
                var data = string.Empty;
                if(item.IsDataSecured)
                {
                    data = item.Secured.Secured;
                }
                else
                {
                    data = item.Data.Value;
                }

                descriptions.Append(item.Description.GetDeliminated());
                values.Append(BaseData.GetDeliminatedData(data));
                secured.Add(item.IsDataSecured.ToString());
                if(item.ObjectState == ObjectState.Mutated)
                {
                    count++;
                }

            }
            var result = new KeyAndDataStringLiterals();
            result.Values = values.ToString();
            result.Descriptions = descriptions.ToString();
            result.ItemsUpdated = count;
            result.Secured = secured;
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

        private string buildSaveString(IContainer item)
        {
            return String.Concat(item.Key.GetDeliminated(), item.Data, ContainerList.deliminater);
        }

        internal int findIndex(Container searchItem)
        {
            return this._items.FindIndex((itemToCheck) => { return itemToCheck.Equals(searchItem); });

        }
    }
}