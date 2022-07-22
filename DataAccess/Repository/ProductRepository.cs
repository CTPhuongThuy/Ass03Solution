using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetFilteredProducts(string tag) => ProductDAO.Instance.GetFilteredProduct(tag);
        public Product GetProductByID(int ProductID) => ProductDAO.Instance.GetProductByID(ProductID);

        public IEnumerable<Product> GetProducts() => ProductDAO.Instance.getProductList();

        public void InsertProduct(Product product) => ProductDAO.Instance.addNewProduct(product);

        public void RemoveProduct(int productId) => ProductDAO.Instance.Remove(productId);

        public void UpdateProduct(Product product) => ProductDAO.Instance.Update(product);
    }
}
