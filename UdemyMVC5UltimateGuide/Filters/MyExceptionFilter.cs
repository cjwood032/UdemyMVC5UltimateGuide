using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace UdemyMVC5UltimateGuide.Filters
{
    public class MyExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            string s = filterContext.Exception.Message + "\n" + filterContext.Exception.GetType().ToString() + "\n" + filterContext.Exception.Source;
            StreamWriter sw = File.AppendText(filterContext.RequestContext.HttpContext.Request.PhysicalApplicationPath + @"\ErrorLog.txt");
            sw.Write(s);
            sw.Close();
            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectResult("!/Error.html");
        }
    }
}