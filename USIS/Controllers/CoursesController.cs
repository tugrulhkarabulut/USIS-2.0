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
    public class CoursesController : Controller
    {
        private UsisDB db = new UsisDB();

        // GET: Courses
        public ActionResult Index()
        {
            var departmentsData = db.Departments.Select(d => new
            {
                id = d.id,
                name = d.departmentName
            });
            ViewBag.DepartmentSelectList = new SelectList(departmentsData, "id", "name");
            return View();
        }

        [Route("Courses/ByDepartment/{departmentID}")]
        [HttpGet]
        public JsonResult CoursesByDepartment(int? departmentID)
        {
            var studentID = int.Parse(Request.Cookies["studentID"].Value);
            var student = db.Students.Find(studentID);
            var courses = db.Courses.Where(c => c.departmentID == departmentID).Select(c => new
            {
                c.courseCode,
                c.credit,
                c.courseName,
                c.year,
                c.semester
            }).OrderBy(c => c.year).ThenBy(c => c.semester).ThenBy(c => c.courseCode).ToList();
            return Json(new { courses }, JsonRequestBehavior.AllowGet);
        }
    }
}