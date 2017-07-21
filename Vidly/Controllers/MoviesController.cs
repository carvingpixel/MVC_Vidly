using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        //Get: Index // pass an int and string - if int no value set defaults 
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return View();
            //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }


        // GET: Movies/Check - calling string library to disemenate the string passed from form
        public ActionResult Check(string passMe)
        {
            // inst movie
            Movie movie = new Movie()
            {
                Name = "Hitchhiker's Guide to the Galaxy",
                Desc = "import library to check stirngs and words",
                Id = 1,
            };

            // if null or white set defaults
            if (String.IsNullOrWhiteSpace(passMe))
            {
                movie.Author = "Douglas Adams";
                movie.UserString = "";
                Dictionary<string, int> myDictionary = new Dictionary<string, int>();
                ViewBag.MyDictionary = myDictionary;
            }
            else
            {   // call methods with string passed using viewbag here
                // does MVC have a built in htmlentities method to sanitize input?
                movie.UserString = passMe;
                ViewBag.myC = movie.CountTotal(passMe);
                ViewBag.myWU = movie.WordsUnique(passMe);
            }

            //customers list to hold users who are discussing or like this movie
            var customersLT = new List<Customer>
            {
                new Customer() {Name = "Scott Kelley"},
                new Customer() {Name = "Lokin Crook"}
            };

            // pass movie and customers list through viewmodel
            var viewModel = new CreateMovieViewModel
            {   //assign objects to viewmodel properties
                Movie = movie,
                Customers = customersLT
            };

            // now instead of passing movie, we pass the viewModel 
            return View(viewModel);
        }


        // GET: Movies/Random
        public ActionResult Random(string passMe)
        {
            // Instantiate Movie Object based on Model.cs //
            // Movie movie = new Movie() {Name = "Hitchhiker's Guide to the Galaxy"};
            // return View(movie);

            Movie movie = new Movie()
            {
                Name = "Hitchhiker's Guide to the Galaxy",
                Desc = "import library to check stirngs and words",
                Id = 1,
            };

            if (String.IsNullOrWhiteSpace(passMe))
            {
                movie.Author = "Douglas Adams";
                movie.UserString = "temp string";         
                Dictionary<string, int> myDictionary = new Dictionary<string, int>();
                ViewBag.MyDictionary = myDictionary;
            }

            else
            {
                movie.Author = passMe;
                movie.UserString = passMe;
              
                // ViewBag.MyDictionary = uniqueDict;

            }


            //[ 1. ViewData - Legacy ]------------------------------------------------------------
            //ViewData["MovieMagicS"] = movie;   // dont use ViewData beacuse of magic strings 

            //[ 2. MS update to ViewData was ViewBag ] ------------------------------------------
            //dont use viewbag - magic method issues MovieMagicM too fragile spreads through code
            //ViewBag.MovieVBName = movie.Name;  
            //ViewBag.MovieVB = movie;  
            //return View();

            ////[ 3.Instead use following ] ------------------------------------------
            //var viewResult = new ViewResult();
            ////viewResult.ViewData.Model
            //// so movie passed will be assigned to the Model property
            //// ViewData is a DataDictionary can use with key value pairs or its model property to work with an object(preffered way)
            //return View(movie);
            // 2.14 passing data to views

            //list to hold customer objects that have checked out a movie

            var customersLT = new List<Customer>
            {
                new Customer() {Name = "Customer One"},
                new Customer() {Name = "Customer Two"}
            };

            var viewModel = new RandomMovieViewModel
            {
                //init movie & customers
                Movie = movie,
                Customers = customersLT
            };

            // now instead of passing movie, we pass the viewModel we created
            return View(viewModel);

        }


        // GET: Movies/Edit contentresult to Content
        // there are many actionresults such as viewresult, contentresult etc. 
        // we can use just one of them or call actionresult allow access to all the actions
        public ContentResult Edit(int id) 
        {
                // /movies/edit?id=44
                // TempData["msg"] = "<script>alert('Edit');</script>";
            return Content("id=" + id);

        }


        // GET: Movies/Create
        public ActionResult Create(string passMe)
        {
            // /movies/Create?passMe=test+me
            @ViewBag.Response = "Here You Go: {0}" + passMe;

            return View();
        }


        //Attribute Routing//  -- appply route atribute and pass the url template  
        //regex regular expression for constraint for digit repeated 4 times and range from 1-12
        //get action ByReleaseAttribute // this is attributes based custom routing.
        // e.g.  movies/attributes/2017/8
        [Route("movies/attributes/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseAttribute(int year, int month)
        {
            return Content(year + " & " + month);
        }


        //Get (mvcaction4) Action == ByReleaseDate  // this is based on convention /l egacy custom routing
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }



    }
}