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
        public ActionResult Index()
        {
            List<Product> products = new List<Product>(){
                new Product() { ProductId = 101, ProductName = "AC", Rate = 45000 },
            new Product() { ProductId = 102, ProductName = "Mobile", Rate = 38000 },
            new Product() { ProductId = 103, ProductName = "Bike", Rate = 94000 },
            };
            ViewBag.Products = products;
            return View();
        }
        public ActionResult Details(int id)
        {

            Product prod = new Product();
            List<Product> products = new List<Product>(){
            new Product() { ProductId = 101, ProductName = "AC", Rate = 45000 },
            new Product() { ProductId = 102, ProductName = "Mobile", Rate = 38000 },
            new Product() { ProductId = 103, ProductName = "Bike", Rate = 94000 },
            };
            prod = products.Find(p => p.ProductId == id);
            ViewBag.Product = prod;
            return View();
        }
    }
}