using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using USIS.Models;

namespace USIS.Controllers
{
    public class CourseRegistrationsController : Controller
    {
        private UsisDB db = new UsisDB();

        // GET: CourseRegistrations
        public ActionResult Index()
        {
            int studentID = int.Parse(Request.Cookies["studentID"].Value);
            Student student = db.Students.Find(studentID);
            ViewBag.student = student;
            var studentCourseRegistrations = db.CourseRegistrations.Where(r => r.studentID == studentID);
            return View(studentCourseRegistrations.ToList());
        }

        // GET: CourseRegistrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseRegistration courseRegistration = db.CourseRegistrations.Find(id);
            if (courseRegistration == null)
            {
                return HttpNotFound();
            }
            return View(courseRegistration);
        }

        // GET: CourseRegistrations/Create
        public ActionResult Create()
        {
            var openedCourses = db.OpenedCourses.Join(
                db.Courses,
            c => c.courseID,
            o => o.id,
            (o, c) => new
            {
                openedCourseID = o.id,
                c.courseName
            });
            ViewBag.openedCoursesSelectList = new SelectList(openedCourses, "openedCourseID", "courseName");
            return View();
        }

        [HttpPost]
        public JsonResult Create(FormCollection courseRegistration)
        {
            int studentID = int.Parse(courseRegistration["studentID"]);
            int openedCourseID = int.Parse(courseRegistration["openedCourseID"]);

            var oldRegistration = db.CourseRegistrations.Where(c => c.studentID == studentID && c.openedCourseID == openedCourseID).First();
            if (oldRegistration != null)
            {
                return Json(new { created = false });
            }

            db.CourseRegistrations.Add(new CourseRegistration { studentID = studentID, openedCourseID = openedCourseID });
            db.SaveChanges();
            return Json(new { created = true });
        }

        // GET: CourseRegistrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseRegistration courseRegistration = db.CourseRegistrations.Find(id);
            if (courseRegistration == null)
            {
                return HttpNotFound();
            }
            return View(courseRegistration);
        }

        // POST: CourseRegistrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,studentID,openedCourseID,grade")] CourseRegistration courseRegistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseRegistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseRegistration);
        }

        // GET: CourseRegistrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseRegistration courseRegistration = db.CourseRegistrations.Find(id);
            if (courseRegistration == null)
            {
                return HttpNotFound();
            }
            return View(courseRegistration);
        }

        // POST: CourseRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseRegistration courseRegistration = db.CourseRegistrations.Find(id);
            db.CourseRegistrations.Remove(courseRegistration);
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
