using DataLibrary.DataAccess;
using DataLibrary.Enums;
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
        public int CreateIngredient(IngredientDTO ingredientModel)
        {
            string sql = $@"insert into dbo.Ingredients (Name,Description,Callories,Cost) values (@Name, @Description,@Callories ,@Cost)";
            return sqlDataAccess.SaveData(sql, ingredientModel);
        }
        public List<IngredientDTO> LoadIngredients()
        {
            string sql = $@"select * from dbo.Ingredients"; //Name,Description,Callories,Category,CostPerUnit
            return sqlDataAccess.LoadData<IngredientDTO>(sql);
        }
        public List<IngredientDTO> LoadIngredients(IngredientColumn column, string value)
        {
            //parameter injection
            var parameter = new
            {
                Value = value
            };
            string sql = $@"select * from dbo.Ingredients where '{column}'=@Value";//'{value}'
            return sqlDataAccess.LoadData<IngredientDTO>(sql,parameter);
        }
    }
}
