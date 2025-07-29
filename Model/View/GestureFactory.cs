using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Configuration;
using JohnBPearson.Application.Gestures.Model.Domain;
using JohnBPearson.Application.Gestures.Model.Utility;

namespace JohnBPearson.Application.Gestures.Model
{
    public class GestureFactory : IGestureFactory
    {

        private Utility.Parser _userSettingsParser;
        private List<IGestureObject> _items = new List<IGestureObject>();
        private const string deliminater = "|";
        private List<Domain.Entities.DomainGesture> _importBackUpItems;
        private List<string> _keys;
        public IEnumerable<string> Keys
        {
            get
            {
                if(this._items != null)
                {
                    if(this._keys == null)
                    {
                        this._keys = (from item in this._items select item.Key.Value).ToList();
                    }
                    
                }
                
                    return this._keys;
            }
        }
        public IEnumerable<IGestureObject> Items
        {
            get
            {
                return this._items;
            }
        }

        public GestureFactory()
        {
        
        }

        public GestureFactory(Utility.Dto strings)
        {
            this._userSettingsParser = new Utility.Parser(strings, this);
            this._items = this._userSettingsParser.Items;

        }

        public IList<IGestureObject> GetItems()
        {
            return this._items;
        }


        public Utility.Dto PrepareDataForSave()
        {
            return prepareForSaveInner(_items);
        }

        public int Modified
        {
            get;
            private set;
        }

        private Utility.Dto prepareForSaveInner(IEnumerable<IGestureObject> items)
        {
          //  var values = new StringBuilder();
            //var descriptions = new StringBuilder();
            //  var secured = new List<string>();
            List<bool> isProtected = new List<bool>();
            List<bool> Protect = new List<bool>();
            List<string> hexStrings = new List<string>();
            List<int> dataLength = new List<int>();
                 List<string> data = new List<string>();
            List<string> description = new List<string>();
            int count = 0;
            foreach(var item in items)

            {
                //  var data = string.Empty;
                if(!item.Data.isProtected || item.Data.HexString.Length == 0)
                {
                    data.Add(item.Data.Value);
                }
                else
                {
                    data.Add(string.Empty);
                }
                isProtected.Add(item.Data.isProtected);
                description.Add(item.Description.Value);
               // Protect.Add(item.Data.Protect);
              //  descriptions.Append(item.Description.GetDeliminated());
                //values.Append(BaseValue.GetDeliminatedData(data));
                // always add hexstring every time else we lose the position
                // in the array that tells us which
                // key a-z this value belongs with. 
                //if(item.Data.isProtected)
                //{
                    hexStrings.Add(item.Data.HexString);
                //}
                dataLength.Add(item.Data.Length);
                if(item.ObjectState == ObjectState.Changed)
                {
                    count++;
                }

            }
            this.Modified = count;
            var result = new Utility.Dto();
         //   result.Values = values.ToString();
           // result.Descriptions = descriptions.ToString();
            result.ItemsUpdated = count;
            result.IsProtected = isProtected;
            result.Protect = Protect;
            result.HexStrings = hexStrings;
            result.DataLengths = dataLength;
            result.Data = data.ToArray();
            result.Description = description.ToArray();
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
        public IGestureFactory Replace(IGestureObject oldItem, IGestureObject newItem)
        {
            int index = this.findIndex(oldItem as GestureObject);

            this._items.RemoveAt(index);
            this._items.Insert(index, newItem);
            return this;
        }

        public static List<bool> ParseStringsToBools(System.Collections.Specialized.StringCollection items)
        {
            return Utility.Parser.parseStringsToBools(items);

        }


        internal int findIndex(GestureObject searchItem)
        {
            return this._items.FindIndex((itemToCheck) => { return itemToCheck.Equals(searchItem); });

        }

        public void import()
        {
        
        }

        public List<Domain.Entities.DomainGesture> MapToEntities()
        {
            var list = new List<Domain.Entities.DomainGesture>();
       
            foreach(var item in _items)
            {
                var concreteItem = item as GestureObject;
                list.Add(concreteItem.MapToEntity());
            }
            return list;
        }




        public void MapFromEntities(List<Domain.Entities.DomainGesture> entities)
        {
            // this._importBackUpItems = this.MapFromEntities(entities);
            this._items = new List<IGestureObject>();

            foreach(var entity in entities)
            {
                this._items.Add(GestureObject.Create(this, entity));
            }



            
        }
    }
}