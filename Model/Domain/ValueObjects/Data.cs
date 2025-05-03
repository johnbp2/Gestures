using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Application.Gestures.Model.Domain
{
    public class Data : BaseValue
    {
        public bool isProtected
        {
            get;
            private set;
        }

        public bool Protect
        {
            get;
            private set;
        }
        // private DataProtectionService mp = new DataProtectionService();

        //private Data() {

        //} 
        protected Data(string value, IContainer parent, bool protect, bool isProtected) : base(value, parent) { 
     
        this.Protect = protect;
            this.isProtected = isProtected;
        }

      //  private string _value;

        public override string Value
        {
            get
            {
                try
                {
                    if(this.isProtected)
                    {
                        return DataProtectionService.Decrypt(base.Value);
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
                if(!this.isProtected && this.Protect)
                {
                    base.Value = DataProtectionService.Encrypt(value);
                }
                else
                {
                    base.Value = value;
                }
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
