//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.NetworkInformation;
//using System.Text;
//using System.Threading.Tasks;

//namespace JohnBPearson.KeyBindingButler.Model
//{
//    internal class OneStringParser
//    {
//        private IKeyBoundDataList _parent;

//        public OneStringParser(string settingString,IKeyBoundDataList parent)
//        {
//            this._settingString = settingString;
//            //this._valuesString = strings.Values;

//            //this._keysString = strings.Keys;
//            this._parent = parent;
//        }

      
//        private string _settingString = "";

//        private List<JohnBPearson.KeyBindingButler.Model.IKeyBoundData> _items;

//        public List<JohnBPearson.KeyBindingButler.Model.IKeyBoundData> Items
//        {
//            get
//            {
//                if (this._items == null)
//                {
//                    this.setParsed(this._parent);
//                }
//                return this._items;
//            }
//            private set { this._items = value; }
//        }

//        private List<string> _keys;

//        public List<string> Keys
//        {
//            get
//            {
//                if (this._keys == null)
//                {
//                    this.setParsed(this._parent);
//                }
//                return this._keys;
//            }
//            private set { _keys = value; }
//        }

//        private void setParsed(IKeyBoundDataList parent)
//        {
//            this.initializeLazyLoad();
//            this._items = this.parse(parent);

//        }

//        private void initializeLazyLoad()
//        {
//            this._keys = new List<string>();
//            this._items = new List<IKeyBoundData>();
//        }
//        private List<JohnBPearson.KeyBindingButler.Model.IKeyBoundData> parse(IKeyBoundDataList parent)
//        {
            
//           // string[] delims = { delim };
//            var resultList = new List<IKeyBoundData>();
//            //   var letters = this._keysString.Split(delims, 100, StringSplitOptions.None).Clone();
//            char[] delimChars = { delimChar };
//            char[] itemDelims = { itemDelimiterChar };

//            var splitString = this._settingString.Split(delimChars, StringSplitOptions.RemoveEmptyEntries);

//            foreach( var split in splitString )
//            {
//                var keyValue = split.Split(itemDelims, StringSplitOptions.RemoveEmptyEntries);
//                if (!string.IsNullOrWhiteSpace(keyValue[0]))
//                {
//                    var data = "";
//                    if (!string.IsNullOrWhiteSpace(keyValue[1]))
//                    {
//                       data = keyValue[1];
//                    }
//                    var pair = Container.Create(, keyValue[0].ToCharArray()[0], data);
//                    if(this.Keys == null)
//                    {
//                        this.Keys = new List<string>();
//                    }
//                    this.Keys.Add(keyValue[0]);
//                    if(this.Items == null)
//                    {
//                        this.Items = new List<IKeyBoundData>();
//                    }
//                    this.Items.Add(pair);
//                }

//            }
//            //var letters = this.Split(delimChars, StringSplitOptions.RemoveEmptyEntries).Clone();
//            //var values = this._valuesString.Split(delimChars, StringSplitOptions.RemoveEmptyEntries).Clone();
//            //this._keys = (letters as string[]).ToList();
//            //var index = 0;
//            //var valuesTyped = values as string[];
//            //foreach (var key in this._keys)
//            //{
//            //    if (index < 26)
//            //    {
//            //        var value = valuesTyped[index];
//            //        var hkv = JohnBPearson.KeyBindingButler.Model.Container.Create(key[0], value);
//            //        resultList.Add(hkv);
//            //        index++;
//            //    }
//            //    else
//            //    {
//            //        break;
//            //    }

//            //}

//            return this.Items;
//        }
//        //private const string delim = "|";
//        private const char delimChar = '|';
//        private const char itemDelimiterChar = ',';
//        internal string updateString(List<JohnBPearson.KeyBindingButler.Model.IKeyBoundData> items)
//        {
//            var result = 0;

//            var sbResult = new StringBuilder();

          
//            foreach (var item in this.Items)
//            {
//                //if (item.IsDirty)
//                //{
//                //    result++;

//                //}
//                sbResult.Append(item.GetDelimitated());
//                //tempKeys.Add(item.KeyInfo.ToString());
//                //tempValues.Add(item.Data.ToString());
//            }
//           // var strings = new KeyAndDataStringLiterals();
//            //strings.Keys = tempKeys.ToString();
//            //strings.Values = tempValues.ToString();
//            return sbResult.ToString();
//        }


//    }
//}
