using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Company.DomainModels;
using Company.DataLayer;
using UdemyMVC5UltimateGuide.Filters;
using Company.ServiceContracts;
using Company.ServiceLayer;
namespace UdemyMVC5UltimateGuide.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class ProductsController : Controller
    {
        CompanyDbContext db;
        IProductsService prodService;
        public ProductsController(IProductsService pService)
        {
            this.db = new CompanyDbContext();
            this.prodService = pService;
        }
        // GET: Products
        public ActionResult Index(string search="", string SortColumn="ProductID", string IconClass="fa-sort-asc")
        {
            
            ViewBag.search = search;
            List<Product> products = prodService.SearchProducts(search);

            /*Sorting*/
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            if (ViewBag.SortColumn == "ProductID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.ProductID).ToList();
                else
                    products = products.OrderByDescending(temp => temp.ProductID).ToList();
            }
            else if (ViewBag.SortColumn == "ProductName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.ProductName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.ProductName).ToList();
            }
            else if (ViewBag.SortColumn == "Price")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Price).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Price).ToList();
            }
            else if (ViewBag.SortColumn == "DOP")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.DOP).ToList();
                else
                    products = products.OrderByDescending(temp => temp.DOP).ToList();
            }
            else if (ViewBag.SortColumn == "AvailabilityStatus")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.AvailabilityStatus).ToList();
                else
                    products = products.OrderByDescending(temp => temp.AvailabilityStatus).ToList();
            }
            else if (ViewBag.SortColumn == "CategoryID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Category.CategoryName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Category.CategoryName).ToList();
            }
            else if (ViewBag.SortColumn == "BrandID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Brand.BrandName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Brand.BrandName).ToList();
            }

            return View(products);
        }
        public ActionResult Details(int id)
        {
            Product product = prodService.GetProductByProductId(id);
            return View(product);
        }
        public ActionResult Edit(int id)
        {

            Product product = prodService.GetProductByProductId(id);
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View(product);
        }
        public ActionResult Create()
        {
            ViewData["Categories"]=db.Categories.ToList();
            ViewData["Brands"] = db.Brands.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            prodService.InsertProduct(product);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Update(Product product)
        {
            prodService.UpdateProduct(product);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(Product product)
        {
            prodService.DeleteProduct(product.ProductID);
            return RedirectToAction("Index");
        }
    }
}