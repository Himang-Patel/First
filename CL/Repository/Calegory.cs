﻿using CL.Common;
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
    public class Calegory: ICategory
    {
        public async Task<IEnumerable<CategoryModel>> GetCategory()
        {
            using (SqlConnection dbCon = new SqlConnection(ConnectionStrings.ConnString))
            {
                dbCon.Open();
                var result= await dbCon.QueryAsync<CategoryModel>(StoreProcedureName.sp_GetCategory, null, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
