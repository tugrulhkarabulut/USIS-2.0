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
            var studentCourseRegistrations = db.CourseRegistrations.Where(r => r.studentID == studentID);

            ViewBag.student = student;
            ViewBag.totalCredits = studentCourseRegistrations.Where(cr => cr.grade != null).Sum(cr => cr.openedCourse.course.credit);
            ViewBag.departmentTotalCredits = student.department.courses.Sum(c => c.credit);
            return View(studentCourseRegistrations.ToList());
        }

        [HttpPost]
        public JsonResult Create(FormCollection courseRegistration)
        {
            int studentID = int.Parse(courseRegistration["studentID"]);
            int openedCourseID = int.Parse(courseRegistration["openedCourseID"]);

            var oldRegistrationQuery = db.CourseRegistrations.Where(c => c.studentID == studentID && c.openedCourseID == openedCourseID);
            if (oldRegistrationQuery.Count() != 0)
            {
                return Json(new { created = false, message = "You already took the course" });
            }

            var openedCourse = db.OpenedCourses.Find(openedCourseID);
            if (openedCourse.capacity <= openedCourse.courseRegistrations.Count())
            {
                return Json(new { created = false, message = "Capacity is full" });
            }



            db.CourseRegistrations.Add(new CourseRegistration { studentID = studentID, openedCourseID = openedCourseID });
            db.SaveChanges();

            var student = db.Students.Find(studentID);
            Helpers.SendEmail(student.email, student.studentName, "Course Registration", $"You took the {openedCourse.course.courseName} course from {openedCourse.lecturer.lecturerName}.");

            return Json(new { created = true, message = "You took the course!" });
        }

        [HttpPost]
        public JsonResult Delete(FormCollection collection)
        {
            try
            {
                CourseRegistration courseRegistration = db.CourseRegistrations.Find(int.Parse(collection["courseRegistrationID"]));
                db.CourseRegistrations.Remove(courseRegistration);
                db.SaveChanges();
                return Json(new { deleted = true, message = "You dropped the course" });

            }
            catch (Exception err)
            {
                return Json(new { deleted = false, message = "An error occurred", error = err.ToString() });
            }
        }
    }
}
