using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace UdemyMVC5UltimateGuide.Filters
{
    public class MyResultFilter : FilterAttribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.noOfVisitors = 100;
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.noOfVisitors = 200;
        }
    }
}