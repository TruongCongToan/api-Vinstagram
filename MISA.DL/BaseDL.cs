using Dapper;
using MISA.Common.Entities;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DL
{
    public class BaseDL
    {
        protected string _connectionString = "" +
            "Host = 47.241.69.179;" +
            "Port = 3306;" +
            "Database= ITSS_DATABASE;" +
            "User Id = nvmanh;" +
            "Password= 12345678";
        protected IDbConnection _dbConnection;


        public IEnumerable<MISAEntity> GetAll<MISAEntity>()
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var tableName = typeof(MISAEntity).Name;
                var sqlCommand = $"Proc_Get{tableName}";
                var entities = _dbConnection.Query<MISAEntity>(sqlCommand, commandType: CommandType.StoredProcedure);
                return entities;
            }
        }

        public MISAEntity GetById<MISAEntity>(Guid id)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var tableName = typeof(MISAEntity).Name;
                var sqlCommand = $"SELECT * FROM {tableName} WHERE {tableName}Id = '{id.ToString()}'";
                var entyties = _dbConnection.QueryFirstOrDefault<MISAEntity>(sqlCommand);
                return entyties;
            }
        }
        public IEnumerable<MISAEntity>Search<MISAEntity>(string m_input)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var tableName = typeof(MISAEntity).Name;
                var param = new {m_input};
                var sqlCommand = "Proc_GetUserByName";
                var customers = _dbConnection.Query<MISAEntity>(sqlCommand, param: param, commandType: CommandType.StoredProcedure);
                return customers;
            }
        }
        public int Insert<MISAEntity>(MISAEntity entity)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var tableName = typeof(MISAEntity).Name;
                var storeName = $"Proc_Insert{tableName}";
                var rowsAffect = _dbConnection.Execute(storeName, param: entity, commandType: CommandType.StoredProcedure);
                return rowsAffect;
            }
        }
        
        public int Update<MISAEntity>(MISAEntity entity, Guid entityId)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {

                var tableName = typeof(MISAEntity).Name;
                var entityIdPropertyName = $"{tableName}Id";
                var entityIdProperty = typeof(MISAEntity).GetProperty("UserId");
                if (entityIdProperty != null)
                    typeof(MISAEntity).GetProperty("UserId").SetValue(entity, entityId);

                var storeName = $"Proc_Update{tableName}";
                var rowsAffect = _dbConnection.Execute(storeName, param: entity, commandType: CommandType.StoredProcedure);
                return rowsAffect;
            }
        }

        public int Delete<MISAEntity>(Guid entityId)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {

                var tableName = typeof(MISAEntity).Name;

                var sqlCommand = $" SET FOREIGN_KEY_CHECKS=OFF; DELETE FROM {tableName} WHERE {tableName}Id = '{entityId.ToString()}'";
                var rowsAffect = _dbConnection.Execute(sqlCommand);
                return rowsAffect;
            }
        }
    }
}
