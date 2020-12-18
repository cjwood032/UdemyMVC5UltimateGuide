using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMVC5UltimateGuide.Models;

namespace UdemyMVC5UltimateGuide.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index(string search="")
        {
            ViewBag.Search = search;
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            List<Product> products = db.Products.Where(p =>p.ProductName.Contains(search)).ToList();

            return View(products);
        }
        public ActionResult Details(int id)
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            Product product = db.Products.Where(p => p.ProductID==id).FirstOrDefault();
            return View(product);
        }
    }
}