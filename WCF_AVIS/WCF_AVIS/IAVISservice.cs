using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_AVIS
{
    [ServiceContract]
    public interface IAVISservice
    {
        [OperationContract]
        void SaveResevation(Reservation res);
        [OperationContract]
        Reservation SearchReservation(string searchVariable);
        [OperationContract]
        List<Reservation> Search(Reservation searchVariable);
        [OperationContract]
        void Update(Reservation res);
        [OperationContract]
        void Delete(Reservation res);
        [OperationContract]
        double CalcPrice(string cat, string dest, DateTime dstart, DateTime dslut);
        [OperationContract]
        List<Reservation> GetReservations();
        [OperationContract]
        List<RentalStation> GetStations();
        [OperationContract]
        List<CarCategory> GetCategories();
        [OperationContract]
        RentalStation MatchStation(string stationcode);
        [OperationContract]
        string CreateSalt();
        [OperationContract]
        string Hasher(string pass, string salt);
        [OperationContract]
        int validateAcess(string user);
        [OperationContract]
        RentalAgent validateUser(string n, string p);
        [OperationContract]
        bool AddUser(RentalAgent ren);
        [OperationContract]
        bool AddCar(Car car);
    }
    
}
