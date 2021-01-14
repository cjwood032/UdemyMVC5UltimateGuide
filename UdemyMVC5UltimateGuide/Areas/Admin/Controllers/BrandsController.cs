using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Company.DataLayer;
//using UdemyMVC5UltimateGuide.Models;
using Company.DomainModels;
using UdemyMVC5UltimateGuide.Filters;
namespace UdemyMVC5UltimateGuide.Areas.Admin.Controllers

{
    [AdminAuthorization]
    public class BrandsController : Controller
    {
        // GET: Brands
        public ActionResult Index()
        {
            CompanyDbContext db = new CompanyDbContext();
            List<Brand> brands = db.Brands.ToList();

            return View(brands);
            
        }
    }
}