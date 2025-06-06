﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Application.Gestures.Model.Domain.Entities
{

    public class Rootobject
    {
        public ContainerEntity[] Containers
        {
            get; set;
        }
        public Rootobject()
        {
        }
    }

    public class ContainerEntity
    {
      //  private DataEntity _data;
        public ContainerEntity()
        {
           // this._data = new Data();
        }
        public string HexString
        {

            get; set;
        }
     
        //public Key Key
        //{
        //    get; set;
        //}
        //public Data Data
        //{
        //    get; set;
        //}
       
        public string DescriptionString
        {
            get; set;
        }
        //public Description Description
        //{
        //    get; set;
        //}
        #region data object
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

        #endregion
        //public object IsProtected
        //{
        //    get; set;
        //}
        //public int ObjectState
        //{
        //    get; set;
        //}
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
