using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

namespace WCF_AVIS
{
    public enum Status { Active, Terminated }


    [DataContract]
    [Serializable]
    public class Reservation
    {
        private string _ReservationNumber { get; set; }
        private Customer _Customer { get; set; }
        private CarCategory _BookedCategory { get; set; }
        private DateTime _StartDate { get; set; }
        private DateTime _ReturnDate { get; set; }
        private RentalStation _RentalStation { get; set; }
        private RentalStation _ReturnStation { get; set; }
        private double _DailyPrice { get; set; }
        private double _TotalPrice { get; set; }
        private int _versionFlag { get; set; }
        

        [DataMember]
        public string Reservationsnummer { get { return this._ReservationNumber; } set { this._ReservationNumber = value; } }
        [DataMember]
        public Customer Customer { get { return this._Customer; } set { this._Customer = value; } }
        [DataMember]
        public DateTime StartDate { get { return this._StartDate; } set { this._StartDate = value; } }
        [DataMember]
        public DateTime EndDate { get { return this._ReturnDate; } set { this._ReturnDate = value; } }
        [DataMember]
        public CarCategory BilCat { get { return this._BookedCategory; } set { this._BookedCategory = value; } }
        [DataMember]
        public RentalStation StartStation { get { return this._RentalStation; } set { this._RentalStation = value; } }
        [DataMember]
        public RentalStation EndStation { get { return this._ReturnStation; } set { this._ReturnStation = value; } }
        [DataMember]
        public Status Status { get; set; }
        [DataMember]
        public double TotalPrize { get { return this._TotalPrice; } set { this._TotalPrice = value; } }
        [DataMember]
        public int Insurance { get; set; }

        public Reservation(DateTime startDate, DateTime endDate, CarCategory bilCat, string startStation, string endStation, string firstName, string lastName, string address, int telephoneNumber, string email)
        {
            this._Customer = new Customer();
            this._BookedCategory = new CarCategory();
            this._RentalStation = new RentalStation();
            this._ReturnStation = new RentalStation();
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.BilCat = bilCat;
            this.StartStation = new DB.FakeDB().MatchStation(startStation);
            this.EndStation = new DB.FakeDB().MatchStation(endStation);
            this.Customer.FirstName = firstName;
            this.Customer.LastName = lastName;
            this.Customer.Street = address;
            this.Customer.TelephoneNumber = telephoneNumber.ToString();
            this.Customer.Email = email;
            this.Status = Status.Active;
        }
        //PRIVATE CONSTRUCTOR FOR INTERNAL USE
        private Reservation(string reservationsnummer, DateTime startDate, DateTime endDate, CarCategory bilCat, RentalStation startStation, RentalStation endStation, string firstName, string lastName, string address, int telephoneNumber, string email, double totalPrize)
        {
            // NOT IMPLEMENTED OR USED YET
            this.Reservationsnummer = reservationsnummer;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.BilCat = bilCat;
            this.StartStation = startStation;
            this.EndStation = endStation;
            this.Customer.FirstName = firstName;
            this.Customer.LastName = lastName;
            this.Customer.Street = address;
            this.Customer.TelephoneNumber = telephoneNumber.ToString();
            this.Customer.Email = email;
            this.TotalPrize = totalPrize;
            this.Status = Status.Active;
        }

        public Reservation(CarCategory bilcat, string startstation, DateTime start, DateTime end)
        {
            this.Customer = new Customer();
            this.BilCat = new CarCategory();
            this.StartStation = new RentalStation();
            this.EndStation = new RentalStation();
            this.StartDate = start;
            this.EndDate = end;
            this.BilCat = bilcat;
            this.StartStation = new DB.FakeDB().MatchStation(startstation);
            this.TotalPrize = 0;
            this.Reservationsnummer = "UNASSIGNED";
            this.Status = Status.Active;
        }
        public Reservation()
        {

            this.Customer = new Customer();
            this._BookedCategory = new CarCategory();
            this.StartStation = new RentalStation();
            this.EndStation = new RentalStation();
            this._DailyPrice = 0;
            this.Reservationsnummer = null;
            this.StartDate = DateTime.Today;
            this.EndDate = DateTime.Today.AddDays(2);
            this.BilCat = new CarCategory();
            this.Customer.FirstName = null;
            this.Customer.LastName = null;
            this.Customer.Street = null;
            this.Customer.PostalCode = null;
            this.Customer.City = null;
            this.Customer.TelephoneNumber = null;
            this.Customer.Email = null;
            this.TotalPrize = 0;
            this.Insurance = 0;
            this.Status = Status.Active;

        }
        public bool CheckFlag(Reservation controlRes)
        {
            
            if (this._versionFlag < controlRes._versionFlag)
            {
                return true;

            }
            return false;
        }
        public void SetVersion()
        {
            this._versionFlag++;
        }
    }
}
