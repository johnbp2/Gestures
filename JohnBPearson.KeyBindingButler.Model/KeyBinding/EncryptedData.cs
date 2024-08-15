using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace JohnBPearson.KeyBindingButler.Model.KeyBinding
{
    public class EncryptedData :BaseData
    {

        public EncryptedData(IKeyBoundData parent, string value): base(value, parent)
        {
            var cyphered = JohnBPearson.Cypher.Aes.AesCypher.LockString(value);
        }
        private string _value = string.Empty;
            public override string Value
        {
            get
            {
                if(_value == string.Empty)
                {
                    try
                    {
                        JohnBPearson.Cypher.Aes.AesCypher.UnlockString(_value);
                    }catch (Exception ex) { }
                }
            return _value;
            }
        }
    }
}
