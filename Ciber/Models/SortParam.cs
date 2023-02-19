using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Models
{
    public class SortParam
    {
        /// <summary>
        /// Cột sort dữ liệu
        /// </summary>
        public int ColumnSort { get; set; }

        /// <summary>
        /// Kiểu sort
        /// </summary>
        public int TypeSort { get; set; }
    }
}
