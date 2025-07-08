using System.Diagnostics.Eventing.Reader;
using JohnBPearson.Application.Gestures.Model.Domain;

namespace JohnBPearson.Application.Gestures.Model
{

    public enum ObjectState
    {
        isNew,
        Changed,
        isDeleted,

    }
    public interface IBaseContainer
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
     
        ObjectState ObjectState {
            get; set;
        }


    }
    public interface IGestureObject : IBaseContainer, System.IEquatable<IGestureObject>
    { 
        
       
      


      //  void Update(ref string newValue, string newDescription,  bool isProtected ,bool protect);
       // string GetDelimitated();


        bool setIfLastItem();

    
    }


    public interface IKeyBoundCommand: IBaseContainer // , IEquatable<IKeyBoundCommand>
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