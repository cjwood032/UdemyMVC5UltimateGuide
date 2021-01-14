using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.DomainModels;
namespace Company.ServiceContracts
{
    public interface IProductsService
    {
        List<Product> GetProducts();
        List<Product> SearchProducts(string ProductName);
        Product GetProductByProductId(int ProductID);
        void InsertProduct(Product p);
        void UpdateProduct(Product p);
        void DeleteProduct(Product p);
    }
}
