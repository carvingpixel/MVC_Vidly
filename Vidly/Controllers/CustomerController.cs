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
        // GET: Customer -- getcustomers list 
        public ViewResult Index()
        {
            ViewBag.Message = "Your application description page.";

            var customers = GetCustomers();

            return View(customers);
        }


        //GET: Customer/Details/? set a customer from getcustomers and iterate to find where c.id == id
        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }


        // not using a database and we need more than one customer so we setup a list of customers
        // then we need a way to get them so let's IEnum via a set method GetCustomers()
        // the can call from views/actions
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer() {Id = 1, Name = "Lokin Crook"},
                new Customer() {Id = 2, Name = "Mary Poppins"}
            };
        }


    }
}