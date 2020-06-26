using DataLibrary.DataAccess;
using DataLibrary.Logic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panel
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            SqlDataAccess sqlDataAccess = new SqlDataAccess()
            IngredientProcessor ingredientProcessor = new IngredientProcessor(sqlDataAccess);

        }

        private static void BasicRead()
        {
            using (IDbConnection cnn = new SqlConnection(connectionString)
            {
                string sql = "select * from dbo.Person";
                var people = cnn.Query<PersonModel>(sql);

                foreach (var person in people)
                {
                    Console.WriteLine($"{ person.FirstName } { person.LastName }");
                }
            }
        }

    }
}
