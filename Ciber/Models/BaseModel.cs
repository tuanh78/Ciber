using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Models
{
    /// <summary>
    /// Class chứa các property chung
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Thời gian tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Người sửa
        /// </summary>
        public string ModifiedBy { get; set; }
        /// <summary>
        /// Thời gian sửa
        /// </summary>
        public DateTime ModifiedDate { get; set; }

    }
}
