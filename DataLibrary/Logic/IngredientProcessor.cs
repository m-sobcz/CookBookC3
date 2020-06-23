using DataLibrary.DataAccess;
using DataLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace DataLibrary.Logic
{
    public class IngredientProcessor : IIngredientProcessor
    {
        private SqlDataAccess sqlDataAccess;

        public IngredientProcessor(SqlDataAccess sqlDataAccess)
        {
            this.sqlDataAccess = sqlDataAccess;
        }
        public int CreateIngredient(string name, string description)
        {
            IngredientModel data = new IngredientModel
            {
                Name = name,
                Description = description
            };
            string sql = @"insert into dbo.Ingredients (Name,Description) values (@Name, @Description)";
            return sqlDataAccess.SaveData(sql, data);
        }
        public List<IngredientModel> LoadIngredients()
        {
            string sql = @"select Name,Description from dbo.Ingredients";
            return sqlDataAccess.LoadData<IngredientModel>(sql);

        }
    }
}
