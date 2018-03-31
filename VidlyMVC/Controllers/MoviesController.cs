using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyMVC.Models;
using VidlyMVC.ViewModels;

namespace VidlyMVC.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random() //ActionResult is the base class for all action results in ASP.NET MVC.
        {
            var movie = new Movie() { Name = "Shrek!" };

            //ViewData["Movie"] = movie; //Using ViewData -> this is of type view data dictionary. This hava a magic string, witch mean is to avoid.
            //ViewBag.Movie = movie; //Using ViewBag -> this is of type view data dictionary. And is more dynamic. But if we change here, we have to alter in the view. So is to avoid too.

            //return View(); 

            //Best way, is to pass the object is here.
            //return View(movie); //We are calling this view method here which is just a helper method inherited from the base 
            ////controller class.

            ////Examples:
            //return Content("Hello World!");
            //return HttpNotFound(); //control shift B.
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" }); //First the action, next the controller, 
            ////and the third is one anonyms method.

            //// To use with viewModels:
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        //In here because we use an id, and the route have an id, we can use the querString and the URL.
        public ActionResult Edit(int id)
        {
            return Content("Id = " + id + "."); 
        }

        // Tehis will be called when we navegate to movies.
        //// The question mark in the integer it means it will accept nullable value.
        //// In the sortBy we don't have to do anything, because the string type in C# is a 
        //// reference type and it's nullable.
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            //return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
            return Content($"pageIndex={pageIndex}&sortBy={sortBy}"); //With string interpolated.
        }

        // To test the new route:
        //To apply the constraints, use :regex(\\d{2}) and we can use more, like range, etc.
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")] 
        public ActionResult ByReleaseDate(int? year, byte? month)
        {
            return Content(year + "/" + month);
        }

    }
}