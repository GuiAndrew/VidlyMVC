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
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        // Method Create:
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0) //Create a new customer:
            {
                _context.Customers.Add(customer);
            }
            else //Update a customer:
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        // GET: Customers
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList(); //Eager Loading.

            return View(customers); //Will return the list of customers to the view Index.
        }

        // This method will pass the id of the single customer to the view to do the details of that customer.
        public ActionResult Details(int id)
        {
            //var customer = _context.Customers.SingleOrDefault(c => c.Id == id); //This call the customer in db.
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null) //If don't have any customer, will return a error.
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        //// Method Edit:
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id); //Will return the customer with the specific id.

            if (customer == null) //If customer for null,
            {
                return HttpNotFound();
            }

            //If customer not null:
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer, 
                MembershipTypes = _context.MembershipTypes.ToList() //We are put the MembershipTypes straight from the database. And to a list.
            };

            return View("CustomerForm", viewModel); //In here we are override the default convention in MVC and specify the view name.
        }
    }
}