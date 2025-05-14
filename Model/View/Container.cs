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
            entity.IsProtected = this.Data.isProtected;
            entity.Protect = this.Data.Protect;
            entity.Length = this.Data.Length;
            return entity;

        }
   


        private Domain.Data _data;

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
 


        private JohnBPearson.Application.Gestures.Model.ObjectState _objectState = JohnBPearson.Application.Gestures.Model.ObjectState.isNew;
        public JohnBPearson.Application.Gestures.Model.ObjectState ObjectState
        {
            get
            {
                return this._objectState;
            }
        }


        protected Container(char key, string data, bool isProtected, bool protect)
        {
            this.CreateKeyboardKey(key);
            this.CreateData(data,isProtected, protect);
        }
        private void CreateData(string value, bool isProtected, bool protect)
        {
            Data = Domain.Data.Create(value, this, isProtected, protect);
        }

        private void CreateKeyboardKey(char key)
        {
            Key = InputKey.Create(key, this);
        }

        private void CreateDescription(string description)
        {
            Description = Domain.Description.Create(description, this);
        }

        protected Container(JohnBPearson.Application.Gestures.Model.IContainerList parent, char key, string value,
            
            string description, bool isProtected, bool protect)
        {
            this.CreateKeyboardKey(key);
           
                this.CreateData(value ,isProtected, protect);
            
            this.CreateDescription(description);
            this._parent = parent;
        }
        protected Container(JohnBPearson.Application.Gestures.Model.IContainerList parent, Domain.Entities.Container container)
        {
            this.CreateKeyboardKey(char.Parse(container.KeyAsChar));

            this.CreateData(container.DataString, container.IsProtected, container.Protect);

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


        public static Container Create(JohnBPearson.Application.Gestures.Model.IContainerList parent,
            char key, string value, string description = "", bool isProtected = false, bool protect = false)
        {
            return new Container(parent, key, value, description, isProtected, protect);
        }


        public static Container Create(JohnBPearson.Application.Gestures.Model.IContainerList parent, Domain.Entities.Container entity)
        {
            return new Container(parent, entity.KeyAsChar.ToCharArray()[0], entity.DataString, entity.DescriptionString, entity.IsProtected, entity.Protect);
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