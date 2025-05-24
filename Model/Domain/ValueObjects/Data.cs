using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using JohnBPearson.Cypher;
using Microsoft.SqlServer.Server;

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
                        return (_dataProtect.Decrypt(this.ByteString));
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
                //if(this._byteValue != null)
                //{
                  return this._byteValue;
                //}
                //else
                   
                //{return new byte[];
                //  }
            }
            private set
            {
            this._byteValue= value;
                this._byteString = this.ByteArrayToString(value);

            }
        }

        private string _byteString = string.Empty;
        public string ByteString
        {
            get
            {

                //if( string.IsNullOrEmpty(this._byteString))
                //{
                //    _byteString = ByteArrayToString(this._byteValue);
                //    return _byteString;
                //}
                return this._byteString;

            }
            set
            {
                this._byteString = value;
                this._byteValue = this.StringToByteArray(value);
            }

        
        
        }


        private  string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach(byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
        private byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for(int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        private string buildByteString(byte[] bytes)
        {
            var localByteString = string.Empty;
            if(bytes != null && bytes.Length > 0)
            {
                foreach(byte b in bytes)
                {
                    localByteString += b.ToString();
                }

            }
            return localByteString;
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
