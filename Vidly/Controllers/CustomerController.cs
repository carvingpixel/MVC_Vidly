using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;


namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ViewResult Index()
        {
            ViewBag.Message = "Your application description page.";

            var customersLT = new List<Customer>
            {
                new Customer() {Name = "Lokin Crook", Id = 1},
                new Customer() {Name = "Scott Kelley", Id = 2}
            };

            var custViewModel = new IndexCustomersViewModel
            {  //list 
                Customers = customersLT
            };

            return View(custViewModel);
        }


        //GET: Customer/Details/?
        public ActionResult Details(int? custId)
        {
            if (!custId.HasValue)
                custId = 1;

            ViewBag.ID = custId;
            ViewBag.Message = "Viewing Customers Page: " + custId;

            return Content("id=" + custId);
        }

    }
}