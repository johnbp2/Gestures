using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using JohnBPearson.Application.Gestures.Model.Domain;
using JohnBPearson.Application.Gestures.Model.Utility;

namespace JohnBPearson.Application.Gestures.Model
{
    public class ContainerList : IContainerList
    {

        private Utility.Parser _userSettingsParser;
        private List<IContainer> _items = new List<IContainer>();
        private const string deliminater = "|";
        private List<Domain.Entities.Container> _importBackUpItems;

        public ContainerList(Utility.KeyAndDataStringLiterals strings)
        {
            this._userSettingsParser = new Utility.Parser(strings, this);
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


        //    var newKeyBoundValue = Containers.CreateForReplace(newItem.Data, oldItem);
        //    var index = this.items.IndexOf(oldItem);
        //    this.items.RemoveAt(index);
        //    this.items[index] = newItem;
        //    //  return this.items;
        //}

       // public Utility.KeyAndDataStringLiterals ImportForSave(IEnumerable<IContainer> items)
       // {
       //     this._importBackUpItems = new List<IContainer>(items);
       //return this.prepareForSaveInner(items);
       // }

        public Utility.KeyAndDataStringLiterals PrepareDataForSave()
        {
            return prepareForSaveInner();
        }

        private Utility.KeyAndDataStringLiterals prepareForSaveInner()
        {
            return prepareForSaveInner(_items);
        }

        private Utility.KeyAndDataStringLiterals prepareForSaveInner(IEnumerable<IContainer> items)
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
                values.Append(BaseValue.GetDeliminatedData(data));
                secured.Add(item.IsDataSecured.ToString());
                if(item.ObjectState == ObjectState.Changed)
                {
                    count++;
                }

            }
            var result = new Utility.KeyAndDataStringLiterals();
            result.Values = values.ToString();
            result.Descriptions = descriptions.ToString();
            result.ItemsUpdated = count;
            result.Secured = secured;
            return result;
        }

        public string PrepareDataToSaveAsOneSetting()
        {
            var sbOneString = new StringBuilder();
            foreach(var item in _items)
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

        public List<Domain.Entities.Container> MapToEnities()
        {
            var list = new List<Domain.Entities.Container>();
            foreach(var item in _items)
            {
                var concreteItem = item as Container;
                list.Add(concreteItem.MapToEntity());
            }
            return list;
        }

     

        public void MapFromEntities(List<Domain.Entities.Container> entities)
        {
            this._importBackUpItems = this.MapToEnities();
        var list = new List<IContainer>();

            foreach(var entity in entities)
            {
               list.Add( Container.Create(this, entity));
            }
           

          
            this._items = list;
        }
    }
}