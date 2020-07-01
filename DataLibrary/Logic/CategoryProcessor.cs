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
            string sql = $@"select * from dbo.Categories"; //Name,Description,Callories,Category,CostPerUnit
            return sqlDataAccess.LoadData<CategoryDTO>(sql);
        }
    }
}
