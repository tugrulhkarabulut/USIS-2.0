using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USIS.Models;

namespace USIS.MVCFilters
{
    public class USISLogin : FilterAttribute, IActionFilter
    {
        private UsisDB db = new UsisDB();

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            try
            {
                if (filterContext.HttpContext.Request.Cookies["studentID"] != null)
                {
                    int studentID = int.Parse(filterContext.HttpContext.Request.Cookies["studentID"].Value);
                    Student currStudent = db.Students.Find(studentID);
                    var message = $"{currStudent.studentName}, {currStudent.studentNumber} logged in to the system.";
                    db.Logs.Add(new Log { message = message, type = "Info", dateTime = DateTime.Now });
                    db.SaveChanges();
                }
            }
            catch
            {

            }

        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //
        }
    }
}