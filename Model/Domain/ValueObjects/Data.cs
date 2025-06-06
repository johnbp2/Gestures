using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using JohnBPearson.Cypher;
using Microsoft.SqlServer.Server;

namespace JohnBPearson.Application.Gestures.Model.Domain
{

    [DebuggerDisplay("{debugDisplay}")]
    public class Data : BaseValue
    {

        private DataProtect _dataProtect = new DataProtect();

        public bool isProtected
        {
            get;
            set;
        }

        public string debugDisplay
        {
            get
            {
                return $"Value={this.Value} HexString={this.HexString} Length={this.Length}";
            }
        }
        private bool _protect;
        /// <summary>
        /// deprecated do not use
        /// </summary>
        [Obsolete]
        public bool Protect
        {
            get
            {
                return _protect;
            }
            set
            {

            }
        }

        public int Length
        {
            get;
            private set;
        }
        protected Data(string value, IValueObjectFactory parent, bool isProtected, string hexString, int length) : base(value, parent)
        {
            // this.Protect = protect;
            this.Length = length;
            this.Value = value;
            this.isProtected = isProtected;
            this._parent = parent;
            //  this.HexString = HexString;
            if(!string.IsNullOrWhiteSpace(hexString))
            {
                this._byteValue = this.StringToByteArray(hexString);
            }
        }

        //  private string _value;

        public override string Value
        {
            get
            {
                try
                {
                    if(this.isProtected && !string.IsNullOrWhiteSpace(this.HexString))
                    {
                        this.setDecryptedValue();
                        // TODO: need to conver the byte string to its ASCII form

                    }
                    return base.Value;

                }
                catch(System.Security.Cryptography.CryptographicException e)
                {
                    return base.Value;
                }
            }
            set
            {

                base.Value = value;
                if(this._parent != null)
                {
                    this._parent.ObjectState = ObjectState.Changed;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plainText"></param>
        public void setEncryptedValue(string plainText)
        {
            //dont encrypt it twice

            /// this.isProtected means the data is already encrypted 
            this.Length = plainText.Length;
            if(!this.isProtected)
            {
                //  base.Value = _dataProtect.Encrypt(plainText, false);

                this.ByteValue = _dataProtect.EncryptToBytes(plainText);
                this.isProtected = true;
                this._parent.ObjectState = ObjectState.Changed;
            }
        }

        private void setDecryptedValue()
        {
            if(this.isProtected && this.Length > 0 && this.HexString.Length > 0)
            {
                var paddedValue = this._dataProtect.DecryptBytes(this.StringToByteArray(this.HexString));
                if(this.Length < 16)
                {
                    int padding = 16 - this.Length;
                    base.Value = paddedValue.Substring(0, padding);
                }
                else if(this.Length == 16)
                {
                    base.Value = paddedValue;
                }
                else
                {
                    // must be greater than 16

                    int padding = this.Length % 16;
                    if(padding != 0)
                    {
                        base.Value = paddedValue.Substring(0, padding);
                    }
                    else
                    {


                        base.Value = paddedValue;
                    }

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
                this._byteValue = value;
                //   this._hexString = this.ByteArrayToHexString(value);

            }
        }

        private string _hexString = string.Empty;
        public string HexString
        {
            get
            {

                //if( string.IsNullOrEmpty(this._hexString))
                //{
                //    _hexString = ByteArrayToHexString(this._byteValue);
                //    return _hexString;
                //}
                if(this.ByteValue != null)
                {

                    return this.ByteArrayToHexString(this.ByteValue);
                }
                else
                {
                    return string.Empty;
                }
            }



        }


        private string ByteArrayToHexString(byte[] ba)
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

        //private string buildByteString(byte[] bytes)
        //{
        //    var localByteString = string.Empty;
        //    if(bytes != null && bytes.Length > 0)
        //    {
        //        foreach(byte b in bytes)
        //        {
        //            localByteString += b.ToString();
        //        }

        //    }
        //    return localByteString;
        //}
        public override string ToString()
        {
            return base.ToString();
        }

        public static Data Create(string value, IValueObjectFactory parent, bool isProtected, string hexString, int length)
        {
            return new Data(value, parent, isProtected, hexString, length);
        }


    }
}
