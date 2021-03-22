﻿using AutoMapper;
using Movie_Project.DTO;
using Movie_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace Movie_Project.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

		public MoviesController()
		{
            _context = new ApplicationDbContext();
		}

        //Get/api/movies

        public IHttpActionResult GetMovies()
		{
            var movieDto = _context.Movies.Include(x=> x.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
            return Ok(movieDto);
		}

        //Get/api/customers/1
        public IHttpActionResult GetMovie (int id)
		{
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();
            return Ok(Mapper.Map<Movie, MovieDto>(movie));

		}

        //Post/Api/Customers
        [HttpPost]

        public IHttpActionResult CreateMovie(MovieDto movieDto)
		{
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);

        }

        //Put/api/customers/1
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
		{
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if(movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();


        }
        //Delete/api/movies/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
