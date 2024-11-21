using System;

namespace JohnBPearson.Application.Gestures.Model.Domain
{



    public abstract class BaseValue : IBaseValue
    {
        protected IContainer _parent;
        protected BaseValue(IContainer parent) { this._parent = parent; }
        protected BaseValue(string value, IContainer parent)
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
            get { return BaseValue._delimiter; }
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
        public override bool Equals(object other)
        {
            BaseValue localType = null;
            if(other.GetType() != this.GetType())
           {
                return false;
            }
            else
            {

                localType = (BaseValue)other;
            }
                if(localType == null) return false;
            if (localType != null && !string.IsNullOrWhiteSpace(localType.Value))
            {

                return this._value == localType.Value;
            }
            return false;
        }

        public bool Equals(BaseValue other)
        {
            return this == other;
           // if (other != null && other.Value == this.Value) { return true; } else { return false; }
        }

        public bool Equals(IBaseValue other)
        {
            return this == other;
        }

        public static bool operator ==(BaseValue lhs, BaseValue rhs)
        {        // public abstract bool Equals(IBaseValue other);
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

        public static bool operator !=(BaseValue lhs, BaseValue rhs)
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
