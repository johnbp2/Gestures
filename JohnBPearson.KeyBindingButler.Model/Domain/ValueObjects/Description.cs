using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Application.Model
{
    public class Description: BaseData
    {


      

      




        protected Description(IContainer parent) : base(parent)
            {

            }
            protected Description(string description, IContainer parent) : base(description, parent)
            {
              
            }

           
            public override string ToString()
            {
               return this.Value;
                
               
            }

        public static Description Create(string description, IContainer parent)
        {
            return new Description(description, parent);
        }
          
         
        }
    }