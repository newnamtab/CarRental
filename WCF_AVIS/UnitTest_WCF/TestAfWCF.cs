using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCF_AVIS;

namespace UnitTest_WCF
{
    [TestClass]
    public class TestAfWCF
    {
        [TestMethod]
        public void SearchTest()
        {
            IAVISservice Test = new AVISservice();
            Reservation newRes = Test.OpretReservation("Ford Focus", "Odense", DateTime.Today, DateTime.Today);
            Reservation searchResult = Test.Search("Odense");
            Assert.AreEqual(newRes, searchResult);
        }

        [TestMethod]
        public void CreateTest()
        {
            IAVISservice Test = new AVISservice();
            Reservation newRes = Test.OpretReservation("Ford Focus", "Odense", DateTime.Today, DateTime.Today);
            FakeDB DB = new FakeDB();
            DB.Insert(newRes);
            Assert.IsTrue(DB.DB.Contains(newRes)); 
        }
    }
}
