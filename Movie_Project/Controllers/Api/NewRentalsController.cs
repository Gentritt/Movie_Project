using Movie_Project.DTO;
using Movie_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Movie_Project.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;
		public NewRentalsController()
		{
			_context = new ApplicationDbContext();
		}
		[HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRentalDto)
		{

			var customer = _context.Customers.Single(c => c.Id == newRentalDto.CustomerId);
			var movies = _context.Movies.Where(m => newRentalDto.MovieIds.Contains(m.Id)).ToList();

			foreach (var movie in movies)
			{
				if (movie.NumerInStock == 0)
					return BadRequest("Movie is not avaliable");

				movie.NumberAvaliable--;

				var rental = new Rental
				{
					Customer = customer,
					Movie = movie,
					DateRented = DateTime.Now
				};
				_context.Rentals.Add(rental);
			}
			_context.SaveChanges();
			return Ok();
		}
    }
}
