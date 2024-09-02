using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedEase_Campus_Clinic.Models
{
	public class Staff
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "User Name is Required.")]
		[StringLength(30, ErrorMessage = "The  must be at least 20 characters long.")]

		public string Username { get; set; }
		[Required]
		[StringLength(8)]
		public string Password { get; set; }
		public string ResetToken { get; set; }
	}
}