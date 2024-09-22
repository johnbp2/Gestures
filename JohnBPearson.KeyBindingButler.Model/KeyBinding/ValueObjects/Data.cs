using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.KeyBindingButler.Model
{
    public class Data : BaseData
    {


        //private Data() {
            
        //} 
        private Data(string value, IKeyBoundData parent) : base(value, parent) { 
     
        
        }

       
        public override string ToString()
        {
            return base.ToString();
        }

        public static Data Create(string value, IKeyBoundData parent)
        {
            return new Data(value, parent);
        }

      
    }
}
