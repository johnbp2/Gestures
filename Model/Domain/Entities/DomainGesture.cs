using System;
using System.Collections.Generic;
using JohnBPearson.Application.Common;

namespace JohnBPearson.Application.Gestures.Model.Domain.Entities
{
    public class JsonRoot
    {
        public string AssemblyVersion
        {
        get; set;
        }
        public List<DomainGesture> Gestures { get; set; }
        public JsonRoot()
        {
        }
    }

    [Serializable]
    public class DomainGesture
    {

        public DomainGesture()
        {

        }
        public string HexString
        {

            get; set;
        }



        public string DescriptionString
        {
            get; set;
        }


        public string DataString
        {
            get; set;
        }
      
        public bool IsProtected
        {
            get;
            set;
        }
        public string KeyAsChar
        {
            get; set;
        }
        public int Length
        {
            get;
            set;
        }

        public string[] ByteValue
        {
            get; set;

        }
        public byte[] Bytes
        {
        
        get; set;}
    }

}
