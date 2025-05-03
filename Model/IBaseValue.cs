using System;

namespace JohnBPearson.Application.Gestures.Model.Domain
{
    public interface IBaseValue :IEquatable<IBaseValue>
    {
        string Value {
            get;
        }

       // bool Equals(IBaseValue other);    
        string GetDeliminated();
        string GetDeliminated(char delim);
        string GetDelimiter();
        string ToString();
    }
}