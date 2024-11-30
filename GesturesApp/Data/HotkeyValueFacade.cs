//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Windows.ApplicationModel.Contacts;
//using Windows.Networking.NetworkOperators;

//namespace JohnBPearson.Windows.Forms.Data
//{
//public enum CollectionNames
//{
//    HotKeyValue = 0
//}

//    public class HotkeyValueDataAccessFacade
//    {

//        private IDataAccess dataAccess;

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="dataAccess"></param>
//        /// <param name="baseHotKeys">represents a-z  on the keyboard</param>
//        public   HotkeyValueDataAccessFacade(IDataAccess<HotKeyValue> dataAccess, Array<string> baseHotKeys) 
//        {
//            this.dataAccess = dataAccess;
//            IEnumerable<HotKeyValue> initializationData = this.dataAccess.GetCollection(CollectionNames.HotKeyValue.ToString());
//            var hasItems = initializationData.FirstOrDefault();
//            if (hasItems == null) 
//            {
//                List<HotKeyValue> hkvCollection = new List<HotKeyValue>();
//                foreach (var baseHotKey in baseHotKeys)
//                {
//                    hkvCollection.Add(new HotKeyValue(baseHotKey, ""))                0
//                }
//                this.dataAccess.SetCollection(hkvCollection, CollectionNames.HotKeyValue.ToString());
//            }

//        }
//    }
//}

