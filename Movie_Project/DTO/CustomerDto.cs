using Movie_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movie_Project.DTO
{
	public class CustomerDto
	{
		public int Id { get; set; }
		[Required]
		[StringLength(255)]
		public string Name { get; set; }
		public bool IssubscribedToNewsletter { get; set; }
		public MembershipTypeDto membershipType { get; set; }
		public int MembershipTypeId { get; set; }
		//[Min18YearsIfAmember]
		public DateTime? Birthdate { get; set; }
	}
}