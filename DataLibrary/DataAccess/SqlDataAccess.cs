using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Configuration;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Data.SqlClient;

namespace CookBookBLL.DataAccess
{
    public class SqlDataAccess
    {
        private readonly IConfiguration configuration;

        public SqlDataAccess(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetConnectionString(string connectionName = "CookBookDB")
        {
            return configuration.GetConnectionString(connectionName);
        }
        public List<T> Load<T>(string sql,object parameter=null, CommandType commandType=CommandType.StoredProcedure)
        {        
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                return connection.Query<T>(sql, parameter,commandType: commandType).ToList();
            }
        }
        public List<Tout> Load<Tin1,Tin2,Tout>(string sql,Func<Tin1,Tin2,Tout> mapping, object parameter = null, CommandType commandType = CommandType.StoredProcedure, string splitOn="CategoryList")
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                return connection.Query<Tin1, Tin2, Tout>(sql, mapping, parameter, commandType: commandType, splitOn: splitOn).ToList();
            }
        }
        public int Save<T>(string sql, T data, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                object result = connection.ExecuteScalar(sql, data, commandType: commandType);
                return (int.TryParse(result?.ToString(), out int intResult)) ? intResult : -1;
            }
        }
        public int Delete(string sql, object parameter,CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                return connection.Execute(sql, parameter, commandType: commandType);
            }
        }


    }
}
