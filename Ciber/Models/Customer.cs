using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Models
{
    /// <summary>
    /// Khách hàng
    /// </summary>
    public class Customer : BaseModel
    {
        // ID khách hàng
        [Key]
        public int CustomerID { get; set; }
        // Tên khách hàng
        public string CustomerName { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }
    }
}
