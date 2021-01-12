using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMVC5UltimateGuide.Filters;
namespace UdemyMVC5UltimateGuide
{
    public class FilterConfig
    {
        public static void  RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new MyExceptionFilter());
        }
    }
}