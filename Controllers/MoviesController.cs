using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>()
            {
                new Customer() { Name = "Customer 1"}, new Customer() { Name = "Customer 2"}
            };
            var randomMovieVM = new RandomMovieVM()
            {
                Movie = movie,
                Customers = customers
            };
            return View("Random", randomMovieVM);
        }

        public ActionResult Edit(int id)
        {
            return Content("Id = " + id);
        }

        //[Route("movies")]
        public ActionResult Index()
        {
            var movies = new List<Movie>()
            {
                new Movie() { Name = "Shrek!"},
                new Movie() { Name = "Wall-e"},
            };
            return View("Index", movies);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}