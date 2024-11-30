
//using LiteDB;
//using System.Collections.Generic;
//using System.Text;
//using Windows.Media.Audio;

//public class HotKeyValue : ICollectionItem
//{
//    [LiteDB.BsonId]
//    public string Key { get; set; }
//    public string Value { get; set; }

//    public HotKeyValue()
//    {

//    }
//    public HotKeyValue(string key, string value)
//    {
//        Key = key;
//        Value = value;
//    }
//}

//public interface IDataAccess<T> where T : ICollectionItem
//{
//    List<T> GetCollection(string collectionName);
//    void SetCollection(List<T> collection, string collectionName);

//}

//public interface ICollectionItem
//{
//    string Key { get; set; }
//}

//public class Database<T> : IDataAccess<T> where T : ICollectionItem
//{
//    private string _databasePath = "";

//    public Database()
//    {
//        this.setDefaultPath();
//    }
//    public Database(string databasePath)
//    {

//        // only need the folder to exist
//        if (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(databasePath)))
//        {
//            if (!string.IsNullOrWhiteSpace(System.IO.Path.GetFileName(databasePath)))
//                // we have a file name to so that is good
//                _databasePath = databasePath;
//        }
//        else
//        {
//            this.setDefaultPath();
//        }
//    }

//    private void setDefaultPath()
//    {
//        _databasePath = System.Windows.Forms.Application.UserAppDataPath;
//    }

//    public List<T> GetCollection(string collectionName)
//    {
//        List<T> result = null;





//        using (var db = new LiteDatabase(this._databasePath))
//        {
//            result = new List<T>();
//            // Get a collection (or create, if doesn't exist)
//            var col = db.GetCollection<T>(collectionName);

//            foreach (var item in col.FindAll())
//            {

//                result.Add(item);
//            }


//        }


//        return result;
//    }

//    public void SetCollection(List<T> collection, string collectionName)
//    {
//        using (var db = new LiteDatabase(this._databasePath))
//        {

//            db.BeginTrans();
//            var col = db.GetCollection<T>(collectionName);
//            col.DeleteAll();
//            col.InsertBulk(collection);
//            db.Commit();
//        }
//    }
//}