using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCAvis.WcfService;

namespace MVCAvis.Models
{
    public class Orders
    {
        public List<RentalStation> StationList { get { return new AVISserviceClient().GetStations().ToList(); } private set { } }
        public List<CarCategory> CategoryList { get { return new AVISserviceClient().GetCategories().ToList(); } private set { } }
        public Reservation CurrentReservation {get;set ;}

        public Orders()
        {
            this.StationList = new List<RentalStation>();
            this.CategoryList = new List<CarCategory>();
            this.CurrentReservation = new Reservation();
            this.CurrentReservation.BilCat = new CarCategory();
            this.CurrentReservation.Customer = new Customer();
            this.CurrentReservation.StartStation = new RentalStation();
            this.CurrentReservation.EndStation = new RentalStation();
            this.CurrentReservation.StartDate = new DateTime();
            this.CurrentReservation.EndDate = new DateTime();
            
        }
    }
   
}
