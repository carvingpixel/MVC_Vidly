using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }



        public ViewResult Videos()
        {

            ViewBag.Message = "Your Video page.";
            ViewBag.Message2 = "By The way, MVC Rocks! But if I change Message2 in controller, I need to change it in the view as well";

            Movie starwars = new Movie()
            {
                Name = "Star Wars",          
                Author = "George Lucas",
                Id = 6
            };
        
            return View(starwars);
        }






        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}