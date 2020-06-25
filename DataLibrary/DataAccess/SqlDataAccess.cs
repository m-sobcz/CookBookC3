using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Configuration;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Data.SqlClient;

namespace DataLibrary.DataAccess
{
    public class SqlDataAccess
    {
        private IConfiguration configuration;

        public SqlDataAccess(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetConnectionString(string connectionName = "CookBookDB")
        {
            return configuration.GetConnectionString(connectionName);
        }
        public List<T> LoadData<T>(string sql,object parameter=null)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                return connection.Query<T>(sql, parameter).ToList();
            }

        }
        public  int SaveData<T>(string sql, T data)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                return connection.Execute(sql, data);
            }
        }
    }
}
