using eStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Repository;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Http;

namespace eStore.Controllers
{
    public class ProductsController : Controller
    {
        IProductRepository productRepository = new ProductRepository();
        // GET: ProductController
        public ActionResult Index()
        {
            var proList = productRepository.GetProducts();
            return View(proList);
        }



        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = productRepository.GetProductByID(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {

            if (ModelState.IsValid)
            {
                productRepository.InsertProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = productRepository.GetProductByID(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                productRepository.UpdateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = productRepository.GetProductByID(id);
            if (id == null)
            {
                return NotFound();
            }
            productRepository.RemoveProduct(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Search/5

        public ActionResult Search(string name, string price)
        {
            ViewBag.Search = name;
            ViewBag.Price = price;
            var products = productRepository.GetProducts();
            var result = products;
            if (name == null && price != null)
            {
                if (price == "<50000")
                    result = products.Where(p => p.UnitPrice <= 50000);
                if (price == "50000-100000")
                    result = products.Where(p => p.UnitPrice >= 50000 && p.UnitPrice <= 100000);
                if (price == ">100000")
                    result = products.Where(p => p.UnitPrice >= 100000);
            }
                
            if(name != null && price == null)
            {
                result = products.Where(p => p.ProductName.ToLower().Contains(name));
            }
            if(name != null && price != null)
            {
                result = products.Where(p => p.ProductName.ToLower().Contains(name));
                if (price == "<50000")
                    result = products.Where(p => p.ProductName.ToLower().Contains(name) & p.UnitPrice <= 50000);
                if (price == "50000-100000")
                    result = products.Where(p => p.ProductName.ToLower().Contains(name) & p.UnitPrice >= 50000 && p.UnitPrice <= 100000);
                if (price == ">100000")
                    result = products.Where(p => p.ProductName.ToLower().Contains(name) & p.UnitPrice >= 100000);
            }    
            
            return View(result);
        }


    }
}
