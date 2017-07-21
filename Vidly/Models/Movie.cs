using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StringsLib;

namespace Vidly.Models
{
    public class Movie : ParseString
    {
        //movie class 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Quote { get; set; }

    }
}