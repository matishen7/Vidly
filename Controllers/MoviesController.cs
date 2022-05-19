using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Random()
        {
            var movies = _context.Movies.Include(x => x.Genre).ToList();
            return View("Random", movies);
        }

        public ActionResult Edit(int id)
        {
            return Content("Id = " + id);
        }

        //[Route("movies")]
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(x => x.Genre).ToList();

            return View("Index", movies);
        }

        [Route("movieDetails/{id}")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).ToList().FirstOrDefault(c => c.Id == id);
            return View("Details", movie);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}