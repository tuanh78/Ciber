using Ciber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Repositories
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Lấy thông tin người dùng theo id
        /// </summary>
        /// <param name="id">ID người dùng</param>
        /// <returns></returns>
        Orders GetOrder(int id);

        /// <summary>
        /// Lấy danh sách người dùng
        /// </summary>
        /// <returns></returns>
        List<Orders> GetOrders();

        /// <summary>
        /// Tạo người dùng
        /// </summary>
        /// <param name="Order"></param>
        /// <returns></returns>
        int CreateOrder(Orders Order);

        /// <summary>
        /// Cập nhật thông tin người dùng
        /// </summary>
        /// <param name="Order"></param>
        /// <returns></returns>
        Orders UpdateOrder(Orders Order);

        /// <summary>
        /// Xóa người dùng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteOrder(int id);

        /// <summary>
        /// Lấy danh sách đơn hàng phân trang
        /// </summary>
        /// <returns></returns>
        (List<OrderDetail>, int) GetOrderDetailsPaging(PagingParam paging);
    }
}
