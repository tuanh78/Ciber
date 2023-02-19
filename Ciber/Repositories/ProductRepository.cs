using Ciber.Common;
using Ciber.DBContext;
using Ciber.Models;
using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Repositories
{
    public class ProductRepository : IProductRepository
    {
        
        /// <summary>
        /// Lấy thông tin sản phẩm theo id
        /// </summary>
        /// <param name="id">ID sản phẩm</param>
        /// <returns></returns>
        public Product GetProduct(int id)
        {
            var query = "SELECT p.ProductID, p.ProductName, p.CategoryID, p.Price, p.Description, p.Quantity FROM product p Where p.ProductID = @Id;";

            using (IDbConnection connection = new MySqlConnection(CommonValue.ConnectionString))
            {
                var company = connection.QuerySingleOrDefault<Product>(query, new { id });
                return company;
            }
        }

        /// <summary>
        /// Lấy danh sách sản phẩm
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts()
        {
            var query = "SELECT p.ProductID, p.ProductName, p.CategoryID, p.Price, p.Description, p.Quantity FROM product p;";

            using (IDbConnection connection = new MySqlConnection(CommonValue.ConnectionString))
            {
                var companies = connection.Query<Product>(query);
                return companies.ToList();
            }
        }
    }
}
