using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Movie_Project.Models
{
	public class Genre
	{

		public byte Id { get; set; }
		[Required]
		[StringLength(255)]
		public string Name { get; set; }
	}
}