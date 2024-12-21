using System; 
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace JohnBPearson.Application.Gestures.Model.Domain
{
    // TODO[]: CREATE TESTS FORE THIS 
    /// <summary>
    /// 
    /// </summary>
    public class SecuredData : Data
    {
        private readonly string rawData;

      protected SecuredData(IContainer parent,  string value, bool dataEncoded) : base(value,parent)
        {
            rawData = String.Copy(value);
            if(!dataEncoded)
            {
                this._secured = JohnBPearson.Cypher.Base64Url.Encode(value);
            }
            else
            {
            this._secured = value;
            }
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

        public static SecuredData Create(IContainer parent,  string value, bool needsEncoding)
        {    var instance = new SecuredData(parent, value, needsEncoding);
            value = null;
            return instance;
        }


    }
}
