using System;

namespace ohnBPearson.Application.Gestures.Model.Domain
{
    public interface IBaseData :IEquatable<IBaseData>
    {
        string Value {
            get;
        }

       // bool Equals(IBaseData other);    
        string GetDeliminated();
        string GetDeliminated(char delim);
        string GetDelimiter();
        string ToString();
    }
}