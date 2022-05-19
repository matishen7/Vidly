using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        // GET: Customers
        public ActionResult Index()
        {
            var customers = new List<Customer>()
            {
                new Customer(){ Name = "John Doe", Id = 1},
                new Customer(){ Name = "Donald Trump", Id = 2},
                new Customer(){ Name = "Joe Biden", Id = 3},
            };
            return View("Index", customers);
        }

        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            var customers = new List<Customer>()
            {
                new Customer(){ Name = "John Doe", Id = 1},
                new Customer(){ Name = "Donald Trump", Id = 2},
                new Customer(){ Name = "Joe Biden", Id = 3},
            };

            var customer = customers.FirstOrDefault(c => c.Id == id);
            return View("Details", customer);
        }
    }
}