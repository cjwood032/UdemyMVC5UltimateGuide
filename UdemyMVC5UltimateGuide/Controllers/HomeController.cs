using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMVC5UltimateGuide.Filters;

namespace UdemyMVC5UltimateGuide.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [MyActionFilter]
        [MyResultFilter]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
            //return View("OurCompanyProducts");
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Profile()
        {
            return View();
        }
        public ActionResult StudentDetails()
        {
            ViewBag.StudentId = 101;
            ViewBag.StudentName = "Scott";
            ViewBag.Marks = 80;
            return View();
        }
    }
}