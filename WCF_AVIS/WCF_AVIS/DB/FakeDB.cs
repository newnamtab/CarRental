using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WCF_AVIS.Models;

namespace WCF_AVIS.DB
{
    public class FakeDB : IDB
    {
        public List<Reservation> DB { get;  set; }
        public List<CarCategory> CarCategories { get; set; }
        public List<RentalStation> RentalStations { get;  set; }
        private List<Customer> Customers { get; set; }
        private List<Car> Cars { get; set; }
        private List<RentalAgent> Employees { get; set; }
        private LoginHelper help = new LoginHelper();
        private object _lockKey = new object();

        public FakeDB()
        {
            CreateDB();
        }

        // INSTANTIERER EN FAKEDATABASE
        private void CreateDB()
        {
            DB = new List<Reservation>();
            Customers = new List<Customer>();
            Cars = new List<Car>();
            CarCategories = new List<CarCategory>();
            Employees = new List<RentalAgent>();
            RentalStations = new List<RentalStation>();


            Customer cust = new Customer();
            cust.FirstName = "Mathias";
            cust.LastName = "Johnson";
            cust.Street = "Helmersgade 32";
            cust.PostalCode = "5000";
            cust.City = "Odense C";
            cust.TelephoneNumber = "+45 120 450 780";
            cust.Email = "matias@gmail.com";
            cust.BirthDate = new DateTime(1992, 08, 20);
            cust.CustomerID = null;

            Customer cust1 = new Customer();
            cust1.FirstName = "Søren";
            cust1.LastName = "Hansen";
            cust1.Street = "Odinsgade 12";
            cust1.PostalCode = "5000";
            cust1.City = "Odense C";
            cust1.TelephoneNumber = "+45 12 27 12";
            cust1.Email = "søren@gmail.com";
            cust1.BirthDate = new DateTime(1979, 08, 03);
            cust1.CustomerID = "DW123AL";

            Customer cust2 = new Customer();
            cust2.FirstName = "Thomas";
            cust2.LastName = "Crown";
            cust2.Street = "CoronationStreet 62";
            cust2.PostalCode = "WP 623 WA 987";
            cust2.City = "London Downtown";
            cust2.TelephoneNumber = "+371 159 753";
            cust2.Email = "Thomas@gmail.com";
            cust2.BirthDate = new DateTime(2008, 12, 24);
            cust2.CustomerID = "123TCQ";

            Customer cust3 = new Customer();
            cust3.FirstName = "Benny";
            cust3.LastName = "Jurgensen";
            cust3.Street = "Holessteder Strasse 25 ";
            cust3.PostalCode = "52125";
            cust3.City = "Berlin";
            cust3.TelephoneNumber = "+31 120450780";
            cust3.Email = "Bejo@gmail.com";
            cust3.BirthDate = new DateTime(1924, 01, 01);
            cust3.CustomerID = "bejo123";

            Customer cust4 = new Customer();
            cust4.FirstName = "Christian";
            cust4.LastName = "Johansen";
            cust4.Street = "Gravene";
            cust4.PostalCode = "4900";
            cust4.City = "In Denmark";
            cust4.TelephoneNumber = "29 29 2929";
            cust4.Email = "Christian@gmail.com";
            cust4.BirthDate = new DateTime(1975, 01, 01);
            cust4.CustomerID = "chri123";

            Customer cust5 = new Customer();
            cust5.FirstName = "Kristina";
            cust5.LastName = "Jansen";
            cust5.Street = "Skøgestræde 69";
            cust5.PostalCode = "2900";
            cust5.City = "Happiness";
            cust5.TelephoneNumber = "0190 433 4333";
            cust5.Email = "skøge@gmail.com";
            cust5.BirthDate = new DateTime(1985, 01, 01);
            cust5.CustomerID = "bejo123";

            Customers.Add(cust);
            Customers.Add(cust1);
            Customers.Add(cust2);
            Customers.Add(cust3);
            Customers.Add(cust4);
            Customers.Add(cust5);

            CarCategory category = new CarCategory();
            category.ID = 'A';
            CarCategory category1 = new CarCategory();
            category1.ID = 'B';
            CarCategory category2 = new CarCategory();
            category2.ID = 'C';
            CarCategory category3 = new CarCategory();
            category3.ID = 'I';
            CarCategory category4 = new CarCategory();
            category4.ID = 'O';

            CarCategories.Add(category);
            CarCategories.Add(category1);
            CarCategories.Add(category2);
            CarCategories.Add(category3);
            CarCategories.Add(category4);

            RentalStation station = new RentalStation();
            station.StationId = 1;
            station.StationCode = "OE1";
            station.Street = "Rugardsvej 5";
            station.PostalCode = "5000";
            station.City = "Odense C";
            station.TelephoneNumber = "11 22 33 44";

            RentalStation station1 = new RentalStation();
            station1.StationId = 2;
            station1.StationCode = "KBH";
            station1.Street = "København gade 2";
            station1.PostalCode = "1000";
            station1.City = "København";
            station1.TelephoneNumber = "12 23 34 45";

            RentalStation station2 = new RentalStation();
            station2.StationId = 3;
            station2.StationCode = "ARH";
            station2.Street = "Århusvej 12";
            station2.PostalCode = "8000";
            station2.City = "Århus C";
            station2.TelephoneNumber = "12 13 14 15";

            RentalStation station3 = new RentalStation();
            station3.StationId = 4;
            station3.StationCode = "SLA";
            station3.Street = "SlåtåbenigulvetGade 56";
            station3.PostalCode = "4500";
            station3.City = "Skagen Downtown";
            station3.TelephoneNumber = "10 20 30 40";

            RentalStation station4 = new RentalStation();
            station4.StationId = 5;
            station4.StationCode = "NY3";
            station4.Street = "Roesparker Alle 56";
            station4.PostalCode = "9500";
            station4.City = "L. Tyndskids marker";
            station4.TelephoneNumber = "555 10 20 99";

            RentalStation station5 = new RentalStation();
            station5.StationId = 6;
            station5.StationCode = "EBJ";
            station5.Street = "Fiskergade 28";
            station5.PostalCode = "6500";
            station5.City = "Esbjerg C";
            station5.TelephoneNumber = "66 77 88 99";

            RentalStations.Add(station);
            RentalStations.Add(station1);
            RentalStations.Add(station2);
            RentalStations.Add(station3);
            RentalStations.Add(station4);
            RentalStations.Add(station5);

            RentalAgent agent = new RentalAgent("Thomas", "Crone", "EALstud", 69, help.CreateSalt(), "password", station1);
            RentalAgent agent1 = new RentalAgent("Morten", "Møller", "Admin", 11, help.CreateSalt(), "password", station1);
            RentalAgent agent2 = new RentalAgent("Søren", "Hansen", "Employee", 69, help.CreateSalt(), "password", station1);

            Employees.Add(agent);
            Employees.Add(agent1);
            Employees.Add(agent2);

            Car car = new Car();
            car.NumberPlate = "BA12345";
            car.Make = "Ford";
            car.Model = "Fiesta";
            car.Colour = "RED";
            car.Odometer = 7;
            car.Category = category1;

            Car car1 = new Car();
            car1.NumberPlate = "BB98765";
            car1.Make = "Nissan";
            car1.Model = "Qashqai";
            car1.Colour = "BLACK";
            car1.Odometer = 1203;
            car1.Category = category3;

            Car car2 = new Car();
            car2.NumberPlate = "BC45678";
            car2.Make = "Iveco";
            car2.Model = "Daily";
            car2.Colour = "WHITE";
            car2.Odometer = 52456;
            car2.Category = category4;

            Car car3 = new Car();
            car3.NumberPlate = "BD54321";
            car3.Make = "Toyota";
            car3.Model = "Avensis";
            car3.Colour = "Blue";
            car3.Odometer = 3500;
            car3.Category = category;

            Car car4 = new Car();
            car4.NumberPlate = "BE58792";
            car4.Make = "Mercedes";
            car4.Model = "A200";
            car4.Colour = "GREY";
            car4.Odometer = 2312;
            car4.Category = category3;

            Car car5 = new Car();
            car5.NumberPlate = "BF58974";
            car5.Make = "Renault";
            car5.Model = "Clio";
            car5.Colour = "GREEN";
            car5.Odometer = 24500;
            car5.Category = category2;

            Car car6 = new Car();
            car6.NumberPlate = "BG25897";
            car6.Make = "BMW";
            car6.Model = "320";
            car6.Colour = "BLACK";
            car6.Odometer = 1857;
            car6.Category = category3;

            Car car7 = new Car();
            car7.NumberPlate = "BH15935";
            car7.Make = "VW";
            car7.Model = "Transporter";
            car7.Colour = "WHITE";
            car7.Odometer = 38951;
            car7.Category = category4;

            Car car8 = new Car();
            car8.NumberPlate = "BI74853";
            car8.Make = "AUDI";
            car8.Model = "A4";
            car8.Colour = "YELLOW";
            car8.Odometer = 159;
            car8.Category = category3;

            Car car9 = new Car();
            car9.NumberPlate = "AA11223";
            car9.Make = "Ferrari";
            car9.Model = "Super Duper";
            car9.Colour = "RED";
            car9.Odometer = 456;
            car9.Category = category;

            Car car10 = new Car();
            car10.NumberPlate = "BU774013";
            car10.Make = "Citroen";
            car10.Model = "C4";
            car10.Colour = "UGLY";
            car10.Odometer = 0;
            car10.Category = category2;

            Cars.Add(car);
            Cars.Add(car1);
            Cars.Add(car2);
            Cars.Add(car3);
            Cars.Add(car4);
            Cars.Add(car5);
            Cars.Add(car6);
            Cars.Add(car7);
            Cars.Add(car8);
            Cars.Add(car9);
            Cars.Add(car10);

            Reservation res = new Reservation();
            res.Reservationsnummer = "123465DK1";
            res.Customer = Customers[1];
            res.BilCat = CarCategories[1];
            res.StartStation = RentalStations[1];
            res.EndStation = RentalStations[1];
            res.StartDate = new DateTime(2016, 12, 10, 12, 30, 00);
            res.EndDate = new DateTime(2016, 12, 24, 12, 30, 00);
            res.TotalPrize = 1230;

            Reservation res1 = new Reservation();
            res1.Reservationsnummer = "123456DK5";
            res1.Customer = Customers[3];
            res1.BilCat = CarCategories[0];
            res1.StartStation = RentalStations[0];
            res1.EndStation = RentalStations[0];
            res1.StartDate = new DateTime(2016, 12, 08, 08, 30, 00);
            res1.EndDate = new DateTime(2016, 12, 12, 08, 30, 00);
            res1.TotalPrize = 245;

            Reservation res2 = new Reservation();
            res2.Reservationsnummer = "123789DK0";
            res2.Customer = Customers[2];
            res2.BilCat = CarCategories[4];
            res2.StartStation = RentalStations[2];
            res2.EndStation = RentalStations[2];
            res2.StartDate = new DateTime(2017, 01, 01, 09, 15, 00);
            res2.EndDate = new DateTime(2017, 02, 01, 09, 15, 00);
            res2.TotalPrize = 3499;

            Reservation res3 = new Reservation();
            res3.Reservationsnummer = "123654DK2";
            res3.Customer = Customers[4];
            res3.BilCat = CarCategories[2];
            res3.StartStation = RentalStations[1];
            res3.EndStation = RentalStations[1];
            res3.StartDate = new DateTime(2016, 12, 03, 09, 30, 00);
            res3.EndDate = new DateTime(2017, 08, 08, 09, 30, 00);
            res3.TotalPrize = 852;

            Reservation res4 = new Reservation();
            res4.Reservationsnummer = "123543DK9";
            res4.Customer = Customers[5];
            res4.BilCat = CarCategories[0];
            res4.StartStation = RentalStations[0];
            res4.EndStation = RentalStations[0];
            res4.StartDate = new DateTime(2016, 12, 24, 10, 30, 00);
            res4.EndDate = new DateTime(2016, 11, 30, 15, 00, 00);
            res4.TotalPrize = 987;

            Reservation res5 = new Reservation();
            res5.Reservationsnummer = "123568DK4";
            res5.Customer = Customers[1];
            res5.BilCat = CarCategories[2];
            res5.StartStation = RentalStations[2];
            res5.EndStation = RentalStations[2];
            res5.StartDate = new DateTime(2016, 12, 24, 12, 0, 00);
            res5.EndDate = new DateTime(2016, 12, 25, 12, 00, 00);
            res5.TotalPrize = 4562;

            Reservation res6 = new Reservation();
            res6.Reservationsnummer = "123459DK9";
            res6.Customer = Customers[1];
            res6.BilCat = CarCategories[3];
            res6.StartStation = RentalStations[1];
            res6.EndStation = RentalStations[3];
            res6.StartDate = new DateTime(2017, 01, 01, 16, 00, 00);
            res6.EndDate = new DateTime(2014, 01, 10, 15, 00, 00);
            res6.TotalPrize = 2356;

            Reservation res7 = new Reservation();
            res7.Reservationsnummer = "123568DK5";
            res7.Customer = Customers[0];
            res7.BilCat = CarCategories[3];
            res7.StartStation = RentalStations[0];
            res7.EndStation = RentalStations[3];
            res7.StartDate = new DateTime(2016, 12, 02, 16, 30, 00);
            res7.EndDate = new DateTime(2016, 12, 20, 16, 30, 00);
            res7.TotalPrize = 974;

            Reservation res8 = new Reservation();
            res8.Reservationsnummer = "142536DK4";
            res8.Customer = Customers[0];
            res8.BilCat = CarCategories[0];
            res8.StartStation = RentalStations[0];
            res8.EndStation = RentalStations[0];
            res8.StartDate = new DateTime(2017, 02, 10, 11, 45, 00);
            res8.EndDate = new DateTime(2017, 02, 13, 11, 45, 00);
            res8.TotalPrize = 654;

            Reservation res9 = new Reservation();
            res9.Reservationsnummer = "142536DK9";
            res9.Customer = Customers[2];
            res9.BilCat = CarCategories[4];
            res9.StartStation = RentalStations[2];
            res9.EndStation = RentalStations[3];
            res9.StartDate = new DateTime(2016, 10, 24, 13, 30, 00);
            res9.EndDate = new DateTime(2016, 10, 28, 13, 30, 00);
            res9.TotalPrize = 1100;

            DB.Add(res);
            DB.Add(res1);
            DB.Add(res2);
            DB.Add(res3);
            DB.Add(res4);
            DB.Add(res5);
            DB.Add(res6);
            DB.Add(res7);
            DB.Add(res8);
            DB.Add(res9);


        }

        // INDSÆT NY RESERVATION
        public void Insert(Reservation res)
        {
            lock (_lockKey)
            {
                DB.Add(res);
            }
           
        }

        // SØG ENKELT RESERVATION DER MATCHER RESERVATIONSNUMMERET
        public Reservation searchReservation(string resNum)
        {
            foreach (Reservation reservation in DB)
            {
                if (resNum.ToLower() == reservation.Reservationsnummer.ToLower())
                {
                    return reservation;
                }
            }
            return null;
        }

        // SØG LISTE AF RESERVATIONER DER MATCHER FLERE SØGEPARAMETRE
        public List<Reservation> Search(Reservation res)
        {
            List<Reservation> returnlist = new List<Reservation>();
            lock (_lockKey)
            {   // Hvis der er et reservationsnummer, så søg på det først.
                if (res.Reservationsnummer != "" && res.Reservationsnummer != null)
                {
                    Reservation reservation = searchReservation(res.Reservationsnummer);

                    if (reservation != null)
                    {
                        returnlist.Add(reservation);

                    }
                    return returnlist;
                }
            }
           

            lock (_lockKey)
            {
                foreach (Reservation reservation in DB)
                {
                    if (res.Customer.FirstName == "" || res.Customer.FirstName == null || CompareStrings(res.Customer.FirstName, reservation.Customer.FirstName))
                    {
                        if ( res.Customer.LastName == "" || res.Customer.LastName == null || CompareStrings(res.Customer.LastName, reservation.Customer.LastName))
                        {
                            if (res.Customer.Street == "" || res.Customer.Street == null || reservation.Customer.Street.ToLower() == res.Customer.Street.ToLower())
                            {
                                if (res.Customer.Email == "" || res.Customer.Email == null || reservation.Customer.Email.ToLower() == res.Customer.Email.ToLower())
                                {
                                    if (res.Customer.TelephoneNumber == "" || res.Customer.TelephoneNumber == null || reservation.Customer.TelephoneNumber.Replace(" ", "") == res.Customer.TelephoneNumber.Replace(" ", ""))
                                    {
                                        if (reservation.StartDate >= res.StartDate && reservation.StartDate <= res.EndDate)
                                        {
                                            returnlist.Add(reservation);
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
                return returnlist;
            }
        }

        // NOGET AF CRONES SØGEALGORITME
        private bool stringSearch(string s1, string s2)
        {
            if (CompareStrings(s1, s2) || CompareStrings(s2, s1))
            {
                return true;
            }
            return false;
        }
        // NOGET AF CRONES SØGEALGORITME
        private bool CompareStrings(string s1, string s2)
        {
            string s1Up = s1.ToUpper();
            string s2Up = s2.ToUpper();
            string tester = "";
            for (int i = 0; i < s1Up.Length - 3; i++)
            {
                try
                {
                    tester = s1Up[i].ToString() + s1Up[i + 1].ToString() + s1Up[i + 2].ToString() +
                             s1Up[i + 3].ToString();
                    if (s2Up.Contains(tester))
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                }
            }
            return false;
        }

        // RETURNER ALLE RESERVATIONER
        public List<Reservation> GetReservations()
        {
            lock (_lockKey)
            {
                return DB;
            }
        }

        //CHECK OM INCOMING STATION MATCHER EN GYLDIG STATIONSKODE
        public RentalStation MatchStation(string stationcode)
        {
            lock (_lockKey)
            {
                foreach (RentalStation station in RentalStations)
                {
                    if (stationcode == station.StationCode)
                    {
                        return station;
                    }
                }
                return null;
            }
        }
        //
        public RentalAgent Login(string user, string password)
        {
            // LoginHelper help = new LoginHelper();
            foreach (RentalAgent us in Employees)
            {
                if (us.UserName == user && help.Hasher(password, us.Salt) == us.HashPass)
                {
                    return us;
                }
            }
            return null;
        }
        public int loginAccess(string user)
        {
            foreach (RentalAgent us in Employees)
            {
                if (us.UserName == user && us.AgentId == 69)
                {
                    return 69;
                }
                if (us.UserName == user && us.AgentId == 11)

                    return 11;
            }
            return 0;
        }
        public string LoggedUser(string auser)
        {
            return "";
        }

        public bool AddRenAgent(RentalAgent agent)
        {
            Employees.Add(agent);
            return true;
        }

        public bool AddNewCar(Car coche)
        {
            Cars.Add(coche);
            return true;
        }
        public void DeleteOrder(Reservation reser)
        {
            for (int i = 0; i < DB.Count; i++)
            {
                if (DB[i].Reservationsnummer == reser.Reservationsnummer)
                {
                    if (DB[i].Status == Status.Active)
                    {
                        DB[i].Status = Status.Terminated;
                    }
                }
            }
        }

        // OPDATER RESERVATION I FAKEDATABASE
        public void Update(Reservation reservation)
        {
            lock (_lockKey)
            {
                for (int i = 0; i < DB.Count; i++)
                {
                    if (DB[i].Reservationsnummer == reservation.Reservationsnummer)
                    {
                        DB[i] = reservation;
                    }
                }
            }
        }

        public List<RentalStation> GetStations()
        {
            return RentalStations;
        }
        public List<CarCategory> GetCategories()
        {
            return CarCategories;
        }
        // HVER DAG IMELLEM 2 DATOER
        //private IEnumerable<DateTime> EachDayBetween(DateTime fromDate, DateTime toDate)
        //{
        //    for (var day = fromDate.Date; day.Date <= toDate.Date; day = day.AddDays(1))
        //        yield return day;
        //}

    }
}

