using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Application.Gestures.Model.Domain
{
    public class Data : BaseData
    {


        //private Data() {
            
        //} 
        protected Data(string value, IContainer parent) : base(value, parent) { 
     
        
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
