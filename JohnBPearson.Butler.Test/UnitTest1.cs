using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JohnBPearson.KeyBindingButler.Model;
using System.Runtime.InteropServices;
using System.Linq;

namespace JohnBPearson.Butler.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string goodDescString = "slot1|||||||||||||||||||||||||slot26";
            const string goodKeys = "a|b|c|d|e|f|g|h|i|j|k|l|m|n|o|p|q|r|s|t|u|v|w|x|y|z";
            const string badSDatatring1 = "||||||||||||";
            const string goodDataString = "slot1|||||||||||||||||||||||||slot26";

           var testData = new KeyAndDataStringLiterals() { Descriptions = goodDescString,Keys= goodKeys, Values = goodDataString };
           
            var lists = new ContainerList(testData);

            var result = lists.Items;

            Assert.IsNotNull(result);
            var testList = result.ToList();
            Assert.IsTrue(testList.Count == 26);

        }
    }
}
