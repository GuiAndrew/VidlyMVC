using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyMVC.Models;

namespace VidlyMVC.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random() //ActionResult is the base class for all action results in ASP.NET MVC.
        {
            var movie = new Movie() { Name = "Shrek!" };

            //return View(movie); //We are calling this view method here which is just a helper method inherited from the base 
            ////controller class.

            ////Examples:
            //return Content("Hello World!");
            //return HttpNotFound(); //control shift B.
            //return new EmptyResult();
            return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" }); //First the action, next the controller, 
            ////and the third is one anonyms method.
        }
    }
}