using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
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
    }
}
