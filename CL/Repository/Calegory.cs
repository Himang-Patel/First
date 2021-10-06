using CL.Common;
using CL.Interface;
using CL.Model;
using CL.Utility;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CL.Repository
{
    public class Calegory : ICategory
    {
        public async Task<IEnumerable<CategoryModel>> GetCategory()
        {
            using (SqlConnection dbCon = new SqlConnection(ConnectionStrings.ConnString))
            {
                dbCon.Open();
                var result = await dbCon.QueryAsync<CategoryModel>(StoreProcedureName.sp_GetCategory, null, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<int> DeleteCategory(int Id)
        {
            using (SqlConnection dbCon = new SqlConnection(ConnectionStrings.ConnString))
            {
                dbCon.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id, DbType.Int32);
                return await dbCon.ExecuteScalarAsync<int>(StoreProcedureName.sp_RemoveCategory, parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<int> AddCategory(CategoryModel categoryModel)
        {
            using (SqlConnection dbCon = new SqlConnection(ConnectionStrings.ConnString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", categoryModel.Id, DbType.Int32);
                parameters.Add("@Name", categoryModel.Name, DbType.String);
                parameters.Add("@DisplayOrder", categoryModel.DisplayOrder, DbType.Int32);

                var result = await dbCon.ExecuteScalarAsync<int>(StoreProcedureName.sp_UpsertCategory, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
