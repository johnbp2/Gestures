using System; 
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace JohnBPearson.KeyBindingButler.Model.KeyBinding
{
    public class EncryptedData : Data
    {

        private EncryptedData(IKeyBoundData parent, ref string value) : base(value,parent)
        {
            this._secured = JohnBPearson.Cypher.Base64Url.Encode(value);
            value = null;
        }
        private string _secured = string.Empty;
            
         //  private string _value = string.Empty;
        public override string Value
        {
            get
            {


                return JohnBPearson.Cypher.Base64Url.Decode(_secured);


                 
            }
        }

        public string Secured
        {
            get { return this._secured; }    
                    }

        public static EncryptedData Cypher(IKeyBoundData parent,  string value)
        {    var instance = new EncryptedData(parent, ref value);
            value = null;
            return instance;
        }


    }
}
