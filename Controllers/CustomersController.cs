using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
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
    }
}