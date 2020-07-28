using CookBookBLL.DataAccess;
using CookBookBLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBookBLL.Logic
{
    public class StepProcessor : Processor
    {
        private SqlDataAccess sqlDataAccess;

        public StepProcessor(SqlDataAccess sqlDataAccess)
        {
            this.sqlDataAccess = sqlDataAccess;
            defaultStoredProceduresPrefix = "Steps";
        }

        public List<StepDTO> Get(int recipeID)
        {
            var parameter = new
            {
                Id = recipeID
            };
            return sqlDataAccess.LoadData<StepDTO>(GetDefaultStoredProcedureName(), parameter);
        }
        public int Delete(int stepId)
        {
            var parameter = new
            {
                Id = stepId
            };
            return sqlDataAccess.DeleteData(GetDefaultStoredProcedureName(), parameter);
        }
        public int Create(StepDTO stepModel)
        {
            return sqlDataAccess.SaveData(GetDefaultStoredProcedureName(), stepModel);
        }
        public int Update(StepDTO stepModel)
        {
            return sqlDataAccess.SaveData(GetDefaultStoredProcedureName(), stepModel);
        }
    }
}
