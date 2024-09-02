using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MedEase_Campus_Clinic.Models;
using Microsoft.AspNet.Identity;


namespace MedEase_Campus_Clinic.Controllers
{
    [Authorize]
    public class AppointmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        

        
        [Authorize(Roles = "Doctor, Patient")]

        
        public ActionResult Index()
        {
            var appointments= db.Appointments.ToList();
            return View(appointments);
        }

      
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }
      
        public ActionResult Create()
        {
            return View();
        }

         // see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Patient")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FullName,Email,Date,Department,PhoneNumber,AdditionalMessage")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                var patientId = User.Identity.GetUserId();
                appointment.PatientId = patientId;
                appointment.Status = AppointmentStatus.Pending;
                db.Appointments.Add(appointment);
                db.SaveChanges();

                //await NotifyDoctors(appointment);


                return RedirectToAction("Index");
            }

            return View(appointment);
        }

        //private async Task NotifyDoctors(Appointment appointment)
        //{
        //    var doctorRole = db.Roles.SingleOrDefault(r => r.Name == "Doctor");

        //    if (doctorRole != null)
        //    {
        //        // Get the users who belong to the "Doctor" role
        //        var doctorUserIds = db.UserRoles
        //            .Where(ur => ur.RoleId == doctorRole.Id)
        //            .Select(ur => ur.UserId)
        //            .ToList();

        //        // Your remaining logic...
        //    }

        //    // Get the doctor users



        //        // Create a notification for each doctor user
        //        var notification = new Notification
        //        {
        //            Message = $"A new appointment has been scheduled by {appointment.Patient.UserName} on {appointment.Date.ToShortDateString()}",
        //            CreatedAt = DateTime.Now,
        //        };

        //        await db.SaveChangesAsync();
        //}

        [Authorize(Roles = "Doctor")]
        public async Task<ActionResult> ManageAppointments()
        {
            var doctorId = User.Identity.GetUserId();
            var pendingAppointments = await db.Appointments
                .Where(a => a.DoctorId == doctorId && a.Status == AppointmentStatus.Pending)
                .ToListAsync();

            return View(pendingAppointments);
        }
        [Authorize(Roles = "Doctor")]
        public async Task<ActionResult> ApproveAppointment(int id)
        {
            var appointment = await db.Appointments.FindAsync(id);
            if (appointment != null)
            {
                appointment.Status = AppointmentStatus.Approved;
                await db.SaveChangesAsync();
            }

            return RedirectToAction(nameof(ManageAppointments));
        }

        [Authorize(Roles = "Doctor")]
        public async Task<ActionResult> RejectAppointment(int id)
        {
            var appointment = await db.Appointments.FindAsync(id);
            if (appointment != null)
            {
                appointment.Status = AppointmentStatus.Rejected;
                await db.SaveChangesAsync();
            }

            return RedirectToAction(nameof(ManageAppointments));
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,Email,Date,Department,PhoneNumber,AdditionalMessage")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
