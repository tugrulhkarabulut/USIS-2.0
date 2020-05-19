using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USIS.Models;
using Vereyon.Web;

namespace USIS.Controllers
{
    public class HomeController : Controller
    {
        private UsisDB db = new UsisDB();
        // GET: Home
        public ActionResult Index()
        {

            bool loggedIn = Request.Cookies["studentID"] != null;
            if (loggedIn)
            {
                return Redirect("/Courses/Index");
            }

            return View();
        }

        [HttpPost]
        [Route("login")]
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
            } catch (Exception err)
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