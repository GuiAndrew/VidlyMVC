using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyMVC.Models;

namespace VidlyMVC.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ViewResult Index()
        {
            var customers = GetCustomers();
          
            return View(customers); //Will return the list of customers to the view Index.
        }

        // This method will pass the id of the single customer to the view to do the details of that customer.
        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null) //If don't have any customer, will return a error.
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        //This method is to do the list of customers.
        private IEnumerable<Customer> GetCustomers()
        {
            var customers = new List<Customer> {
                new Customer { Id = 1, Name = "Bruce Kim" },
                new Customer { Id = 2, Name = "Blenda Kinda" }
            };

            return customers;
        }
    }
}