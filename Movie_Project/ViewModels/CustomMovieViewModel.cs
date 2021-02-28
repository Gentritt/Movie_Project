using Movie_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie_Project.ViewModels
{
	public class CustomMovieViewModel
	{
		public IEnumerable<Genre> Genres { get; set; }
		public Movie Movie { get; set; }
	}
}