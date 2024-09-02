
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedEase_Campus_Clinic.Models
{
	public class Clinic
	{
		[Key]
		public int Id { get; set; }
		public string WelcomeMessage { get; set; }
		public ContactInfo Contact { get; set; }
		public List<string> NavigationLinks { get; set; }
	}
}