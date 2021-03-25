using System.Collections.Generic;
using System.Data.SqlClient;
using AspNetCoreMvcWithLightVue.Models;
using Dapper;

namespace AspNetCoreMvcWithLightVue.Repositories
{
    public class NorthwindRepository
    {
        private readonly SqlConnection _conn;

        public NorthwindRepository(SqlConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<NorthwindOrderDto> GetOrderList()
        {
            var sql = @"
SELECT *
FROM [dbo].[Orders]
";
            return _conn.Query<NorthwindOrderDto>(sql);
        }
    }
}