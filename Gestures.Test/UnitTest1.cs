using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JohnBPearson.Application.Gestures.Model;
using JohnBPearson.Application.Gestures.Model.Utility;
using System.Runtime.InteropServices;
using System.Linq;
using JohnBPearson.Cypher;
using JohnBPearson.HotkeyButler.DataAccess;
using System.Net.Security;
using System.Data;

namespace JohnBPearson.Butler.Test
{
    [TestClass]
    public class UnitTest1
    {
        const string goodDescString = "slot1|||||||||||||||||||||||||slot26";
        const string goodKeys = "a|b|c|d|e|f|g|h|i|j|k|l|m|n|o|p|q|r|s|t|u|v|w|x|y|z";
        const string badDatatring1 = "||||||||||||";
        const string goodDataString = "slot1|||||||||||||||||||||||||slot26";
        [TestMethod]
        public void assertCountOfHotkeys1()
        {


            var testData = new KeyAndDataStringLiterals() { Descriptions = goodDescString, Keys = goodKeys, Values = goodDataString };

            var lists = new ContainerList(testData);

            var result = lists.Items;

            Assert.IsNotNull(result);
            var testList = result.ToList();
            Assert.IsTrue(testList.Count == 26);

        }

        [TestMethod]
        public void assertEncodingDecoding()
        {
            //var test = "TestEncoding";
            //var encoded = Base64Url.Encode(test);
            //Assert.AreEqual(Base64Url.Decode(encoded), test, true);
            DataProtect dp = new DataProtect();
          byte[] result=  dp.EncryptToBytes("test");
            Assert.IsNotNull(result);
            Console.WriteLine(result.ToString());
          string decrypted =  dp.DecryptBytes(result);
            Console.WriteLine(decrypted.ToString());

        }


        [TestMethod]
        public void dataA1ccessSQLite()
        {
         DataTable result =   SqliteDataAccess.Read(@"select * from TargetApplication t inner join Version v on t.TargetId = v.TargetApplication");
            Assert.IsTrue(result.Rows.Count > 0);
            // test
            // SqliteDataAcces           s.ExecuteReader("select * from Application inner join Version on Application.Id = Version.Application");
            object[] parms = new object[4];
            parms[0] = 0;
            parms[1] = 0;
            parms[2] = 0;
            parms[3] = 25;
            parms[4] = 1;
            SqliteDataAccess.ExecuteNonQuery("UPDATE Version    SET   Major = ?,        Minor = ?,        Build = ?,  Revision = ?  WHERE VersionId = ? ",
                parms );
                                       
        }


        [TestMethod] 
        public void CheckEncryption()
        {

        
        }
    }
}
