using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        //movies class model to be instantiated by controller and then rendered to view via Return view(movie)

        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Quote { get; set; }

        //moves/random
        // create a movieController with an action called random

    }
}