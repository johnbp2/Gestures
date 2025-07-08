using System;

namespace JohnBPearson.Application.Gestures.Model.Domain.Entities
{
    public class ContainerEntity
    {

        public ContainerEntity()
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
        [Obsolete]
        public bool Protect
        {
            get;
            set;
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
    }

}
