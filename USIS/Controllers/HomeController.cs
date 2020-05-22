using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USIS.Models;
using USIS.MVCFilters;
using Vereyon.Web;

namespace USIS.Controllers
{
    public class HomeController : Controller
    {
        private UsisDB db = new UsisDB();
        // GET: Home
        public ActionResult Index()
        {
            var studentID = Request.Cookies["studentID"];
            if (studentID != null && db.Students.Find(int.Parse(studentID.Value)) != null)
            {
                return Redirect("/Students/Details/" + studentID.Value);
            }

            return View();
        }

        [HttpPost]
        [Route("login")]
        [USISLogin]
        public ActionResult Login(FormCollection collection)
        {
            int studentNumber;
            try
            {
                studentNumber = int.Parse(collection["studentNumber"]);
                Student student = db.Students.First(s => s.studentNumber == studentNumber);
                HttpCookie cookie = new HttpCookie("studentID", student.id.ToString());
                cookie.Expires = DateTime.Now.AddDays(30);
                HttpContext.Response.Cookies.Add(cookie);
                return Redirect("/Courses/Index");
            } catch
            {
                FlashMessage.Danger("Please enter a valid student number");
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [Route("logout")]
        public ActionResult Logout(FormCollection collection)
        {
            HttpContext.Response.Cookies.Get("studentID").Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("Index");
        }
    }
}