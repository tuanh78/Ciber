using Ciber.Common;
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
    public class CustomerRepository : ICustomerRepository
    {
        public Customer GetCustomer(int id)
        {
            var query = "SELECT * FROM customer WHERE Id = @Id";

            using (IDbConnection connection = new MySqlConnection(CommonValue.ConnectionString))
            {
                var company = connection.QuerySingleOrDefault<Customer>(query, new { id });
                return company;
            }
        }

        public List<Customer> GetCustomers()
        {
            var query = "SELECT * FROM customer p;";

            using (IDbConnection connection = new MySqlConnection(CommonValue.ConnectionString))
            {
                var customers = connection.Query<Customer>(query);
                return customers.ToList();
            }
        }
    }
}
