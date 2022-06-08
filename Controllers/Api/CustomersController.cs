using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Vidly.Dto;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            var result = _context.Customers.Include(c => c.MembershipType).ToList().Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(x => x.Id == id);

            if (customer == null)
                return NotFound();
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            var membershipType = _context.MembershipTypes.SingleOrDefault(x => x.Id == customerDto.MembershipTypeId);
            if (membershipType.Name == null)
                return NotFound();

            customer.MembershipType = membershipType;

            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }


        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(x => x.Id == id);

            if (customerInDb == null)
                return NotFound();

            var membershipType = _context.MembershipTypes.SingleOrDefault(x => x.Id == customerDto.MembershipTypeId);
            if (membershipType.Name == null)
                return NotFound();
            Mapper.Map(customerDto, customerInDb);
            //customerInDb.Name = customerDto.Name;
            //customerInDb.Birthdate = customerDto.Birthdate;
            //customerInDb.IsSubscribedToNews = customerDto.IsSubscribedToNews;
            //customerInDb.MembershipType = membershipType;

            _context.SaveChanges();
            return Ok(customerDto);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(x => x.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
