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

    }
}
