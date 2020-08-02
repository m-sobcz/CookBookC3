using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CookBookASP.Extensions
{
    public static class ASPNames
    {
        public static string Add => "Add";
        public static string Index => "Index";
        public static string Edit => "Edit";
        public static string Create => "Create";
        public static string Update => "Update";
        public static string Delete => "Delete";
        public static string Categories => "Categories";
        public static string Cuisines => "Cuisines";
        public static string Ingredients => "Ingredients";
        public static string AddCategory => "AddCategory";
        public static string RemoveCategory => "RemoveCategory";
        public static string AddCuisine => "AddCuisine";
        public static string RemoveCuisine => "RemoveCuisine";
        public static string RemoveAll => "RemoveAll";
        public static string AddIngredient => "AddIngredient";
        public static string RemoveIngredient => "RemoveIngredient";
        public static string AddRecipe => "AddRecipe";
        public static string Steps => "Steps";
        public static string EditIngredientCount => "EditIngredientCount";
        public static string GetASPName(this string originalName)
        {
            string result = Regex.Replace(originalName, @"ViewComponent|Controller", String.Empty);
            return result;
        }
    }
}
