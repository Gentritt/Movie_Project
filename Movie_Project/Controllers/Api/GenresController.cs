using Movie_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Movie_Project.Controllers.Api
{
   
    public class GenresController : ApiController
    {

        private ApplicationDbContext _context;
        public GenresController()
        {
            _context = new ApplicationDbContext();
        }
        
        //Get/Api/Genres
        public IHttpActionResult GetGenres()
		{
            var getGenres = _context.Genres.ToList();
            return Ok(getGenres);
		}

        //Get/api/Genres/1
        public IHttpActionResult GetGenre( int id)
		{
            var genre = _context.Genres.SingleOrDefault(x => x.Id == id);

            if (genre == null)
                return NotFound();

            return Ok(genre);

		}
        [HttpPost]
        public Genre CreateGenre(Genre genre)
        {
            
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Genres.Add(genre);
            _context.SaveChanges();
            return genre;
        }

        [HttpDelete]
        public void DeleteGenre(int id)
		{

            var genreDb = _context.Genres.SingleOrDefault(c => c.Id == id);
            if (genreDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Genres.Remove(genreDb);
            _context.SaveChanges();

		}

    }
}
