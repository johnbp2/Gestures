
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Deployment.Internal;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Web.UI;
using System.Windows.Forms;
using JohnBPearson.Application.Gestures.Model;
using JohnBPearson.Application.Gestures.Model.Domain;
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

        private List<bool> _protect;

        internal List<bool> Protected
        {
            get
            {
                return _protect;
            }
            set
            {
                _protect = value;
            }
        }

        internal static System.Collections.Specialized.StringCollection parseBoolsToString(IEnumerable<bool> items)
        {
            var strings = new System.Collections.Specialized.StringCollection();
            foreach(var item in items)
            {
                strings.Add(item.ToString());
            }
            return strings;
        }
        internal static List<bool> parseStringsToBools(System.Collections.Specialized.StringCollection protectedValues)
        {
            List<bool> listBool = new List<bool>();
            foreach(string booleanValue in protectedValues)
            {
                bool temp = false;
                if(bool.TryParse(booleanValue, out temp))
                {
                    listBool.Add(temp);
                }
                else
                {

                    listBool.Add(false);

                }
            }
            return listBool;
        }

        private IGestureFactory _containerList;
        private List<int> _dataLengths;
        internal Parser(Dto strings, IGestureFactory parent)
        {

          //  this._valuesString = strings.Values;

          //  this._keysString = strings.Keys;
         //   this._descriptionString = strings.Descriptions;
            this._isProtected = strings.IsProtected;
            this._containerList = parent;
            this._protect = strings.Protect;
            this._hexStrings = strings.HexStrings;
            this._dataLengths = strings.DataLengths;
            this._dto = strings;

            this._data = strings.Data;
//this._key = strings.Key;
            this._description = strings.Description;
        }
        private Dto _dto;
       // private string _keysString;
       // private string _valuesString;
        //private string _descriptionString;
        private IEnumerable<bool> _isProtected;
        private IEnumerable<string> _hexStrings;

       // private string[] _key;
        private string[] _data;
        private string[] _description;

        private List<JohnBPearson.Application.Gestures.Model.IGestureObject> _items;

        internal List<JohnBPearson.Application.Gestures.Model.IGestureObject> Items
        {
            get
            {
                if(this._items == null)
                {
                    this._items = parse();
                }
                return this._items;
            }
            private set
            {
                this._items = value;
            }
        }

       // private List<string> _keys;

        internal List<string> Keys
        {
            get
            {
                if(this._items == null)
                {
                    this._items = parse();
                }
                var list = new List<string>();
                 this.keysArray.ToList().ForEach(k => list.Add(k.ToString()));
                return list;
            }
        }

        //private List<IGestureObject> hydrateItems(List<IGestureObject> items)
        //{
        //    if(items == null)
        //    {
        //        items = parse();
        //    }
        //    return items;
        //}
        internal static IEnumerable<string> parseStringToList(string value, char delim)
        {
            var list = new List<string>();

            if(value.Contains(delim))
            {
                var arr = new List<char>();
                arr.Add(delim);

                list.AddRange(value.Split(arr.ToArray(), StringSplitOptions.None));
                return list;
            }


            throw new ArgumentException(string.Concat(delim, " was not found in  ", value));
        }
        private char[] keysArray
        {
            get
            {
              return  new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            
            }
        }
        private List<JohnBPearson.Application.Gestures.Model.IGestureObject> parse()
        {

            //  var securedArray = this._isProtected.ToArray();
            string[] delims = { BaseValue.Delimiter };
            var resultList = new List<IGestureObject>();
            //   var letterrs = this._keysString.Split(delims, 100, StringSplitOptions.None).Clone();
          //  var letters = this._keysString.Split(BaseValue.DelimiterChar).Clone();
           // var values = this._valuesString.Split(BaseValue.DelimiterChar);
            // TODO: fxi so there are no null from here
          //  var descriptions = this._descriptionString.Split(BaseValue.DelimiterChar);
            //this._keys = (letters as string[]).ToList();
            var index = 0;
            // var protectedItems = this._is
          
            foreach(var key in this.keysArray)
            {
                if(index < this._data.Length)
                {
                    var value = this._data.ToArray()[index];
                    var des = this._description.ToArray()[index];
                    var isProtected = this._isProtected.ToArray()[index];
                    var hexString = this._hexStrings.ToArray()[index];
                    var length = this._dataLengths.ToArray()[index];
                    //var protect = this._protect.ToArray()[index];
                    var hkv = JohnBPearson.Application.Gestures.Model.GestureObject.Create(this._containerList, key, value, des, isProtected, hexString,length);
                    resultList.Add(hkv);
                    index++;
                }
                else
                {
                    break;
                }

            }
         //   checkAndRepairValuesArray(values);
           // checkAndRepairValuesArray(descriptions);

            return resultList;
        }

        private string[] checkAndRepairValuesArray(string[] values)
        {
            if(values.Length < 26)
            {
                var needToAdd = 26 - values.Length;

                for(int i = 0; i < needToAdd; i++)
                {
                    values.Append("");
                }
            }
            return values;
        }

        internal static List<int> parseStringsToInts(System.Collections.Specialized.StringCollection strings)
        {
            var ret = new List<int>();
            int test = 0;

            foreach(string s in strings)
            {
                if(int.TryParse(s, out test))
                {

                    ret.Add(test);
                }
                else
                {
                    ret.Add(0);
                }

            }
            return ret;
        }
     //   private const string delim = "|";
       // private const char delimChar = '|';
        //internal Dto updateStrings(List<JohnBPearson.Application.Model.IGestureObject> items)
        //{
        //    var result = 0;
        //    var tempKeys = new List<string>();
        //    var tempValues = new List<string>();
        //    var tempDescs = new List<string>();
        //    var values = new StringBuilder();

        //    foreach (var item in this.Items)
        //    {
        //        if (item.ObjectState != ObjectState.isDeleted)
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
        //        else if(item.ObjectState == ObjectState.isDeleted)
        //        {
        //            tempKeys.Add(item.Alpha.GetDeliminated());
        //            tempValues.Add(item.Data.GetDeliminated());
        //            tempDescs.Add(item.Description.GetDeliminated());
        //        }
        //    }
        //    var strings = new Dto();

        //    strings.Keys = tempKeys.ToString();
        //    strings.Descriptions = tempDescs.ToString();
        //    strings.Values = this.checkAndRepairValuesArray(tempValues.ToArray()).ToString();

        //    return strings;
        //}


    }
}


