using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLibrary.Logic
{
    public class CategoryProcessor
    {
        private SqlDataAccess sqlDataAccess;

        public CategoryProcessor(SqlDataAccess sqlDataAccess)
        {
            this.sqlDataAccess = sqlDataAccess;
        }
        public List<CategoryDTO> LoadCategories()
        {
            string sql = $@"SELECT * 
FROM Categories";
            return sqlDataAccess.LoadData<CategoryDTO>(sql);
        }
        public CategoryDTO Get(int id)
        {
            var parameter = new
            {
                Id = id
            };
            string sql = $@"SELECT * 
FROM Categories
WHERE Categories.Id=@Id";
            return sqlDataAccess.LoadData<CategoryDTO>(sql, parameter).FirstOrDefault();
        }
        public int Create(CategoryDTO category)
        {
            string sql = $@"INSERT INTO Categories 
(Name,Description) VALUES (@Name, @Description)";
            return sqlDataAccess.SaveData(sql, category);
        }
        public int Update(CategoryDTO category)
        {
            string sql = $@"UPDATE Categories 
SET Name=@Name, Description=@Description 
WHERE Id=@Id";
            return sqlDataAccess.SaveData(sql, category);
        }
        public int Delete(int id)
        {
            var parameter = new
            {
                Id = id
            };
            string sql1 = $@"DELETE FROM Ingredients_Categories 
WHERE Ingredients_Categories.Categories_Id=@Id";
            string sql2 = $@"DELETE FROM Categories
WHERE Id=@Id";
            sqlDataAccess.DeleteData(sql1, parameter);
            return sqlDataAccess.DeleteData(sql2, parameter);
        }
    }
}
