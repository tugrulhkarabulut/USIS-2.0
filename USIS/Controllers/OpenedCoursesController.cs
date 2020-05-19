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
    public class OpenedCoursesController : Controller
    {
        private UsisDB db = new UsisDB();

        // GET: OpenedCourses
        public ActionResult Index()
        {
            int studentID = int.Parse(Request.Cookies["studentID"].Value);
            Student student = db.Students.Find(studentID);

            var openedCoursesForStudent = db.OpenedCourses.Where(o => o.course.departmentID == student.departmentID);
            ViewBag.student = student;

            return View(openedCoursesForStudent.ToList());
        }

        // GET: OpenedCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpenedCourse openedCourse = db.OpenedCourses.Find(id);
            if (openedCourse == null)
            {
                return HttpNotFound();
            }
            return View(openedCourse);
        }

        // GET: OpenedCourses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OpenedCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,courseID,year,semester,capacity")] OpenedCourse openedCourse)
        {
            if (ModelState.IsValid)
            {
                db.OpenedCourses.Add(openedCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(openedCourse);
        }

        // GET: OpenedCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpenedCourse openedCourse = db.OpenedCourses.Find(id);
            if (openedCourse == null)
            {
                return HttpNotFound();
            }
            return View(openedCourse);
        }

        // POST: OpenedCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,courseID,year,semester,capacity")] OpenedCourse openedCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(openedCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(openedCourse);
        }

        // GET: OpenedCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpenedCourse openedCourse = db.OpenedCourses.Find(id);
            if (openedCourse == null)
            {
                return HttpNotFound();
            }
            return View(openedCourse);
        }

        // POST: OpenedCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OpenedCourse openedCourse = db.OpenedCourses.Find(id);
            db.OpenedCourses.Remove(openedCourse);
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
