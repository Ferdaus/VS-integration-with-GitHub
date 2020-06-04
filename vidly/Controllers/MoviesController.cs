using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using vidly.Models;
using vidly.ViewModels;

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Scent of a Woman"};

            var customers = new List<Customer>
            {
                new Customer { Name = "Kawsar"},
                new Customer { Name = "Adib"},
                new Customer { Name = "Tauseef"},

            };

            var viewModel = new RandomMoviewViewModel
            {
                Movie = movie,
                Customers = customers
            };

            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page =1, sortBy = "name"});
            return View(viewModel);
        }

        //[Route("movies/released/{year}/{month:regex(\\d{4}): range(1,12)}")]
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        //[Route("movies/released/{year:regex(2015|2016}/{month:regex(\\d{2}):range(1,12)}")]

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/"+ month);
        }    

        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }

        public ActionResult AnotherEdit(int id)
        {
            return Content("id = " + id);
        }

        /*    public ActionResult Index(int? pageIndex, string sortBy)
            {
                if (!pageIndex.HasValue)
                    pageIndex = 1;
                if (String.IsNullOrWhiteSpace(sortBy))
                    sortBy = "Name";

                return Content(String.Format("pageIndex={0}&sortBy={1} ",pageIndex,sortBy));

            } */

        public ViewResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }

    }


}