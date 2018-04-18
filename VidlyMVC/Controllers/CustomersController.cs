using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyMVC.Models;

namespace VidlyMVC.Controllers
{
    public class CustomersController : Controller
    {
        ///First we declare a field Db context to access the DB:
        private ApplicationDbContext _context;

        //We inialize the db context field in the ctor:
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //The db context is a dispose object, so we do a method to properly dispose it:
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // Method New:
        public ActionResult New()
        {
            return View();
        }

        // GET: Customers
        public ViewResult Index()
        {
            //var customers = GetCustomers(); //This call the method GetCustomers.

            //var customers = _context.Customers; //This os to get the customers in database. But this is what we 
            //call deferred execution. 

            //var customers = _context.Customers.ToList(); //Wiht the ToList, will immediately call the customers.

            var customers = _context.Customers.Include(c => c.MembershipType).ToList(); //Eager Loading.

            return View(customers); //Will return the list of customers to the view Index.
        }

        // This method will pass the id of the single customer to the view to do the details of that customer.
        public ActionResult Details(int id)
        {
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id); //This is to use the method GetCustomers().
            //And to call the customer hard code in the nethod.

            //var customer = _context.Customers.SingleOrDefault(c => c.Id == id); //This call the customer in db.
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null) //If don't have any customer, will return a error.
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        ////This method is to do the list of customers.
        //private IEnumerable<Customer> GetCustomers()
        //{
        //    var customers = new List<Customer> {
        //        new Customer { Id = 1, Name = "Bruce Kim" },
        //        new Customer { Id = 2, Name = "Blenda Kinda" }
        //    };

        //    return customers;
        //}
    }
}