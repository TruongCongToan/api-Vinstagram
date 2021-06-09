using Dapper;
using MISA.BL.Exceptions;
using MISA.Common.Entities;
using MISA.DL;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace MISA.BL
{
  public class UserBL:BaseBL<User>
    {

        protected string _connectionString = "" +
        "Host = 47.241.69.179;" +
        "Port = 3306;" +
        "Database= ITSS_DATABASE;" +
        "User Id = nvmanh;" +
        "Password= 12345678";
        protected IDbConnection _dbConnection;
        protected override void Validate(User entity)
        {
            if (entity is User)
            {
                var user = entity as User;
                UserDL userDL = new UserDL();
                // Validate dữ liệu:
                // 1. Đã nhập ten hay chưa? nếu chưa nhập thì đưa ra cảnh báo lỗi:
                if (string.IsNullOrEmpty(user.UserName))
                {
                    throw new GuardException<User>("Mã khách hàng không được phép để trống.", user);
                }
                // 2. Check ten khách hàng đã tồn tại hay chưa?
                var isExists = userDL.CheckUserNameExist(user.UserName);
                if (isExists == true)
                {
                    throw new GuardException<User>("Mã khách hàng đã tồn tạo trong hệ thống, vui lòng kiểm tra lại", null);
                }

                // 3. Kiểm tra Email có đúng định dạng hay không?
                var emailTemplate = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
                if (!Regex.IsMatch(user.Email, emailTemplate))
                {
                    throw new GuardException<User>("Email không đúng định dạng, vui lòng kiểm tra lại", null);
                }
            }
        }
        public IEnumerable<User> Search<User>(string m_input)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var tableName = typeof(User).Name;
                var param = new { m_input };
                var sqlCommand = "Proc_GetUserByName";
                var users = _dbConnection.Query<User>(sqlCommand, param: param, commandType: CommandType.StoredProcedure);
                return users;
            }
        }
    }
}
