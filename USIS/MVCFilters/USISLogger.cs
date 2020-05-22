using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USIS.Models;

namespace USIS.MVCFilters
{
    public class USISLogger : FilterAttribute, IActionFilter
    {
        private UsisDB db = new UsisDB();

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

            var controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var actionName = filterContext.ActionDescriptor.ActionName;

            var message = $"{actionName} executed on {controller}";

            db.Logs.Add(new Log { message = message, type = "Info", dateTime = DateTime.Now });
            db.SaveChanges();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //
            var controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var actionName = filterContext.ActionDescriptor.ActionName;

            var message = $"Executing {actionName} on {controller}...";

            db.Logs.Add(new Log { message = message, type = "Info", dateTime = DateTime.Now });
            db.SaveChanges();
        }
    }
}