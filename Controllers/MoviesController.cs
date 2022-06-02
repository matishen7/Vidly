using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var newMovieViewModel = new MovieFormViewModel()
            {
                Movie = new Movie(),
                Genres = genres
            };
            return View("MovieForm", newMovieViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel()
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList(),
                };

                return View("MovieForm", viewModel);
            }

            var genre = _context.Genres.ToList().FirstOrDefault(a => a.Id == movie.Genre.Id);
            if (movie.Id == 0)
            {
                movie.Genre = genre;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(x => x.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.Genre = genre;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(x => x.Genre).ToList();

            return View("Index", movies);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(a => a.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }
    }
}