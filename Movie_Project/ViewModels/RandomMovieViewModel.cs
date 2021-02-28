using Movie_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie_Project.ViewModels
{
	public class RandomMovieViewModel
	{
		public Movie movie { get; set; }
		public List<Customer> Customers { get; set; }
	}
}