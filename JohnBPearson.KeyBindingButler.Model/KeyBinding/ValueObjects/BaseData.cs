using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.KeyBindingButler.Model
{



    public abstract class BaseData : IEquatable<BaseData>, IBaseData
    {
        protected IContainer _parent;
        protected BaseData(IContainer parent) { this._parent = parent; }
        protected BaseData(string value, IContainer parent)
        {
            if (value == null) value = string.Empty;
            this._value = value;
            this._parent = parent;
        }



        private  string _value = "";
        public virtual string Value
        {
            get { return _value; }
             set
            {
            _value = value; }   
        //private    set
        //    {
        //        if (!string.IsNullOrWhiteSpace(value))
        //        {
        //            this._value = value;
        //        }
        //    }
        }

        public static string Delimiter
        {
            get { return BaseData._delimiter; }
            private set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    _delimiter = value;
                }
            }
        }



        private static string _delimiter = "|";

        public override string ToString()
        {
            return Value;
        }
        public string GetDeliminated()
        {
            return string.Concat(Value, Delimiter);
        }
        public static string GetDeliminatedData(string Data)
        {
            return string.Concat(Data, Delimiter);
        }
        public string GetDelimiter()
        {
            return Delimiter;
        }




        public string GetDeliminated(char delim)
        {
            switch (delim)
            {
                case ',':

                    break;
                case '?':

                    break;
                case '!':

                    break;
                case '/':

                    break;
                case '\\':

                    break;
                case '#':

                    break;
                case '%':

                    break;
                default:
                    throw new ArgumentException($"{nameof(delim)} is invalid for _delimiter. Allowed chars are , ? ! / \\ # %");
                    break;
            }
            return string.Concat(Value, delim.ToString());
        }
        public bool Equals(IBaseData other)
        {
            if (other != null && !string.IsNullOrWhiteSpace(other.Value))
            {

                return this._value == other.Value;
            }
            return false;
        }

        public bool Equals(BaseData other)
        {
            return this == other;
           // if (other != null && other.Value == this.Value) { return true; } else { return false; }
        }


        public static bool operator ==(BaseData lhs, BaseData rhs)
        {        // public abstract bool Equals(IBaseData other);
            if (lhs is null || rhs is null)
            {
                if (lhs is null && rhs is null) { return true; } else { return false; }


            }
            if (lhs.Value == rhs.Value) { return true; }
            else
            {
                return false;
            }
            
        }

        public static bool operator !=(BaseData lhs, BaseData rhs)
        {
            if (lhs is null || rhs is null)
            {
                if (lhs is null && rhs is null) { return false; } else { return true; }

      
            }
            if (!lhs.Equals(rhs)) return true;
            return false;
        }
    }
}
