using System;
using System.Collections.Generic;
namespace JohnBPearson.Application.Gestures.Model.Utility
{
    public struct Dto
    {
        [Obsolete]
        public string Keys;
        [Obsolete]
        public string Values;
        public int ItemsUpdated;
        [Obsolete]
        public string Descriptions;
      
        [Obsolete]
        public List<bool> Protect;
        public List<int> DataLengths;
        public List<string> HexStrings;

        public string[] Key;
        public string[] Data;
        public string[] Description;
        public IEnumerable<bool> IsProtected;


    }



}