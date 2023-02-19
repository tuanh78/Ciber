using Ciber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Repositories
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Lấy thông tin người dùng theo id
        /// </summary>
        /// <param name="id">ID người dùng</param>
        /// <returns></returns>
        Customer GetCustomer(int id);

        /// <summary>
        /// Lấy danh sách người dùng
        /// </summary>
        /// <returns></returns>
        List<Customer> GetCustomers();
    }
}
