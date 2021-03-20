using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movie_Project.DTO
{
	public class MovieDto
	{

		public int Id { get; set; }
		[Required]
		[StringLength(255)]
		public string Name { get; set; }
		[Required]
		public byte GenreID { get; set; }
		public DateTime DateAdded { get; set; }
		public DateTime ReleaseDate { get; set; }
		[Range(1, 20)]
		public byte NumerInStock { get; set; }
	}
}