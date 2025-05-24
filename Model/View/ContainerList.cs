using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using JohnBPearson.Application.Gestures.Model.Domain;
using JohnBPearson.Application.Gestures.Model.Utility;

namespace JohnBPearson.Application.Gestures.Model
{
    public class ContainerList : IContainerList
    {

        private Utility.Parser _userSettingsParser;
        private List<IContainer> _items = new List<IContainer>();
        private const string deliminater = "|";
        private List<Domain.Entities.ContainerEntity> _importBackUpItems;
        public IEnumerable<string> Keys
        {
            get
            {
                if(this._userSettingsParser != null)
                {
                    return this._userSettingsParser.Keys;
                }
                else
                    return null;
            }
        }
        public IEnumerable<IContainer> Items
        {
            get
            {
                return this._items;
            }
        }



        public ContainerList(Utility.KeyAndDataStringLiterals strings)
        {
            this._userSettingsParser = new Utility.Parser(strings, this);
            this._items = this._userSettingsParser.Items;

        }

        public IList<IContainer> GetItems()
        {
            return this._items;
        }


        public Utility.KeyAndDataStringLiterals PrepareDataForSave()
        {
            return prepareForSaveInner(_items);
        }



        private Utility.KeyAndDataStringLiterals prepareForSaveInner(IEnumerable<IContainer> items)
        {
            var values = new StringBuilder();
            var descriptions = new StringBuilder();
            //  var secured = new List<string>();
            List<bool> isProtected = new List<bool>();
            List<bool> Protect = new List<bool>();
            int count = 0;
            foreach(var item in items)

            {
                var data = string.Empty;

                data = item.Data.Value;

                isProtected.Add(item.Data.isProtected);
                Protect.Add(item.Data.Protect);
                descriptions.Append(item.Description.GetDeliminated());
                values.Append(BaseValue.GetDeliminatedData(data));
                // secured.Add(item.IsDataSecured.ToString());
                if(item.ObjectState == ObjectState.Changed)
                {
                    count++;
                }

            }
            var result = new Utility.KeyAndDataStringLiterals();
            result.Values = values.ToString();
            result.Descriptions = descriptions.ToString();
            result.ItemsUpdated = count;
            result.IsProtected = isProtected;
            result.Protect = Protect;
            return result;
        }


        public static List<int> paresStringsToInts(System.Collections.Specialized.StringCollection items)
        {
            return Parser.parseStringsToInts(items);
        }
        public static System.Collections.Specialized.StringCollection ParseBoolsToStrings(IEnumerable<bool> items)
        {
            return Utility.Parser.parseBoolsToString(items);


        }
        public IContainerList Replace(IContainer oldItem, IContainer newItem)
        {
            int index = this.findIndex(oldItem as Container);

            this._items.RemoveAt(index);
            this._items.Insert(index, newItem);
            return this;
        }

        public static List<bool> ParseStringsToBools(System.Collections.Specialized.StringCollection items)
        {
            return Utility.Parser.parseStringsToBools(items);

        }


        internal int findIndex(Container searchItem)
        {
            return this._items.FindIndex((itemToCheck) => { return itemToCheck.Equals(searchItem); });

        }

        public void import()
        {
        
        }

        public List<Domain.Entities.ContainerEntity> MapToEntities()
        {
            var list = new List<Domain.Entities.ContainerEntity>();
            foreach(var item in _items)
            {
                var concreteItem = item as Container;
                list.Add(concreteItem.MapToEntity());
            }
            return list;
        }




        public void MapFromEntities(List<Domain.Entities.ContainerEntity> entities)
        {
            // this._importBackUpItems = this.MapFromEntities(entities);
            this._items = new List<IContainer>();

            foreach(var entity in entities)
            {
                this._items.Add(Container.Create(this, entity));
            }



            
        }
    }
}