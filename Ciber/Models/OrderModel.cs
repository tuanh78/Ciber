using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Models
{
    /// <summary>
    /// Model hiển thị danh sách đơn hàng
    /// </summary>
    public class OrderModel
    {
        public List<OrderDetail> ListOrder;

        public DateTime OrderDate { get; set; }
    }

    public class OrderDetail
    {
        /// <summary>
        /// ID đơn hàng
        /// </summary>
        public long OrderID { get; set; }

        /// <summary>
        /// Tên đơn hàng
        /// </summary>
        public string OrderName { get; set; }
        /// <summary>
        /// ID khách hàng
        /// </summary>
        public long CustomerID { get; set; }
        /// <summary>
        /// Tên khách hàng
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// ID sản phẩm
        /// </summary>
        public long ProductID { get; set; }
        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// ID danh mục
        /// </summary>
        public long CategoryID { get; set; }
        /// <summary>
        /// Tên danh mục
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Số lượng hàng hóa đặt
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Ngày đặt hàng
        /// </summary>
        public DateTime OrderDate { get; set; }
    }
}
