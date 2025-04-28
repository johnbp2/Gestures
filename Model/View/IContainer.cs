using System;
using System.ComponentModel;

using JohnBPearson.Application.Gestures.Model.Domain;
using System.Dynamic;
using System.Net.Http.Headers;

namespace JohnBPearson.Application.Gestures.Model
{

    public enum ObjectState
    {
        Loaded,
        Changed,
        Deleted,

    }
    public interface IBase
    {
        InputKey Key { get; }
        
        Data Data { get; }
        string DataString
        {

            get;
            set;
        }
        string DescriptionString
        {

            get;
            set;
        }
        Description Description { get; set; }
        char KeyAsChar { get; }
     
        ObjectState ObjectState { get; }


    }
    public interface IContainer : IBase, System.IEquatable<IContainer>
    { 
        

      


        void Update(ref string newValue, string newDescription,  bool isSecure = false);
       // string GetDelimitated();


        bool setIfLastItem();

   bool IsDataSecured { get; set; }
    }


    public interface IKeyBoundCommand: IBase // , IEquatable<IKeyBoundCommand>
    {

    }
}

//    public abstract class KeyBoundDataBase
//    {



//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="key"></param>
//        /// <param name="value"></param>
//        /// <param name="item">the item to be replaced</param>
//        ///// <returns></returns>
//        //public static IKeyBoundData CreateForReplace(string key, string value, Containers item)
//        //{
//        //    return Containers.KeyBoundDataBase Create(string key, string value)
//        //}
//    }
//}