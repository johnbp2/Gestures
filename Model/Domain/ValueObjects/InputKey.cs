﻿namespace JohnBPearson.Application.Gestures.Model.Domain    
{
    public class InputKey : BaseValue
    {

        private char _key;

        public char Key
        {
            get
            {
                if (this.validateStringIsChar(base.Value))
                {
                    return base.Value[0];
                }
                else
                {
                    return _key;
                }
            }
            set { _key = value; }
        }


        protected InputKey(IGestureObject parent) : base(parent)
        {

        }
        protected InputKey(char key, IGestureObject parent) : base(key.ToString(), parent)
        {
            this._key = key;
        }

        private bool last
        {
            get
            {

                if (_key == 'z') { return true; } else { return false; }
            }
        }

        public override string ToString()
        {
            if (this.last)
            {
                return Key.ToString();
            }
            else
            {
                return base.ToString();
            }
        }


        private bool validateStringIsChar(string c)
        {
            if (!string.IsNullOrWhiteSpace(c) && c.Length == 1)
            {
                return true;
            }
            return false;

        }

        public static InputKey Create(char key, IGestureObject parent)
        {
            return new InputKey(key, parent);

        }
    }
}
