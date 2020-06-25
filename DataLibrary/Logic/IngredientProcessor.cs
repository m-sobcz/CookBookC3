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
        public int CreateIngredient(IngredientModelDTO ingredientModel)
        {
            string sql = $@"insert into dbo.Ingredients (Name,Description,Callories,Category,CostPerUnit) values (@Name, @Description,@Callories ,@Category,@CostPerUnit)";
            return sqlDataAccess.SaveData(sql, ingredientModel);
        }
        public List<IngredientModelDTO> LoadIngredients()
        {
            string sql = $@"select * from dbo.Ingredients"; //Name,Description,Callories,Category,CostPerUnit
            return sqlDataAccess.LoadData<IngredientModelDTO>(sql);
        }
        public List<IngredientModelDTO> LoadIngredients(IngredientColumn column, string value)
        {
            //parameter injection
            var parameter = new
            {
                Value = value
            };
            string sql = $@"select Name,Description,Callories,Category,CostPerUnit from dbo.Ingredients where '{column}'=@Value";//'{value}'
            return sqlDataAccess.LoadData<IngredientModelDTO>(sql,parameter);
        }
    }
}
