using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMVC5UltimateGuide.Models;

namespace UdemyMVC5UltimateGuide.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([ModelBinder(typeof (CustomBinder))] Student stu)
        {

        }
    }
}