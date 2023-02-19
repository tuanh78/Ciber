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
    public class OrderRepository : IOrderRepository
    {

        /// <summary>
        /// Tạo đơn hàng
        /// </summary>
        /// <param name="order">Đơn hàng</param>
        /// <returns></returns>
        public int CreateOrder(Orders order)
        {
            var query = "INSERT INTO orders (OrderName, CustomerID, ProductID, Amount, OrderDate) VALUES (@OrderName, @CustomerID, @ProductID, @Amount, @OrderDate)";

            var param = new Dictionary<string, object>();
            param.Add("OrderName", order.OrderName);
            param.Add("CustomerID", order.CustomerID);
            param.Add("ProductID", order.ProductID);
            param.Add("Amount", order.Amount);
            param.Add("OrderDate", order.OrderDate);
            // số bản ghi dược tạo ra
            var rowAffect = 0;
            using (IDbConnection connection = new MySqlConnection(CommonValue.ConnectionString))
            {
                rowAffect = connection.Execute(query, param);
            }
            return rowAffect;
        }

        /// <summary>
        /// Xóa đơn hàng
        /// </summary>
        /// <param name="id">ID đơn hàng</param>
        /// <returns></returns>
        public int DeleteOrder(int id)
        {
            var query = "DELETE FROM Companies WHERE Id = @Id";
            using (IDbConnection connection = new MySqlConnection(CommonValue.ConnectionString))
            {
                connection.Execute(query, new { id });
            }
            return 0;
        }

        /// <summary>
        /// Lấy thông tin đơn hàng
        /// </summary>
        /// <param name="id">ID đơn hàng</param>
        /// <returns></returns>
        public Orders GetOrder(int id)
        {
            var query = "SELECT * FROM order WHERE Id = @Id";

            using (IDbConnection connection = new MySqlConnection(CommonValue.ConnectionString))
            {
                var company = connection.QuerySingleOrDefault<Orders>(query, new { id });
                return company;
            }
        }
        /// <summary>
        /// Lấy danh sách đơn hàng phân trang
        /// </summary>
        /// <returns></returns>
        public (List<OrderDetail>, int) GetOrderDetailsPaging(PagingParam paging)
        {
            var proc = "Proc_GetOrdersPaging";
            var procTotal = "Proc_GetTotalOrders";
            var param = new Dictionary<string, object>();
            param.Add("v_limit", paging.PageSize);
            param.Add("v_offset", (paging.PageIndex - 1) * paging.PageSize);
            param.Add("v_search", paging.TxtSearch);

            var paramTotal = new Dictionary<string, object>();
            paramTotal.Add("v_search", paging.TxtSearch);
            var orders = new List<OrderDetail>();
            int total = 0;
            using (IDbConnection connection = new MySqlConnection(CommonValue.ConnectionString))
            {
                orders = connection.Query<OrderDetail>(proc, param, commandType: CommandType.StoredProcedure).ToList();
                total = connection.QueryFirstOrDefault<int>(procTotal, paramTotal, commandType: CommandType.StoredProcedure);
            }

            return (orders, total);
        }

        /// <summary>
        /// Lấy danh sách đơn hàng
        /// </summary>
        /// <returns></returns>
        public List<Orders> GetOrders()
        {
            var query = "SELECT * FROM orders";

            using (IDbConnection connection = new MySqlConnection(CommonValue.ConnectionString))
            {
                var companies = connection.Query<Orders>(query);
                return companies.ToList();
            }
        }

        /// <summary>
        /// Cập nhật đơn hàng
        /// </summary>
        /// <param name="Order">Thông tin đơn hàng</param>
        /// <returns></returns>
        public Orders UpdateOrder(Orders Order)
        {
            var query = "INSERT INTO Companies (CompanyName, CompanyAddress, Country,GlassdoorRating) VALUES (@CompanyName, @CompanyAddress, @Country, @GlassdoorRating WHERE Id = @Id)";
            var parameters = new DynamicParameters();
            //parameters.Add("Name", company.CompanyName, DbType.String);
            //parameters.Add("Address", company.CompanyAddress, DbType.String);
            //parameters.Add("Country", company.Country, DbType.String);
            //parameters.Add("Country", company.GlassdoorRating, DbType.Int32);
            using (IDbConnection connection = new MySqlConnection(CommonValue.ConnectionString))
            {
                connection.Execute(query, parameters);
            }

            return new Orders();
        }

    }
}