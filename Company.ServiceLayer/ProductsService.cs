using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.ServiceContracts;
using Company.DomainModels;
using Company.DataLayer;
using Company.RepositoryContracts;
using Company.RepositoryLayer;
namespace Company.ServiceLayer
{
    public class ProductsService :IProductsService
    {
        IProductsRepository prodRep;    
        public ProductsService(IProductsRepository r)
        {
            this.prodRep = r;
        }
        public List<Product> GetProducts()
        {
            List<Product> products = prodRep.GetProducts();
            return products;
        }
        public List<Product> SearchProducts(string ProductName)
        {
            List<Product> products = prodRep.SearchProducts(ProductName);
            return products;
        }
        public Product GetProductByProductId(int ProductID)
        {
            Product product = prodRep.GetProductByProductID(ProductID);
            return product;
        }
        public void InsertProduct(Product p)
        {
            prodRep.InsertProduct(p);
        }
        public void UpdateProduct(Product product)
        {
            prodRep.UpdateProduct(product);
        }
        public void DeleteProduct(long productID)
        {
            prodRep.DeleteProduct(productID);
        }
    }
}
