using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.KeyBindingButler.Model.Domain.Entities
{

    public class Rootobject
    {
        public Container[] Containers
        {
            get; set;
        }
    }

    public class Container
    {
        public bool IsDataSecured
        {
            get; set;
        }
        public Key Key
        {
            get; set;
        }
        public Data Data
        {
            get; set;
        }
        public string DataString
        {
            get; set;
        }
        public string DescriptionString
        {
            get; set;
        }
        public Description Description
        {
            get; set;
        }
        public string KeyAsChar
        {
            get; set;
        }
        public object Secured
        {
            get; set;
        }
        public int ObjectState
        {
            get; set;
        }
    }

    public class Key
    {
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
        public string Value
        {
            get; set;
        }
    }

    public class Description
    {
        public string Value
        {
            get; set;
        }
    }

}
