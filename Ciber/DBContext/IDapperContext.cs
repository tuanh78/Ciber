using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.DBContext
{
    public interface IDapperContext
    {
        public IDbConnection CreateConnection();
    }
}
