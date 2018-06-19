using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyMVC.DTOS;
using VidlyMVC.Models;

namespace VidlyMVC.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET / api/customers
        // public IEnumerable<CustomerDto> GetCustomers()
        public IHttpActionResult GetCustomers()
        {
            //In here we remove the parenteses in the end, because if we call this with the parenteses, will execute,
            //and we need to delegate a reference to this method.
            //return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
            var customerDtos = _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customerDtos);
        }

        // GET /api/customer/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            //return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
            return Created(new Uri(Request.RequestUri + "" +customer.Id), customerDto);
        }

        // PUT /api/customer/1
        [HttpPut]
        //public void UpdateCustomer(int id, CustomerDto customerDto)
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();
            }

            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDB == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            }

            //Mapper.Map<CustomerDto, Customer>(customerDto, customerInDB); //Ou:
            Mapper.Map(customerDto, customerInDB);

            _context.SaveChanges();
            return Ok();
        }

        // DELETE /api/customer/1
        [HttpDelete]
        //public void DeleteCustomer(int id)
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDB == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            }

            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();
            return Ok();
        }
    }
}
