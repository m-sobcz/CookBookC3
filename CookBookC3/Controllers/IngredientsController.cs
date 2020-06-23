using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBookC3.Models;
using DataLibrary.DataAccess;
using DataLibrary.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookBookC3.Controllers
{
    public class IngredientsController : Controller
    {
        private IIngredientProcessor ingredientProcessor;
        public int IngredientsPerPage { get; set; } = 3;
        public IngredientsController(IIngredientProcessor ingredientProcessor)
        {
            this.ingredientProcessor = ingredientProcessor;
        }

        public ActionResult Index(int currentPage = 1)
        {
            List<Ingredient> Ingredients = new List<Ingredient>();
            var data = ingredientProcessor.LoadIngredients();
            foreach (var row in data)
            {
                Ingredients.Add(new Ingredient
                {
                    Name = row.Name,
                    Description=row.Description,
                    Unit=row.Unit
                });
            }

            IngredientsListWithPaginationInfo ingredientsList = new IngredientsListWithPaginationInfo()
            {
                Ingredients = Ingredients.Skip((currentPage - 1) * IngredientsPerPage).Take(IngredientsPerPage),
                PaginationInfo = new PaginationInfo()
                {
                    Current = currentPage,
                    ItemsPerPage = IngredientsPerPage,
                    ItemsCount = Ingredients.Count()

                }
            };
            return View(ingredientsList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                ingredientProcessor.CreateIngredient(ingredient.Name,
                                                                          ingredient.Description);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
    }
}
