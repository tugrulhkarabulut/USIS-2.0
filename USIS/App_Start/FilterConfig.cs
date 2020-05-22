using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USIS.MVCFilters;

namespace USIS.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new USISLogger());
            filters.Add(new USISLastActivity());
        }
    }
}