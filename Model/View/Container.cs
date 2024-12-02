using System;
using System.ComponentModel;
using System.Linq;
using JohnBPearson.Application.Gestures.Model.Domain;

namespace JohnBPearson.Application.Gestures.Model
{


    public class Container : JohnBPearson.Application.Gestures.Model.IContainer
    {


        internal Domain.Entities.Container MapToEntity()
        {
            var entity = new Domain.Entities.Container();
            entity.DataString = this.Data.Value;
            entity.DescriptionString = this.Description.Value;
            entity.KeyAsChar = this.KeyAsChar.ToString();

                return entity;
        
        
        }



        private Data _data;

        private InputKey _key;
        internal JohnBPearson.Application.Gestures.Model.IContainerList _parent;
        public InputKey Key
        {
            get
            {
                return _key;
            }
            private set
            {
                _key = value;
            }
        }
      //  [System.Text.Json.Serialization.JsonIgnore]
        public string DescriptionString
        {
            get
            {
                return this._description.Value;
            }
            set
            {
                this._description.Value = value;
            }
        }

       // [System.Text.Json.Serialization.JsonIgnore]
        public string DataString
        {
            get
            {
                return this._data.Value;
            }
            set
            {
                this._data.Value = value;
            }
        }

        public Data Data
        {
            get
            {

                if(this._isDataSecured == false)
                {
                    return _data;
                }
                else
                {
                    return this._secured;

                }
            }
            private set
            {
                if(value != this._data)
                {
                    this._data = value;

                }
            }
        }
        private Description _description;
        public Description Description
        {
            get
            {
                return _description;
            }
            set
            {
                if(value != this._description)
                {
                    this._description = value;

                }
            }
        }

        private bool _isDataSecured;

        public bool IsDataSecured
        {
            get
            {
                return _isDataSecured;
            }
            set
            {
                _isDataSecured = value;
            }
        }



        private JohnBPearson.Application.Gestures.Model.Domain.SecuredData _secured;

        public JohnBPearson.Application.Gestures.Model.Domain.SecuredData Secured
        {
            get
            {
                return this._secured;
            }
        }

        public char KeyAsChar
        {
            get
            {

                if(!string.IsNullOrWhiteSpace(_key.Value))
                {

                    return _key.Value.ToCharArray()[0];
                }

                return ' ';
            }

        }
 


        private JohnBPearson.Application.Gestures.Model.ObjectState _objectState = JohnBPearson.Application.Gestures.Model.ObjectState.New;
        public JohnBPearson.Application.Gestures.Model.ObjectState ObjectState
        {
            get
            {
                return this._objectState;
            }
        }


        protected Container(char key, string value)
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
            Key = InputKey.Create(key, this);
        }

        private void CreateDescription(string description)
        {
            Description = Description.Create(description, this);
        }

        protected Container(JohnBPearson.Application.Gestures.Model.IContainerList parent, char key, string value, string description, bool secured)
        {
            this.CreateKeyboardKey(key);
            if(secured)
            {
                Data = SecuredData.Create(value, this);
            }
            else
            {
                this.CreateData(value);
            }
            this.CreateDescription(description);
            this._parent = parent;
        }


        public bool setIfLastItem()
        {
            /// z is the last in the keyboard key list 
            var lastIndex = this._parent.Items.Count() - 1;
            var lastItem = _parent.Items.LastOrDefault();
            if(lastItem.Equals(this))
            {
                return true;

            }
            return false;
        }


        internal static Container Create(JohnBPearson.Application.Gestures.Model.IContainerList parent, char key, string value, string description = "", bool secured = false)
        {
            return new Container(parent, key, value, description, secured);
        }


        internal static Container Create(JohnBPearson.Application.Gestures.Model.IContainerList parent, Domain.Entities.Container entity)
        {
            return new Container(parent, entity.KeyAsChar.ToCharArray()[0], entity.DescriptionString, entity.DataString, false);
        }
        //internal static Containers CreateForReplace(Data newValue, IKeyBoundData oldItem)
        //{
        //    if (!newValue.Equals(oldItem.Data))
        //    {
        //        return new Containers(oldItem.InputKey.InputKey, newValue.Value);
        //    }
        //    if (oldItem is Containers)
        //    {
        //        return (Containers)(oldItem);
        //    } else
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

       


        //[Obsolete("no mas")]
        //public string GetDelimitated()
        //{
        //    return string.Concat(this._key.GetDeliminated(), this._data.ToString());

        //}

        public void Update(ref string newValue, string newDescription, bool isSecure = false)
        {

            this._isDataSecured = isSecure;
            if(this.Data.Value != newValue && !isSecure)
            {
                this.Data.Value = newValue;
                this._objectState = JohnBPearson.Application.Gestures.Model.ObjectState.Mutated;

            }
            else if(this.Data.Value != newValue || isSecure)
            {
                this.UpdateAddSecureString(newValue);
                this._objectState = JohnBPearson.Application.Gestures.Model.ObjectState.Mutated;
            }
            if(!string.IsNullOrWhiteSpace(newDescription))
            {
                this.Description.Value = newDescription;
                this._objectState = JohnBPearson.Application.Gestures.Model.ObjectState.Mutated;
            }
        }

        //public bool Equals(IContainer other)
        //{
        //    if (other.Data.Equals(this.Data))
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        public void UpdateAddSecureString(string newValue)
        {
            this._secured = SecuredData.Create(this, newValue);
            this._isDataSecured = true;
            newValue = string.Empty;

        }

        public bool Equals(Gestures.Model.IContainer other)
        {
            if(other.Data.Equals(this.Data))
            {
                return true;
            }
            return false;
        }

        public bool Equals(Gestures.Model.Container other)
        {
            if(other.Data.Equals(this.Data))
            {
                return true;
            }
            return false;
        }
    }
}