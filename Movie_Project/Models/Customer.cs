using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movie_Project.Models
{
	public class Customer
	{
		public int Id { get; set; }
		[Required]
		[StringLength(255)]
		public string Name { get; set; }
		public bool IssubscribedToNewsletter { get; set; }
		public MembershipType MembershipType { get; set; }
		[Display(Name = "MemberShip Type: ")]
		public int MembershipTypeId { get; set; }
		//[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
		//[Display(Name = "Date of Birth")]
		[Min18YearsIfAmember]
		public DateTime? Birthdate { get; set; }

	}
}