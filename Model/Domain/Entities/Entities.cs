using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Application.Gestures.Model.Domain.Entities
{

    public class Rootobject
    {
        public GestureDTO[] Containers
        {
            get; set;
        }
        public Rootobject()
        {
        }
    }

    public class Key
    {
        public Key()
        {
        }
        public string Alpha
        {
            get; set;
        }
        public string Value
        {
            get; set;
        }
    }

    public class Data
    {
        public Data()
        {
        }
        public string Value
        {
            get; set;
        }
    }
    
    public class Description
    {

        public Description()
        {
        }
        public string Value
        {
            get; set;
        }
    }

}
