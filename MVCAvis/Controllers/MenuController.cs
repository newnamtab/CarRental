using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAvis.Models;
using MVCAvis.WcfService;

namespace MVCAvis.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult MenuPage()
        {
            RentalAgent rental = (RentalAgent)Session["UserSession"];
            ViewData["ActiveUserName"] = rental.UserName;
            ViewData["tiden"] = DateTime.Now;
            return View();
        }

        [HttpPost]
        public ActionResult MenuPage(string redirect)
        {
            RentalAgent rental = (RentalAgent)Session["UserSession"];
            ViewData["ActiveUserName"] = rental.UserName;
            switch (redirect)
            {
                case "Søg bestilling":
                    return RedirectToAction("searchOrder", "Orders");

                case "Opret bestilling":
                    return RedirectToAction("createOrder", "Orders");

                case "Rediger/slet":
                    if (rental == null)
                    {
                        return RedirectToAction("MenuPage", "Menu");
                    }
                    else if (rental.AgentId == 11)
                    {
                        return RedirectToAction("Rediger", "Admin");
                    }
                    break;
                default:
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotImplemented, "Something went wrong. Try again" + redirect);
            }
            return View();

        }
    }
}