using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace JohnBPearson.KeyBindingButler.Model.KeyBinding
{
    public class EncryptedData : BaseData
    {

        public EncryptedData(IKeyBoundData parent, string value) : base(value, parent)
        {
            var cyphered = JohnBPearson.Cypher.Base64Url.Encode(value);
        }
        private string _value = string.Empty;
        public override string Value
        {
            get
            {


                JohnBPearson.Cypher.Base64Url.Decode(_value);


                return _value;
            }
        }


    }
}
