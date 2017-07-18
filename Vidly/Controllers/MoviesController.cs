using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
   
        // GET: Movies/Random
        public ActionResult Random()
        {
            // Instantiate Movie Object based on Model.cs //
            // put the movie model into our view so we can render it//
            // return View(movie);

            Movie movie = new Movie()
            {
                Name = "Hitchhiker's Guide to the Galaxy",
                Author = "Douglas Adams",
                Id = 1           
            };

            //ViewData["MovieMagicS"] = movie;   // dont use ViewData beacuse of magic strings 

            ViewBag.MovieVBName = movie.Name;  //dont use viewbag - magic method issues MovieMagicM too fragile spreads through code
            ViewBag.MovieVB = movie;  //dont use viewbag - magic method issues MovieMagicM too fragile spreads through code
            return View();

            ////3.Instead 
            //var viewResult = new ViewResult();
            ////viewResult.ViewData.Model
            //// so movie passed will be assigned to the Model property
            //// ViewData is a DataDictionary can use with key value pairs or its model property to work with an object(preffered way)
            //return View(movie);
        }


        // GET: Movies/Random
        public ActionResult Edit(int id) 
        {
                // /movies/edit?id=44
                // TempData["msg"] = "<script>alert('Edit');</script>";
            return Content("id=" + id);

        }


        // GET: Movies/Random
        public ActionResult Create(string passMe)
        {
            // /movies/Create?passMe=test+me
            TempData["msg"] = "<script>alert('Edit');</script>";
            return Content($"Here You Go: {passMe}");

        }

        //Get: Movies/
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }


        //Attribute Routing//          // appply route atribute and pass the url template  
        //regex regular expression for constraint for digit repeated 4 times and range from 1-12
        //get action ByReleaseAttribute // this is attributes based custom routing.
        //        [Route("movies/attributes/{year}/{month:regex(\\d{4}):range(1, 12)}")]
        [Route("movies/attributes/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseAttribute(int year, int month)
        {
            return Content(year + " & " + month);
        }


        //Get (mvcaction4) Action == ByReleaseDate  // this is based on convention /legacy custom routes
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }



    }
}