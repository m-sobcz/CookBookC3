﻿using CookBookBLL.DataAccess;
using CookBookBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBookBLL.Logic
{
    public class CuisineProcessor : Processor
    {
        private SqlDataAccess sqlDataAccess;
        public CuisineProcessor(SqlDataAccess sqlDataAccess)
        {
            this.sqlDataAccess = sqlDataAccess;
            defaultStoredProceduresPrefix = "Cuisines";
        }
        public List<CuisineDTO> GetAll()
        {
            return sqlDataAccess.Load<CuisineDTO>(GetDefaultStoredProcedureName());
        }
        public CuisineDTO Get(int id)
        {
            var parameter = new
            {
                Id = id
            };
            return sqlDataAccess.Load<CuisineDTO>(GetDefaultStoredProcedureName(), parameter).FirstOrDefault();
        }
        public int Create(CuisineDTO category)
        {
            return sqlDataAccess.Save(GetDefaultStoredProcedureName(), category);
        }
        public int Update(CuisineDTO category)
        {
            return sqlDataAccess.Save(GetDefaultStoredProcedureName(), category);
        }
        public int Delete(int id)
        {
            var parameter = new
            {
                Id = id
            };
            //sqlDataAccess.DeleteData("RecipesCuisines_DeleteByCuisines", parameter);
            return sqlDataAccess.Delete(GetDefaultStoredProcedureName(), parameter);
        }
    }
}
