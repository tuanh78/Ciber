using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Models
{
    /// <summary>
    /// Sản phẩm
    /// </summary>
    public class Product : BaseModel
    {
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
        /// Giá sản phẩm
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Số lượng
        /// </summary>
        public int Quantity { get; set; }
    }
}
