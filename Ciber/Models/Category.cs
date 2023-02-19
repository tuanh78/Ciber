using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Models
{
    /// <summary>
    /// Danh mục
    /// </summary>
    public class Category : BaseModel
    {
        /// <summary>
        /// ID danh mục
        /// </summary>
        public long CategoryID { get; set; }

        /// <summary>
        /// Tên danh mục
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Mô tả danh mục
        /// </summary>
        public string Description { get; set; }
    }
}
