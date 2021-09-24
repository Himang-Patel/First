using CL.Model;
using CL.Utility;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CL.Repository
{
    public class Calegory
    {
        private readonly ConnectionString _connectionString;

        internal IDbConnection DbConnection => new SqlConnection(_connectionString.ConnString);
        public Task<IEnumerable<CategoryModel>> GetCategory()
        {
            using (IDbConnection dbCon = DbConnection)
            {
                dbCon.Open();
                return dbCon.QueryAsync<CategoryModel>("GetCategory", null, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
