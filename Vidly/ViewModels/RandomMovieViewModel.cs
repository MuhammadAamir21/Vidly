using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    //so why ViewModel
    //it provide access to 2 or more different model to be passed in the view
    //It is specificly for the view
    public class RandomMovieViewModel
    {
        //2 model are added here movie and customers
        public Movie Movie { get; set; }

        public List<Customer> Customers { get; set; }
    }
}