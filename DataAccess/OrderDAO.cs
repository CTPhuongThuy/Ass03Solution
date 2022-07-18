using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Order> GetOrderList2()
        {
            var orders = new List<Order>();
            List<Order> FList = new List<Order>();
            try
            {
                using var context = new AssignmentContext();
                orders = context.Orders.ToList();
                for (int i = 1; i <= orders.Count; i++)
                {
                    if (orders[i - 1].Status == 1) { FList.Add(orders[i - 1]); }
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return FList;

        }
        public IEnumerable<Order> GetOrderTime(DateTime startime, DateTime endTime)
        {
            IEnumerable<Order> List = null;
            try
            {
                using AssignmentContext dbContext = new AssignmentContext();
                List = dbContext.Orders
                    .Where(o => o.OrderDate >= startime)
                    .Where(o => o.OrderDate <= endTime)
                    .ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return List;
        }
        public IEnumerable<Order> GetOrderList()
        {
            var members = new List<Order>();
            try
            {
                using var context = new AssignmentContext();
                members = context.Orders.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return members;

        }

        public Order GetOrderByID(int OrderID)
        {
            Order mem = null;
            try
            {
                using var context = new AssignmentContext();
                mem = context.Orders.SingleOrDefault(c=>c.OrderId == OrderID);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return mem;
        }

        //-----------------------------------------------------------------
        public void AddNew(Order Order)
        {
            try
            {
                Order mem = GetOrderByID(Order.OrderId);
                if (mem == null)
                {
                    using var context = new AssignmentContext();
                    context.Orders.Add(Order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Order is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Remove2(int OrderId)
        {
            try
            {
                Order oder = GetOrderByID(OrderId);
                if (oder != null)
                {
                    using(AssignmentContext db=new AssignmentContext())
                    {
                        Order order = db.Orders.Where(d => d.OrderId == OrderId).First();
                        order.Status = 0;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //-----------------------------------------------------------------
        public void Update(Order Order)
        {
            try
            {
                Order mem = GetOrderByID(Order.OrderId);
                if (mem != null)
                {
                    using var context = new AssignmentContext();
                    context.Orders.Update(Order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Order does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-----------------------------------------------------------------
        public void Remove(int OrderId)
        {
            try
            {
                Order mem = GetOrderByID(OrderId);
                if (mem != null)
                {
                    using var context = new AssignmentContext();
                    context.Orders.Remove(mem);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Order does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
