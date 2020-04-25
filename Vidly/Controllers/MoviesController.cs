using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Add referneece to the application model to use them in controller
using Vidly.Models;

namespace Vidly.Controllers
{
    //CTRL + M, CTRL + O to collapse all code
    //CTRL + M, CTRL + P Un-collapse
    public class MoviesController : Controller
    {
        // GET: Movies working with optinal paramters
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            //https://localhost:44331/Movies?pageIndex=2&sortBy=ReleaseDate
            //Movies?pageIndex=2&sortBy=ReleaseDate
            //working with 2 paramters
            //It can not be enbeded in the url becuase we need to create a custom route that can handle 2 parameters

            return Content(string.Format("pageIndex={0} & sortby={1}", pageIndex, sortBy));
        }

        // GET: Movies/Random
        // Here an action result is an base actionresult method which call a action result base on the view that is return
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Sherk!" };
            //Here view is an helper method of class Controller which is reposible of creating
            // New ViewResult
            //return View(movie);
            // return new viewresult();

            //return a plain text string
            //return Content("Hello World");

            //Return 404 error
            //return HttpNotFound();

            //Retun nothing
            //return new EmptyResult();
            // redirect to any actions takes action name controller and annoymous object optional to pass arguments
            return RedirectToAction("Index", "Home", new { page = 1, sortBy = "Name" });

            //Control + shift + B to bulid application
            //Ctrl + r to refresh papge
            //Alt + tab to change win tabs
            //This will compile application without opening the a new tabs
            //Meaning changes made in models and controller need to build to be shown in running application
            //So this will make it easy so no more running again and again while making changes
        }

        public ActionResult Edit(int movieId)
        {
            //https://localhost:44331/Movies/Edit/1
            //Here the parameter is embeded in the URL
            //here it will work for only default paramter name which is ID
            //Which is define in the in our route

            //https://localhost:44331/Movies/Edit?id=1
            //paramter name should be same
            //Mapped using the Qurey string
            return Content("id= " + movieId);
        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}