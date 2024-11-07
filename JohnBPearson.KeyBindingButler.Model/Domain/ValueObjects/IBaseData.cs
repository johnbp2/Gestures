using System;

namespace JohnBPearson.Application.Model
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