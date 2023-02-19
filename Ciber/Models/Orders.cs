using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Models
{
    /// <summary>
    /// Đơn hàng
    /// </summary>
    public class Orders : BaseModel
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
        /// ID sản phẩm
        /// </summary>
        public long ProductID { get; set; }

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
