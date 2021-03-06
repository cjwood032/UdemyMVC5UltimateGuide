﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Company.DomainModels;
using Company.DataLayer;
using UdemyMVC5UltimateGuide.Filters;
namespace UdemyMVC5UltimateGuide.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            CompanyDbContext db = new CompanyDbContext();
            List<Category> categories = db.Categories.ToList();

            return View(categories);
        }
    }
}