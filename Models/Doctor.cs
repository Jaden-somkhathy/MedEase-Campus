using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedEase_Campus_Clinic.Models
{
	public class Doctor
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "User Name is Required.")]
		[StringLength(50, ErrorMessage = "The  must be at least 50 characters long.")]

		public string Username { get; set; }
		[StringLength(8)]
		public string Password { get; set; }
		public string ResetToken { get; set; }
	}
}