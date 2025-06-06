using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Application.Gestures.Model.Domain
{
    public class Description: BaseValue
    {


      

      



        protected Description(IValueObjectFactory parent) : base(parent)
            {

            }
            protected Description(string description, IValueObjectFactory parent) : base(description, parent)
            {
              
            }

           
            public override string ToString()
            {
               return this.Value;
                
               
            }

        public static Description Create(string description, IValueObjectFactory parent)
        {
            return new Description(description, parent);
        }
          
         
        }
    }