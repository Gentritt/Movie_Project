using Movie_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Movie_Project.ViewModels;

namespace Movie_Project.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Movies
        public ActionResult Index()
        {
            //var movie = _context.Movies.Include(x=> x.Genre).ToList();
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("Index");
            else
                return View("ReadOnlyList");
            
        }

        [Authorize(Roles =RoleName.CanManageMovies)]
        public ActionResult New()
		{
            var genres = _context.Genres.ToList();
            var viewmodel = new CustomMovieViewModel
            {
                Genres = genres


            };
            return View("MovieForm", viewmodel);
		}


        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                _context.Movies.Add(movie);

            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.NumerInStock = movie.NumerInStock;
                movieInDb.GenreID = movie.GenreID;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }


        public ActionResult Details(int id)
		{
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            else
                return View(movie);


        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewmodel = new CustomMovieViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()

            };
            return View("MovieForm", viewmodel);
        }
    }
}