using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedEase_Campus_Clinic.Models
{
	public class Student
	
		{
		[Key]
			public int Id { get; set; }

			[Required(ErrorMessage = "Student number is required")]
			[Display(Name = "Student Number")]
			public string StudentNumber { get; set; }

			[Required(ErrorMessage = "Password is required")]
			[StringLength(11, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
			public string Password { get; set; }

			public string ResetToken { get; set; }
		}
}
