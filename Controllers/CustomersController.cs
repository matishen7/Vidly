using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context { get; set; }
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View("Index", customers);
        }

        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).ToList().FirstOrDefault(c => c.Id == id);
            return View("Details", customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var newCustomerVM = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", newCustomerVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList(),
                };

                return View("CustomerForm", viewModel);
            }

            var membershipType = _context.MembershipTypes.ToList().FirstOrDefault(a => a.Id == customer.MembershipType.Id);
            if (customer.Id == 0)
            {
                customer.MembershipType = membershipType;
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(x => x.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipType = membershipType;
                customerInDb.IsSubscribedToNews = customer.IsSubscribedToNews;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(a => a.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}