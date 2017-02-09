using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAvis.Models;
using MVCAvis.WcfService;

namespace MVCAvis.Controllers
{
    public class OrdersController : Controller
    {
        private AVISserviceClient Refe = new AVISserviceClient();
        private Helper hilfer = new Helper();

        [HttpGet]
        public ActionResult createOrder()
        {
            Orders model = new Orders();

            return View(model);
        }

        [HttpPost]
        public ActionResult createOrder(string confirm, FormCollection form)
        {
            Orders model = new Orders();
            model.CurrentReservation = new Reservation();
            model.CurrentReservation.Customer = new Customer();
            model.CurrentReservation.BilCat = new CarCategory();
            model.CurrentReservation.StartStation = new RentalStation();
            model.CurrentReservation.EndStation = new RentalStation();
            switch (confirm)
            {
                case "Calculate prize":
                    model.CurrentReservation.BilCat.ID = Convert.ToChar(form["cat"]);
                    model.CurrentReservation.StartStation = Refe.MatchStation(form["destination"]);
                    model.CurrentReservation.EndStation = Refe.MatchStation(form["Slutdestination"]);
                    model.CurrentReservation.Insurance = int.Parse(form["Insurance"]);
                    model.CurrentReservation.StartDate = DateTime.Parse(form["datostart"]);
                    model.CurrentReservation.EndDate = DateTime.Parse(form["datoslut"]);
                    model.CurrentReservation.Customer.FirstName = form["firstname"];
                    model.CurrentReservation.Customer.LastName = form["lastname"];
                    model.CurrentReservation.Customer.Street = form["address"];
                    model.CurrentReservation.Customer.PostalCode = form["postal"];
                    model.CurrentReservation.Customer.City = form["city"];
                    model.CurrentReservation.Customer.TelephoneNumber = form["phonenumber"];
                    model.CurrentReservation.Customer.Email = form["email"];

                    model.CurrentReservation = hilfer.calcReservationPrize(model.CurrentReservation);

                    ViewData["pris"] = model.CurrentReservation.TotalPrize;
                    ViewData["desti"] = model.CurrentReservation.StartStation.StationCode;
                    ViewData["Slutdesti"] = model.CurrentReservation.EndStation.StationCode;
                    ViewData["startdato"] = model.CurrentReservation.StartDate;
                    ViewData["slutdato"] = model.CurrentReservation.EndDate;
                    ViewData["dage"] = (model.CurrentReservation.EndDate - model.CurrentReservation.StartDate).Days;
                    ViewData["forsikring"] = model.CurrentReservation.Insurance;
                    break;
                case "Create order":


                    model.CurrentReservation.BilCat.ID = Convert.ToChar(form["cat"]);
                    model.CurrentReservation.StartStation = Refe.MatchStation(form["destination"]);
                    model.CurrentReservation.EndStation = Refe.MatchStation(form["Slutdestination"]);
                    model.CurrentReservation.StartDate = DateTime.Parse(form["datostart"]);
                    model.CurrentReservation.EndDate = DateTime.Parse(form["datoslut"]);
                    model.CurrentReservation.Insurance = int.Parse(form["Insurance"]);
                    model.CurrentReservation.Customer.FirstName = form["firstname"];
                    model.CurrentReservation.Customer.LastName = form["lastname"];
                    model.CurrentReservation.Customer.Street = form["address"];
                    model.CurrentReservation.Customer.PostalCode = form["postal"];
                    model.CurrentReservation.Customer.City = form["city"];
                    model.CurrentReservation.Customer.TelephoneNumber = form["phonenumber"];
                    model.CurrentReservation.Customer.Email = form["email"];

                    model.CurrentReservation.Reservationsnummer = hilfer.AssignReservationNumber(model.CurrentReservation);

                    Refe.SaveResevation(model.CurrentReservation);
                    break;
                case "Tilbage":
                    return RedirectToAction("MenuPage", "Menu");
                default:
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotImplemented, "Something went wrong. Try again" + confirm);
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult searchOrder()
        {
            List<Reservation> viewList = new List<Reservation>();

            var resList = Refe.GetReservations();
            foreach (Reservation reservation in resList)
            {
                viewList.Add(reservation);
            }

            return View(viewList);
        }

        [HttpPost]
        public ActionResult searchOrder(string search, FormCollection form)
        {
            List<Reservation> resList = new List<Reservation>();
            Reservation tempRes = new Reservation();
            DateTime tempStartDate;
            DateTime tempEndDate;

            switch (search)
            {
                case "Search":
                    tempRes.Reservationsnummer = form["searchreservationsnummer"];
                    tempRes.StartStation = Refe.MatchStation(form["searchstation"]);

                    if (form["searchdatostart"] != "" && DateTime.TryParse(form["searchdatostart"], out tempStartDate))
                    {
                        tempRes.StartDate = tempStartDate;
                    }
                    else tempRes.StartDate = DateTime.Now - new TimeSpan(30, 0, 0, 0);


                    if (form["searchdatoslut"] != "" && DateTime.TryParse(form["searchdatoslut"], out tempEndDate))
                    {
                        tempRes.EndDate = tempEndDate;
                    }
                    else tempRes.EndDate = DateTime.Now + new TimeSpan(30, 0, 0, 0);


                    tempRes.Customer = new Customer();
                    tempRes.Customer.FirstName = form["searchfirstname"];
                    tempRes.Customer.LastName = form["searchlastname"];
                    tempRes.Customer.Street = form["searchaddress"];
                    tempRes.BilCat = new CarCategory() { ID = 'A' };
                    tempRes.Customer.TelephoneNumber = form["searchphonenumber"];
                    tempRes.Customer.Email = form["searchemail"];

                    resList = Refe.Search(tempRes).ToList();
                    break;

                case "Reset":
                    Reservation ts = new Reservation();
                    ts.BilCat = new CarCategory();
                    tempRes.BilCat.ID = Convert.ToChar(form["cat"]);
                    ts.StartStation = Refe.MatchStation(form["destination"]);
                    ts.EndStation = Refe.MatchStation(form["destination"]);
                    ts.Customer = new Customer();
                    ts.Customer.FirstName = form["firstname"];
                    ts.Customer.LastName = form["lastname"];
                    ts.Customer.Street = form["address"];
                    ts.Customer.TelephoneNumber = form["phonenumber"];
                    ts.Customer.Email = form["email"];
                    ts.StartDate = DateTime.Parse(form["datostart"]);
                    ts.EndDate = DateTime.Parse(form["datoslut"]);

                    Refe.SaveResevation(ts);
                    break;
                case "Tilbage":
                    return RedirectToAction("MenuPage", "Menu");
                default:
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotImplemented, "Something went wrong. Try again" + search);
            }
            return View(resList);
        }

        //[HttpGet]
        //public ActionResult editOrder()
        //{
        //    Reservation res = new Reservation();
        //    return View(res);
        //}

        [HttpGet]
        public ActionResult editOrder(string reservationNumber)
        {
            Reservation res = new Reservation();
            res.BilCat = new CarCategory();
            res.BilCat.ID = 'A';
            res.Customer = new Customer();
            res.StartStation = new RentalStation();
            res.EndStation = new RentalStation();


            if (reservationNumber != "" && reservationNumber != null)
            {
                res = Refe.SearchReservation(reservationNumber);
            }


            return View(res);
        }

        [HttpPost]
        public ActionResult editOrder(string modify, FormCollection form)
        {

            Reservation tempRes = new Reservation();
            DateTime tempStartDate;
            DateTime tempEndDate;

            switch (modify)
            {
                case "Modify reservation":
                    tempRes.Reservationsnummer = form["resnumber"];
                    tempRes.StartStation = Refe.MatchStation(form["destination"]);
                    tempRes.EndStation = Refe.MatchStation(form["Slutdestination"]);

                    if (form["datostart"] != "" && DateTime.TryParse(form["datostart"], out tempStartDate))
                    {
                        tempRes.StartDate = tempStartDate;
                    }
                    else tempRes.StartDate = DateTime.Now - new TimeSpan(30, 0, 0, 0);


                    if (form["datoslut"] != "" && DateTime.TryParse(form["datoslut"], out tempEndDate))
                    {
                        tempRes.EndDate = tempEndDate;
                    }
                    else tempRes.EndDate = DateTime.Now + new TimeSpan(30, 0, 0, 0);


                    tempRes.Customer = new Customer();
                    tempRes.Customer.FirstName = form["firstname"];
                    tempRes.Customer.LastName = form["lastname"];
                    tempRes.Customer.Street = form["address"];
                    tempRes.Customer.PostalCode = form["postal"];
                    tempRes.Customer.City = form["city"];

                    tempRes.BilCat = new CarCategory() { ID = Convert.ToChar(form["cat"]) };
                    tempRes.Customer.TelephoneNumber = form["phonenumber"];
                    tempRes.Customer.Email = form["email"];

                    Refe.Update(tempRes);

                    break;

                case "Calculate prize":
                    tempRes.Reservationsnummer = form["resnumber"];
                    tempRes.Customer = new Customer();
                    tempRes.Customer.FirstName = form["firstname"];
                    tempRes.Customer.LastName = form["lastname"];
                    tempRes.Customer.Street = form["address"];
                    tempRes.Customer.PostalCode = form["postal"];
                    tempRes.Customer.City = form["city"];
                    tempRes.Customer.TelephoneNumber = form["phonenumber"];
                    tempRes.Customer.Email = form["email"];
                    tempRes.BilCat = new CarCategory();
                    tempRes.BilCat.ID = Convert.ToChar(form["cat"]);
                    tempRes.StartStation = Refe.MatchStation(form["destination"]);
                    tempRes.EndStation = Refe.MatchStation(form["Slutdestination"]);
                    tempRes.Insurance = int.Parse(form["Insurance"]);
                    tempRes.StartDate = DateTime.Parse(form["datostart"]);
                    tempRes.EndDate = DateTime.Parse(form["datoslut"]);

                    tempRes = hilfer.calcReservationPrize(tempRes);

                    ViewData["pris"] = tempRes.TotalPrize;
                    ViewData["desti"] = tempRes.StartStation.StationCode;
                    ViewData["Slutdestination"] = tempRes.EndStation.StationCode;
                    ViewData["datostart"] = tempRes.StartDate;
                    ViewData["datoslut"] = tempRes.EndDate;
                    ViewData["dage"] = (tempRes.EndDate - tempRes.StartDate).Days;
                    ViewData["forsikring"] = tempRes.Insurance;

                    break;

                case "Reset":

                    tempRes = Refe.SearchReservation(form["resnumber"]);
                    break;
                case "Delete":

                    tempRes.Reservationsnummer = form["resnumber"];
                    tempRes.Customer = new Customer();
                    tempRes.Customer.FirstName = form["firstname"];
                    tempRes.Customer.LastName = form["lastname"];
                    tempRes.Customer.Street = form["address"];
                    tempRes.Customer.PostalCode = form["postal"];
                    tempRes.Customer.City = form["city"];
                    tempRes.Customer.TelephoneNumber = form["phonenumber"];
                    tempRes.Customer.Email = form["email"];
                    tempRes.BilCat = new CarCategory();
                    tempRes.BilCat.ID = Convert.ToChar(form["cat"]);
                    tempRes.StartStation = Refe.MatchStation(form["destination"]);
                    tempRes.EndStation = Refe.MatchStation(form["Slutdestination"]);
                    tempRes.Insurance = int.Parse(form["Insurance"]);
                    tempRes.StartDate = DateTime.Parse(form["datostart"]);
                    tempRes.EndDate = DateTime.Parse(form["datoslut"]);


                    Refe.Delete(tempRes);
                    break;

                default:
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotImplemented, "Something went wrong. Try again" + modify);
            }


            return View(tempRes);
        }
    }
}