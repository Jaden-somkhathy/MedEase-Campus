using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedEase_Campus_Clinic.Models
{
	public class ContactInfo
	{
		[Key]
		public int Id { get; set; }
		public string Hours { get; internal set; }
		public string PhoneNumber { get; internal set; }
		public string Email { get; internal set; }
	}
}