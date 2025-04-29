
using System;
using System.Collections.Generic;
using System.Linq;
using JohnBPearson.Application.Gestures.Model;
using log4net.Util;

namespace JohnBPearson.Application.Gestures.Model.Utility
{
    internal class Parser
    {



        private class Resurrect
        {

            const int Delimiter = 25;


            internal Resurrect()
            {
            }
        
        }

        private IContainerList _parent;
        internal Parser(KeyAndDataStringLiterals strings, IContainerList parent)
        {

            this._valuesString = strings.Values;

            this._keysString = strings.Keys;
            this._descriptionString = strings.Descriptions;
            this._secured = strings.Secured;
            this._parent = parent;

        }

        private string _keysString;
        private string _valuesString;
        private string _descriptionString;
        private IEnumerable<string> _secured;

        private List<JohnBPearson.Application.Gestures.Model.IContainer> _items;

        internal List<JohnBPearson.Application.Gestures.Model.IContainer> Items
        {
            get
            {
                this.hydrateItems(this._items);
                return this._items;
            }
            private set { this._items = value; }
        }

        private List<string> _keys;

        internal List<string> Keys
        {
            get
            {
                this.hydrateItems(this._items);
                return this._keys;
            }
            private set { _keys = value; }
        }

        private List<IContainer> hydrateItems(List<IContainer> items)
        {
            if(items == null)
            {
                items = parse();
            }
            return items;
        }
        internal static IEnumerable<string> parseStringToList(string value, char delim)
        {
            var list = new List<string>();

            if (value.Contains(delim))
            {
                var arr = new List<char>();
                    arr.Add(delim);
                    
                  list.AddRange(  value.Split(arr.ToArray(), StringSplitOptions.None));
                return list;
            }


            throw new ArgumentException(string.Concat( delim, " was not found in  ", value));
        }

        private List<JohnBPearson.Application.Gestures.Model.IContainer> parse()
        {

            var securedArray = this._secured.ToArray();
            string[] delims = { delim };
            var resultList = new List<IContainer>();
            //   var letters = this._keysString.Split(delims, 100, StringSplitOptions.None).Clone();
            var letters = this._keysString.Split(delimChar).Clone();
            var values = this._valuesString.Split(delimChar);
            // TODO: fxi so there are no null from here
            var descriptions = this._descriptionString.Split(delimChar);
            this._keys = (letters as string[]).ToList();
            var index = 0;
            var protectedItems = PropertiesDictionary.
            foreach (var key in this._keys)
            {
                if (index < values.Length)
                {
                    var value = values[index];
                    var des = descriptions[index];
                    var isSecuredStrinh = securedArray[index];
                    bool isSecure = false;                       
                    if(!string.IsNullOrWhiteSpace(isSecuredStrinh)) {
                        isSecure =   bool.Parse(isSecuredStrinh);
                    }
                   
                    var hkv = JohnBPearson.Application.Gestures.Model.Container.Create(this._parent,key[0], value, des, isSecure);
                    resultList.Add(hkv);
                    index++;
                }
                else
                {
                    break;
                }

            }
            checkAndRepairValuesArray(values);
            checkAndRepairValuesArray(descriptions);

            return resultList;
        }

        private string[] checkAndRepairValuesArray(string[] values)
        {
            if (values.Length < 26)
            {
             var needToAdd = 26- values.Length;
                
                for (int i = 0; i < needToAdd; i++)
                {
                    values.Append("");
                }
            }
            return values;
        }

        private const string delim = "|";
        private const char delimChar = '|';
        //internal KeyAndDataStringLiterals updateStrings(List<JohnBPearson.Application.Model.IContainer> items)
        //{
        //    var result = 0;
        //    var tempKeys = new List<string>();
        //    var tempValues = new List<string>();
        //    var tempDescs = new List<string>();
        //    var values = new StringBuilder();
           
        //    foreach (var item in this.Items)
        //    {
        //        if (item.ObjectState != ObjectState.Deleted)
        //        {
        //            if (!item.setIfLastItem()) { 
        //            tempKeys.Add(item.Alpha.GetDeliminated());
        //                tempValues.Add(item.Data.GetDeliminated());
        //                tempDescs.Add(item.Description.GetDeliminated());
        //            }else
        //            {
        //                tempKeys.Add(item.Alpha.Value);
        //                tempValues.Add(item.Data.Value);
        //                tempDescs.Add(item.Description.Value);
        //            }
        //        }
        //        if(item.ObjectState == ObjectState.Changed)
        //        {
        //            result++;
        //        }
        //        else if(item.ObjectState == ObjectState.Deleted)
        //        {
        //            tempKeys.Add(item.Alpha.GetDeliminated());
        //            tempValues.Add(item.Data.GetDeliminated());
        //            tempDescs.Add(item.Description.GetDeliminated());
        //        }
        //    }
        //    var strings = new KeyAndDataStringLiterals();
          
        //    strings.Keys = tempKeys.ToString();
        //    strings.Descriptions = tempDescs.ToString();
        //    strings.Values = this.checkAndRepairValuesArray(tempValues.ToArray()).ToString();
            
        //    return strings;
        //}


    }
}


