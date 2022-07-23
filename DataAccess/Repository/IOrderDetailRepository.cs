using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetOrderDetails();
        OrderDetail GetOrderDetailByID(int OrderID, int ProductID);
        OrderDetail GetOrderDetailByOrderID(int OrderID);
        void InsertOrderDetail(OrderDetail OrderDetail);
        void DeleteOrderDetail(int OrderID, int ProductID);
        void UpdateOrderDetail(OrderDetail OrderDetail);

    }
}
