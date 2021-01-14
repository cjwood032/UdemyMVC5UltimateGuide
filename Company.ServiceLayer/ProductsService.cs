using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.ServiceContracts;
using Company.DomainModels;
using Company.DataLayer;
namespace Company.ServiceLayer
{
    public class ProductsService :IProductsService
    {
        CompanyDbContext db;
        public ProductsService()
        {
            this.db = new CompanyDbContext();
        }
        public List<Product> GetProducts()
        {
            List<Product> products = db.Products.ToList();
            return products;
        }
        public List<Product> SearchProducts(string ProductName)
        {
            List<Product> products = db.Products.Where(p => p.ProductName.Contains(ProductName)).ToList();
            return products;
        }
        public Product GetProductByProductId(int ProductID)
        {
            Product product = db.Products.Where(p => p.ProductID==ProductID).FirstOrDefault();
            return product;
        }
        public void InsertProduct(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
        }
        public void UpdateProduct(Product product)
        {
            Product foundProduct = db.Products.Where(p => p.ProductID == product.ProductID).FirstOrDefault();
            foundProduct.ProductName = product.ProductName;
            foundProduct.Price = product.Price;
            foundProduct.DOP = product.DOP;
            foundProduct.CategoryID = product.CategoryID;
            foundProduct.BrandID = product.BrandID;
            foundProduct.AvailabilityStatus = product.AvailabilityStatus;
            foundProduct.Active = product.Active;
            db.SaveChanges();
        }
        public void DeleteProduct(Product product)
        {
            Product foundProduct = db.Products.Where(p => p.ProductID == product.ProductID).FirstOrDefault();
            db.Products.Remove(foundProduct);
            db.SaveChanges();
        }
    }
}
