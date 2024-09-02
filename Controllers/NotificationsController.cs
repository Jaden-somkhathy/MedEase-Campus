using MedEase_Campus_Clinic.Models;
using Microsoft.AspNet.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MedEase_Campus_Clinic.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;

        public NotificationsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            db = context;
            _userManager = userManager;
        }

        //[Authorize(Roles = "Doctor")]
        //public async Task<IActionResult> Index()
        //{
        //    var doctorId = User.Identity.GetUserId();
        //    var notifications = await db.Notifications
        //        .Where(n => n.DoctorId == doctorId)
        //        .OrderByDescending(n => n.CreatedAt)
        //        .ToList();

        //    return View(notifications);
        //}

       
    }
}