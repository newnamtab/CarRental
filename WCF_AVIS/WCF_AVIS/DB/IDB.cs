using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_AVIS
{
    public interface IDB
    {
        void Insert(Reservation res);
        List<Reservation> Search(Reservation res);
        List<Reservation> GetReservations();
        List<RentalStation> GetStations();
        List<CarCategory> GetCategories();
        RentalStation MatchStation(string stationcode);
        RentalAgent Login(string user, string password);
        int loginAccess(string user);
        //RentalAgent LoggedUser(string h);
        bool AddRenAgent(RentalAgent agent);
        bool AddNewCar(Car coche);
        void DeleteOrder(Reservation reser);
        void Update(Reservation inRes);
    }
    
}
