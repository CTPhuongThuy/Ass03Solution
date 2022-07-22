﻿using eStore.Models;
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
    public class OrderController : Controller
    {
        IOrderRepository orderRepository = new OrderRepository();
        // GET: OrderController
        public ActionResult Index()
        {
            var model = orderRepository.GetOrders();
            return View(model);
        }

        // GET: OrderController/Search/
        public ActionResult Search(DateTime startTime,DateTime endTime)
        {
           
            if (startTime == null && endTime == null)
            {
                return NotFound();
            }
            var order = orderRepository.GetOrderTime(startTime, endTime);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
        // GET: OrderController/Details/
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = orderRepository.GetOrderByID(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                orderRepository.InsertOrder(order);
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: OrderController/Edit
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = orderRepository.GetOrderByID(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: OrderController/Edit/:{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                orderRepository.UpdateOrder(order);
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: OrderController/Delete
        public ActionResult Delete(int id)
        {
            var order = orderRepository.GetOrderByID(id);
            if (order == null)
            {
                return NotFound();
            }
            orderRepository.DeleteOrder(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: OrderController/Delete/:{id}
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



    }
}
