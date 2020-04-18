using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Add referneece to the application model to use them in controller
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            return View();
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
    }
}