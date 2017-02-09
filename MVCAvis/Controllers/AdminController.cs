using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAvis.Models;
using MVCAvis.WcfService;

namespace MVCAvis.Controllers
{
    public class AdminController : Controller
    {
        private AVISserviceClient Refe = new AVISserviceClient();
        [HttpGet]
        public ActionResult Rediger()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Rediger(string edit, FormCollection formula)
        {

            RentalAgent Ren = new RentalAgent();
            Car bil = new Car();

            switch (edit)
            {
                case "Tilføj medarbejder":

                    Ren.FirstName = formula["firstname"];
                    Ren.LastName = formula["lastname"];
                    Ren.UserName = formula["username"];
                    Ren.AgentId = int.Parse(formula["id"]);
                    Ren.HashPass = formula["password"];
                    Ren.PrimaryLocation = new RentalStation();

                    if (Refe.AddUser(Ren))
                    {
                        Response.Write("Du har tilføjet en ny medarbejder");
                    }
                    else
                    {
                        Response.Write("Der skete en fejl. Prøv igen.");
                    }
                    break;
                case "Tilføj bil":

                    bil.NumberPlate = formula["licence"];
                    bil.Make = formula["producent"];
                    bil.Model = formula["model"];
                    bil.Colour = formula["color"];
                    bil.Odometer = int.Parse(formula["odometer"]);
                    bil.Category = new CarCategory();

                    if (Refe.AddCar(bil))
                    {
                        Response.Write("Du har tilføjet en ny medarbejder");
                    }
                    else
                    {
                        Response.Write("Der skete en fejl. Prøv igen.");
                    }
                    break;
                default:
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotImplemented, "Something went wrong. Try again" + edit);
            }
            return View();
        }


    }
}