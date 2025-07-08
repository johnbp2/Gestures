using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Runtime.Remoting.Messaging;

namespace JohnBPearson.Application.Gestures.Model.Utility
{
    internal static class UserSettingsValidator
    {




        internal static StringCollection validateCollection(StringCollection stringCollection, bool repair, string item)
        {

            var result = testStringCollection(stringCollection);
            if(repair)
            {
                if(result == null)
                {



                    stringCollection = new StringCollection();
                    initNullCollection(stringCollection, item);
                    return stringCollection;





                }
                else if(result > 0)
                {


                    var toAdd = 26 - stringCollection.Count;
                    addArbitraryNumberOfEmptyStrings(stringCollection, toAdd, item);
                    return stringCollection;


                }
                else if(result < 0)
                {

                    var toRemove = stringCollection.Count - 26;
                    removeArbitraryNumberOfEmptyStrings(stringCollection, toRemove);
                    return stringCollection;


                }
                else
                {
                    return stringCollection;

                }
            }
            else
            {
                throwExeception(result);
            }
       
            return stringCollection;
        }


        private static void throwExeception(int? result)
        {
            string insert = result != null ? result.ToString() : "null";
            throw new Exception($"user setting for string collection is out of range by: {insert}. 0 indicates null collection or empty.");
        }


        private static int? testStringCollection(StringCollection stringCollection)
        {
            if(stringCollection == null)
            {
                return null;
            }
            else if(stringCollection.Count < 26)
            {
                return 26 - stringCollection.Count;

            }
            else if(stringCollection.Count > 26)
            {
                return -(stringCollection.Count - 26);

            }
            else
            {
                //there are 26 items
                return 0;
            }
        }
        private static StringCollection removeArbitraryNumberOfEmptyStrings( StringCollection stringCollection, int count)
        {
            for(int i = stringCollection.Count - 1; i >= 0; i--)
            {
                stringCollection.RemoveAt(i);
            }
            return stringCollection;

        }
        private static StringCollection addArbitraryNumberOfEmptyStrings(StringCollection stringCollection, int count, string item)
        {
            for(int i = 0; i < count;)
            {

                stringCollection.Add(item);
                i++;
            }
            return stringCollection;

        }
        private static StringCollection initNullCollection(StringCollection stringCollection, string item)
        {

            if(stringCollection == null)
            {
                stringCollection = new StringCollection();
            }
            for(int i = 0; i < 26;)
            {

                stringCollection.Add(item);
                i++;
            }
            return stringCollection;


        }
    }
}
