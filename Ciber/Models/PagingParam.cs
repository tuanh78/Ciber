using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Models
{
    public class PagingParam
    {
        /// <summary>
        /// Trang hiện tại
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// Số bản ghi trên một trang
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Từ tìm kiếm
        /// </summary>
        public string TxtSearch { get; set; }

        /// <summary>
        /// Tổng số trang
        /// </summary>
        public int TotalPage { get; set; }
    }
}
