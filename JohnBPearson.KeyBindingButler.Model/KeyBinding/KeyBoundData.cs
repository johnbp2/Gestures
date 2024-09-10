using System;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace JohnBPearson.KeyBindingButler.Model
{


    public class KeyBoundData : IKeyBoundData
    {
        private Data _data;
       
        private KeyboardKey _key;
         internal IKeyBoundDataList _parent;
        public KeyboardKey Key
        {
            get { return _key; }
            private set { _key = value; }
        }
        public Data Data
        {
            get { return _data; }
            private set
            {
                if (value != this._data)
                {
                    this._data = value;
                 
                }
            }
        }
        private Description _description;
        public Description Description
        {
            get { return _description ; }
             set
            {
                if (value != this._description)
                {
                    this._description = value;

                }
            }
        }
     


        public char KeyAsChar
        {
            get
            {

                if (!string.IsNullOrWhiteSpace(_key.Value))
                {

                    return _key.Value.ToCharArray()[0];
                }

                return ' ';
            }

        }
        //private string _description = "";
        //public string Description
        //{
        //    get { return _description; } private set { if (value != this._description && !string.IsNullOrWhiteSpace(value) ){
        //            _description = value;
        //        } }
        //}


        private ObjectState _objectState = ObjectState.New;
        public ObjectState ObjectState
        {
            get { return this._objectState; }
        }

        protected KeyBoundData()
        {
        }
        protected KeyBoundData(char key, string value)
        {
            this.CreateKeyboardKey(key);
            this.CreateData(value);
        }
        private void CreateData(string value)
        {
            Data = Data.Create(value, this);
        }

        private void CreateKeyboardKey(char key)
        {
            Key = KeyboardKey.Create(key, this);
        }

        private void CreateDescription(string description)
        {
            Description =Description.Create(description, this);
        }

        protected KeyBoundData(IKeyBoundDataList parent, char key, string value, string description)
        {
            this.CreateKeyboardKey(key);
            this.CreateData(value);
           this.CreateDescription(description);
            this._parent = parent;
        }


        public bool setIfLastItem()
        {
            /// z is the last in the keyboard key list 
            var lastIndex = this._parent.Items.Count() - 1;
            var lastItem = _parent.Items.LastOrDefault();
            if (lastItem.Equals(this))
            {
                return true;
               
            }
            return false;
        }


        internal static KeyBoundData Create(IKeyBoundDataList parent, char key, string value, string description = "")
        {
            return new KeyBoundData(parent, key, value, description);
        }

        //internal static KeyBoundData CreateForReplace(Data newValue, IKeyBoundData oldItem)
        //{
        //    if (!newValue.Equals(oldItem.Data))
        //    {
        //        return new KeyBoundData(oldItem.Key.Key, newValue.Value);
        //    }
        //    if (oldItem is KeyBoundData)
        //    {
        //        return (KeyBoundData)(oldItem);
        //    } else
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        public bool Equals(KeyBoundData other)
        {
            if (this.Data == other.Data && this.KeyAsChar == other.KeyAsChar)
            {
                return true;
            }
            return false;
        }
   

        [Obsolete("no mas")]
        public string GetDelimitated()
        {
            return string.Concat(this._key.GetDeliminated(), this._data.ToString());
                    
        }

        public void Update(string newValue, string newDescription)
        {
            if (this.Data.Value != newValue)
            {
                this.Data.Value = newValue;
                this._objectState = ObjectState.Mutated;
            }
            if (!string.IsNullOrWhiteSpace(newDescription))
            {
                this.Description.Value = newDescription;
                this._objectState = ObjectState.Mutated;
            }
        }

        public bool Equals(IKeyBoundData other)
        {
            if (other.Data.Equals(this.Data))
            {
                return true;
            }
            return false;
        }
    }
}