using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace JohnBPearson.KeyBindingButler.Model
{
    public class KeyboardKey : BaseData
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
        protected KeyboardKey(IKeyBoundData parent) : base(parent)
        {

        }
        protected KeyboardKey(char key, IKeyBoundData parent) : base(key.ToString(), parent)
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

        public static KeyboardKey Create(char key, IKeyBoundData parent)
        {
            return new KeyboardKey(key, parent);

        }
    }
}
