using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USIS.Models;

namespace USIS.MVCFilters
{
    public class USISLastActivity : FilterAttribute, IActionFilter
    {
        private UsisDB db = new UsisDB();

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                if (filterContext.HttpContext.Request.Cookies["studentID"] != null)
                {
                    int studentID = int.Parse(filterContext.HttpContext.Request.Cookies["studentID"].Value);
                    Student currStudent = db.Students.Find(studentID);
                    currStudent.lastActivity = DateTime.Now;
                    db.SaveChanges();
                }
            } catch
            {

            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //
        }
    }
}