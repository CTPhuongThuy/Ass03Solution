using DataAccess.DataAccess;
using DataAccess.Repository;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        //-----------------------
        AssignmentContext db = new AssignmentContext();
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        //-----------------------

        public IEnumerable<Product> getProductList()
        {
            var products = new List<Product>();
            List<Product> FList = new List<Product>();
            try
            {
                using var context = new AssignmentContext();
                products = context.Products.ToList();
                for (int i = 1; i <= products.Count; i++)
                {
                    if (products[i - 1].Status == 1) { FList.Add(products[i - 1]); }
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return FList;

        }

        //-----------------------
        public Product GetProductByID(int ProductID)
        {
            Product product = null;
            try
            {
                using var context = new AssignmentContext();
                product = context.Products.SingleOrDefault(p => p.ProductId == ProductID);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return product;
        }

        //-----------------------
        public void addNewProduct(Product product)
        {
            try
            {
                Product pro = GetProductByID(product.ProductId);
                if (pro == null)
                {
                    using var context = new AssignmentContext();
                    context.Products.Add(product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The product is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-----------------------
        public void Update(Product product)
        {
            try
            {
                Product pro = GetProductByID(product.ProductId);
                if (pro != null)
                {
                    using var context = new AssignmentContext();
                    context.Products.Update(product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The product does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-------------------------

        public void Remove(int productId)
        {
            try
            {
                Product pro = GetProductByID(productId);
                if (pro != null)
                {
                    using (AssignmentContext db = new AssignmentContext())
                    {
                        Product product = db.Products.Where(d => d.ProductId == productId).First();
                        product.Status = 0;
                        db.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The product does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Product> GetFilteredProduct(String tag)
        {
            List<Product> filtered = new List<Product>();
            foreach (Product product in getProductList())
            {
                int add = 0;
                if (product.ProductId.ToString().Contains(tag))
                    add = 1;
                if (product.ProductName.Contains(tag))
                    add = 1;
                if (product.UnitPrice.ToString().Contains(tag))
                    add = 1;
                if (product.UnitslnStock.ToString().Contains(tag))
                    add = 1;
                if (add == 1)
                    filtered.Add(product);
            }
            return filtered;
        }
    }
}
