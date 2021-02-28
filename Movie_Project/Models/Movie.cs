using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Movie_Project.Models
{
	public class Movie
	{
		public int Id { get; set; }
		
		public string Name { get; set; }
		public Genre Genre { get; set; }
		public byte GenreID { get; set; }
		public DateTime DateAdded { get; set; }
		public DateTime ReleaseDate { get; set; }
		public byte NumerInStock { get; set; }
	}
}