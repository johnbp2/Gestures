using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Application.Gestures.Model.Domain
{
    public class Data : BaseValue
    {

       // private MemoryProtection mp = new MemoryProtection();

        //private Data() {
            
        //} 
        protected Data(string value, IContainer parent) : base(value, parent) { 
     
        
        }

      //  private string _value;

        public override string Value
        {
            get
            {
                try
                {
                    return MemoryProtection.Decrypt(base.Value);
                }
                catch(  System.Security.Cryptography.CryptographicException e)
                {
                    return base.Value;
                }
            }
            set
            {
                base.Value = MemoryProtection.Encrypt(value);
                                
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static Data Create(string value, IContainer parent)
        {
            return new Data(value, parent);
        }

      
    }
}
