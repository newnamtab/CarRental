using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCAvis;
using MVCAvis.Models;
using WCF_AVIS;
using WCF_AVIS.Models;
using WCF_AVIS.DB;



namespace UnitTest_AVIS
{
    [TestClass]
    public class TestClass
    {
        private FakeDB db = new FakeDB();

        [TestMethod]
        public void OpretBestillingTest()
        {
            bool tester = false;
            Reservation TestRes = TestReservation();
            db.Insert(TestRes);
            foreach (Reservation res in db.DB)
            {
                if (res.Equals(TestRes))
                {
                    tester = true;
                }
            }
            Assert.IsTrue(tester);
        }

        [TestMethod]
        public void SøgBestillingTest()
        {
            bool tester = false;
            Reservation testRes1 = TestReservation();
            Reservation testRes2 = TestReservation();
            testRes2.Customer.FirstName = "Ulrik";
            db.Insert(testRes1);
            db.Insert(testRes2);
            Reservation searchRes = new Reservation();
            searchRes.Customer.FirstName = "Datboy";
            List<Reservation> searchResult = db.Search(searchRes);
            foreach (Reservation res in searchResult)
            {
                if (res.Equals(testRes1))
                {
                    tester = true;
                }
                if (res.Equals(testRes2))
                {
                    throw new Exception("Finder forkert res");
                }
            }
            Assert.IsTrue(tester);
        }

        [TestMethod]
        public void RedigerBestillingTest()
        {
            Reservation testRes1 = TestReservation();
            db.Insert(testRes1);
            Assert.IsTrue(db.searchReservation(testRes1.Reservationsnummer).Customer.Email == "boi@dat.com");
            testRes1.Customer.Email = "dat@boi.com";
            db.Update(testRes1);
            Assert.IsTrue(db.searchReservation(testRes1.Reservationsnummer).Customer.Email == "dat@boi.com");
        }

        [TestMethod]
        public void LoginTest()//opretter bruger og logger ind med denne
        {
            RentalAgent agent = new RentalAgent("Dat", "boi","Datboi", 69, new LoginHelper().CreateSalt(),"kodeord", db.RentalStations[0]);
            db.AddRenAgent(agent);
            Assert.IsFalse(db.Login("Forkert", "login")!= null);
            Assert.IsTrue(db.Login("Datboi", "kodeord").Equals(agent));
        }

        [TestMethod]
        public void UdregnPris()
        {
            //Kan ikke testes da logikken ligger i Avisservice (Vi kan ikke tilgå da vi får fejl ved session)
        }
        
        public Reservation TestReservation()
        {
            Reservation TestRes = new Reservation(DateTime.Today, DateTime.Today.AddDays(15), db.CarCategories[1], "OE1", "KBH", "Datboi", "Petersen", "EALvej 18", 55442233, "boi@dat.com");

            TestRes.Reservationsnummer = "100100DK1";
            return TestRes;
        }
    }
}
