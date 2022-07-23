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
using eStore.ViewModels;

namespace eStore.Controllers
{
    public class OrderController : Controller
    {
        IOrderRepository orderRepository = new OrderRepository();
        IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
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
            var orderDetail = orderDetailRepository.GetOrderDetailByOrderID(id);
            if (order == null || orderDetail == null)
            {
                return NotFound();
            }
            var DetailOrderAndOrderDetail = new OrderDetailViewModel
            {
                Order = order,
                OrderDetail = orderDetail,
            };
            return View(DetailOrderAndOrderDetail);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order, OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                orderRepository.InsertOrder(order);
                orderDetail.OrderId = order.OrderId;
                orderDetailRepository.InsertOrderDetail(orderDetail);
                return RedirectToAction(nameof(Index));
            }
            var CreateModel = new OrderDetailViewModel
            {
                Order = order,
                OrderDetail = orderDetail,
            };
            return View(CreateModel);
        }

        // GET: OrderController/Edit
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = orderRepository.GetOrderByID(id);
            var orderDetail = orderDetailRepository.GetOrderDetailByOrderID(id);
            if (order == null)
            {
                return NotFound();
            }
            OrderDetailViewModel orderDetailView = new OrderDetailViewModel
            {
                Order = order,
                OrderDetail = orderDetail,
            };
            return View(orderDetailView);
        }

        // POST: OrderController/Edit/:{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Order order, OrderDetail orderDetail)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                orderRepository.UpdateOrder(order);
                orderDetailRepository.UpdateOrderDetail(orderDetail);
                return RedirectToAction(nameof(Index));
            }

            var EditModel = new OrderDetailViewModel
            {
                Order = order,
                OrderDetail = orderDetail,
            };
            return View(EditModel);
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
