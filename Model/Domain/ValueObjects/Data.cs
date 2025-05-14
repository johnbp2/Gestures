using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using JohnBPearson.Cypher;

namespace JohnBPearson.Application.Gestures.Model.Domain
{
    public class Data : BaseValue
    {

        private DataProtect _dataProtect = new DataProtect();

        public bool isProtected
        {
            get;
            set;
        }

        public bool Protect
        {
            get;
            set;
        }
        // private DataProtectionService mp = new DataProtectionService();

        //private Data() {
            
        //} 
        public int Length
        {
            get;
            private set;
        }
        protected Data(string value, IContainer parent, bool protect, bool isProtected) : base(value, parent) {
            this.Protect = protect;
            this.Length = value.Length;
       
            this.isProtected = isProtected;
        }

      //  private string _value;

        public  override string Value
        {
            get
            {
                try
                {
                    if(this.isProtected)
                    {
                        return (_dataProtect.Decrypt(base.Value));
                    }
                    else
                    {return base.Value;
                    }
                }
                catch(System.Security.Cryptography.CryptographicException e)
                {
                    return base.Value;
                }
            }
            set
            {
                //dont encrypt it twice
                /// this.protect means data should be encrypted
                /// this.isProtected means the data is already encrypted 
                if(!this.isProtected && this.Protect)
                {
                    base.Value = _dataProtect.Encrypt(value, false);
                    this.ByteValue = _dataProtect.Encrypt(value);
                    this.isProtected = true;
                }
                else
                {
                    base.Value = value;
                    this.isProtected= false;
                    this.ByteValue = null;
                }
            }
        }
        private byte[] _byteValue;

        public byte[] ByteValue
        {
            get
            {
                return this._byteValue; 
            }
            private set
            {
            this._byteValue= value;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static Data Create(string value, IContainer parent, bool isProtected = false, bool protect = false)
        {
            return new Data(value, parent, protect, isProtected);
        }

      
    }
}
