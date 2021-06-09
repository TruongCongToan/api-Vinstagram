using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using MySqlConnector;
using System.Data;
namespace MISA.DL
{
    public class UserDL:BaseDL
    {
        public bool CheckUserNameExist(string userName)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                // 3. Thực thi lệnh lấy dữ liệu trong Database:
                var sqlCommand = $"Proc_CheckUserNameExist";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@m_UserName", userName);
                var res = _dbConnection.ExecuteScalar<bool>(sqlCommand, dynamicParameters, commandType: CommandType.StoredProcedure);
                return res;
            }
        }
    }
}
