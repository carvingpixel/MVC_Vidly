using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    // setup class to hold class objects to pass into a view so we can pass more than one this way
    public class CreateMovieViewModel
    {
        //Movie object
        public Movie Movie { get; set; }

        //List of Customers
        public List<Customer> Customers { get; set; }
        
    }
}
