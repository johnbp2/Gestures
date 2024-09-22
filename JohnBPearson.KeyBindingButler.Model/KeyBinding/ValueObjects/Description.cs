using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.KeyBindingButler.Model
{
    public class Description: BaseData
    {


      

      




        protected Description(IKeyBoundData parent) : base(parent)
            {

            }
            protected Description(string description, IKeyBoundData parent) : base(description, parent)
            {
              
            }

           
            public override string ToString()
            {
               return this.Value;
                
               
            }

        public static Description Create(string description, IKeyBoundData parent)
        {
            return new Description(description, parent);
        }
          
         
        }
    }