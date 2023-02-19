using Ciber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Repositories
{
    public interface IProductRepository
    {
        /// <summary>
        /// Lấy sản phẩm theo id
        /// </summary>
        /// <param name="id">ID sản phẩm</param>
        /// <returns></returns>
        Product GetProduct(int id);

        /// <summary>
        /// Lấy danh sách sản phẩm
        /// </summary>
        /// <returns></returns>
        List<Product> GetProducts();
    }
}
