using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataLibrary.Logic
{
    public class CategoryProcessor : Processor
    {
        private SqlDataAccess sqlDataAccess;
        public CategoryProcessor(SqlDataAccess sqlDataAccess)
        {
            this.sqlDataAccess = sqlDataAccess;
            defaultStoredProceduresPrefix = "Categories";
        }
        public List<CategoryDTO> GetAll()
        {
            return sqlDataAccess.LoadData<CategoryDTO>(GetDefaultStoredProcedureName(),commandType: CommandType.StoredProcedure);
        }
        public CategoryDTO Get(int id)
        {
            var parameter = new
            {
                Id = id
            };
            string sql = "Categories_Get";
            return sqlDataAccess.LoadData<CategoryDTO>(sql, parameter, CommandType.StoredProcedure).FirstOrDefault();
        }
        public int Create(CategoryDTO category)
        {
            string sql = "Categories_Create";
            return sqlDataAccess.SaveData(sql, category, CommandType.StoredProcedure);
        }
        public int Update(CategoryDTO category)
        {
            string sql = "Categories_Update";
            return sqlDataAccess.SaveData(sql, category, CommandType.StoredProcedure);
        }
        public int Delete(int id)
        {
            var parameter = new
            {
                Id = id
            };
            string sql1 = "IngredientsCategories_Delete";
            string sql2 = "Categories_Delete";
            sqlDataAccess.DeleteData(sql1, parameter, CommandType.StoredProcedure);
            return sqlDataAccess.DeleteData(sql2, parameter, CommandType.StoredProcedure);
        }

    }
}
