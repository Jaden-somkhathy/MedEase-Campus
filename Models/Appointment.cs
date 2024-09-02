using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedEase_Campus_Clinic.Models
{
	public class Appointment
	{
		    [Key]
			public int Id { get; set; }

			[Required]
			public string FullName { get; set; }

			[Required]
			[EmailAddress]
			public string Email { get; set; }

			[Required]
			[DataType(DataType.Date)]
			public DateTime Date { get; set; }

			[Required]
			public string Department { get; set; }

			[Required]
			[Phone]
			public string PhoneNumber { get; set; }

			public string AdditionalMessage { get; set; }

        public string PatientId { get; set; }
        public ApplicationUser Patient { get; set; }
        public string DoctorId { get; set; }
        public ApplicationUser Doctor { get; set; }
        public AppointmentStatus Status { get; set; }
    }

    public enum AppointmentStatus
    {
        Pending,
        Approved,
        Rejected
    }

//   public class Notification
//{
//    public int Id { get; set; }
//    public string Message { get; set; }
//    public DateTime CreatedAt { get; set; }
//    public string DoctorId { get; set; }
//    public ApplicationUser Doctor { get; set; }
//}
}
