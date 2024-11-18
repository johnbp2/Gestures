namespace JohnBPearson.Application.Model
{
    public class InputKey : BaseData
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

        public System.Windows.Forms.k MyProperty { get; set; }

        protected InputKey(IContainer parent) : base(parent)
        {

        }
        protected InputKey(char key, IContainer parent) : base(key.ToString(), parent)
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

        public static InputKey Create(char key, IContainer parent)
        {
            return new InputKey(key, parent);

        }
    }
}
