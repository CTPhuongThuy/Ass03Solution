using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance = null;
        private static readonly object instanceLock = new object();
        private OrderDetailDAO() { }
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<OrderDetail> GetOrderDetailList()
        {
            var members = new List<OrderDetail>();
            try
            {
                using var context = new AssignmentContext();
                members = context.OrderDetails.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return members;

        }

        public OrderDetail GetOrderDetailByID(int OrderID, int ProductID)
        {
            OrderDetail mem = null;
            try
            {
                using var context = new AssignmentContext();
                mem = context.OrderDetails.SingleOrDefault(c=> c.OrderId==OrderID && c.ProductId==ProductID);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return mem;
        }

        //-----------------------------------------------------------------
        public void AddNew(OrderDetail OrderDetail)
        {
            try
            {
                OrderDetail mem = GetOrderDetailByID(OrderDetail.OrderId, OrderDetail.ProductId);
                if (mem == null)
                {
                    using var context = new AssignmentContext();
                    context.OrderDetails.Add(OrderDetail);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The OrderDetail is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //-----------------------------------------------------------------
        public void Update(OrderDetail OrderDetail)
        {
            try
            {
                OrderDetail mem = GetOrderDetailByID(OrderDetail.OrderId, OrderDetail.ProductId);
                if (mem != null)
                {
                    using var context = new AssignmentContext();
                    context.OrderDetails.Update(OrderDetail);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The OrderDetail does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Remove2(int OrderId, int ProductId)
        {
            try
            {
                OrderDetail mem = GetOrderDetailByID(OrderId, ProductId);
                if (mem != null)
                {
                    using (AssignmentContext db = new AssignmentContext())
                    {
                        OrderDetail orderdetail = db.OrderDetails.Where(d => d.OrderId == OrderId).First();
                        orderdetail.Status = 0;
                        db.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The member does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-----------------------------------------------------------------
        public void Remove(int OrderId, int ProductId)
        {
            try
            {
                OrderDetail orderDetail = GetOrderDetailByID(OrderId, ProductId);
                if (orderDetail != null)
                {
                    using var context = new AssignmentContext();
                    context.OrderDetails.Remove(orderDetail);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The  OrderDetail does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
