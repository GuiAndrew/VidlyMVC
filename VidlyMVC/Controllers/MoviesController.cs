using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyMVC.Models;
using VidlyMVC.ViewModels;

namespace VidlyMVC.Controllers
{
    public class MoviesController : Controller
    {
        ///First we declare a field Db context to access the DB:
        private ApplicationDbContext _context;

        //We inialize the db context field in the ctor:
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
                
        //============== 
        public ViewResult Index()
        {
            //var movies = GetMovies();
            var movies = _context.Movies.Include(m => m.Genre).ToList(); //Eager Loading.

            return View(movies); //Will return the list of movies to the view Index.
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null) //If don't have any customer, will return a error.
            {
                return HttpNotFound();
            }

            return View(movie);
        }
    
        //// Method New Movie
        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        //// Method Edit Movie
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        //// Method Save Movie
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0) //If movie don't exist, create a new one:
            {
                movie.DateAdded = DateTime.Now;

                _context.Movies.Add(movie);
            }
            else // If movie exist, update:
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.Stock = movie.Stock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}