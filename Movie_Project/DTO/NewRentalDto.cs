﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movie_Project.DTO
{
	public class NewRentalDto
	{
		public int CustomerId { get; set; }
		public List<int> MovieIds { get; set; }

	}
	
}