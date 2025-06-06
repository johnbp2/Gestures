using System.Diagnostics;
using System.Linq;
using JohnBPearson.Application.Gestures.Model.Domain;

namespace JohnBPearson.Application.Gestures.Model
{

    [DebuggerDisplay("{debugDisplay}")]
    public class ValueObjectFactory : JohnBPearson.Application.Gestures.Model.IValueObjectFactory
    {


        public string debugDisplay
        {
            get
            {
                return $"Value={this.Data.Value} HexString={this.Data.HexString} Length={this.Data.Length}";
            }
        }

        internal Domain.Entities.ContainerEntity MapToEntity()
        {
            var entity = new Domain.Entities.ContainerEntity();
            entity.DataString = this.Data.Value;
            entity.DescriptionString = this.Description.Value;
            entity.KeyAsChar = this.KeyAsChar.ToString();
            entity.IsProtected = this.Data.isProtected;
           // entity.Protect = this.Data.Protect;
            entity.Length = this.Data.Length;
            entity.HexString = this.Data.HexString;
            return entity;

        }
   


        private Domain.Data _data;

        private InputKey _key;
        internal JohnBPearson.Application.Gestures.Model.IEntityFactory _parent;
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

        public Domain.Data Data
        {
            get
            {

               
                    return _data;
               
            }
            private set
            {
                if(value != this._data)
                {
                    this._data = value;

                }
            }
        }
        private Domain.Description _description;
        public Domain.Description Description
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
 


         JohnBPearson.Application.Gestures.Model.ObjectState _objectState = JohnBPearson.Application.Gestures.Model.ObjectState.isNew;
        public JohnBPearson.Application.Gestures.Model.ObjectState ObjectState
        {
            get
            {
                return this._objectState;
            }
            set
            {
                this._objectState = value;
            }
        }


        protected ValueObjectFactory(char key, string data, bool isProtected, string hexString, int length)
        {
            this.CreateKeyboardKey(key);
            this.CreateData(data,isProtected, hexString, length);
        }
        private void CreateData(string value, bool isProtected,string hexString, int length)
        {
            Data = Domain.Data.Create(value, this, isProtected, hexString, length);
        }

        private void CreateKeyboardKey(char key)
        {
            Key = InputKey.Create(key, this);
        }

        private void CreateDescription(string description)
        {
            Description = Domain.Description.Create(description, this);
        }

        protected ValueObjectFactory(JohnBPearson.Application.Gestures.Model.IEntityFactory parent, char key, string value,
            
            string description, bool isProtected, string hexString, int length)
        {
            this.CreateKeyboardKey(key);
           
                this.CreateData(value ,isProtected, hexString, length);
            
            this.CreateDescription(description);
            this._parent = parent;
        }

        protected ValueObjectFactory(JohnBPearson.Application.Gestures.Model.IEntityFactory parent, char key, string value,

          string description, bool isProtected, bool protect, string hexString, int length)
        {
            this.CreateKeyboardKey(key);

            this.CreateData(value, isProtected,hexString,length);

            this.CreateDescription(description);
            this._parent = parent;
        }
        protected ValueObjectFactory(JohnBPearson.Application.Gestures.Model.IEntityFactory parent, Domain.Entities.ContainerEntity container)
        {
            this.CreateKeyboardKey(char.Parse(container.KeyAsChar));

            this.CreateData(container.DataString, container.IsProtected, container.HexString, container.Length);

            this.CreateDescription(container.DescriptionString);
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


        public static ValueObjectFactory Create(JohnBPearson.Application.Gestures.Model.IEntityFactory parent,
            char key, string value, string description = "", bool isProtected = false,
            string hexString = "", int length = 0)
        {
            return new ValueObjectFactory(parent, key, value, description, isProtected, hexString, length);
        }


        public static ValueObjectFactory Create(JohnBPearson.Application.Gestures.Model.IEntityFactory parent, Domain.Entities.ContainerEntity entity)
        {
            return new ValueObjectFactory(parent, entity.KeyAsChar.ToCharArray()[0], entity.DataString, entity.DescriptionString, entity.IsProtected, entity.HexString, entity.Length);
        }
        //internal static Containers CreateForReplace(Data newValue, IKeyBoundData oldItem)
        //{
        //    if (!newValue.Equals(oldItem.Data)) 02
        //    {
        //        return new Containers(oldItem.InputKey.InputKey, newValue.Value);
        //    }
        //    if (oldItem is Containers)
        //    {
        //        return (Containers)(oldItem);
        //    } else
        //    {
        //        throw new NotImplementedException();
        //    }0-2        //{
        //    if (other.Data.Equals(this.Data))
        //    {
        //        return true;
        //    }
        //    return false;
        //}

     

        public bool Equals(Gestures.Model.IValueObjectFactory other)
        {
            if(other.Data.Equals(this.Data))
            {
                return true;
            }
            return false;
        }

        public bool Equals(Gestures.Model.ValueObjectFactory other)
        {
            if(other.Data.Equals(this.Data))
            {
                return true;
            }
            return false;
        }
    }
}