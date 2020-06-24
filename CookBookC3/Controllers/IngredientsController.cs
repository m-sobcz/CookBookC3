using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CookBookC3.Extensions;
using CookBookC3.Models;
using DataLibrary.DataAccess;
using DataLibrary.Logic;
using DataLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace CookBookC3.Controllers
{

    public class IngredientsController : Controller
    {
        private IMapper mapper;
        private IIngredientProcessor ingredientProcessor;
        public int IngredientsPerPage { get; set; } = 6;
        public IngredientsController(IIngredientProcessor ingredientProcessor, IMapper mapper)
        {
            this.mapper = mapper;
            this.ingredientProcessor = ingredientProcessor;
        }
        public ActionResult Index(int id = 1, string category="")
        {
            List<IngredientModelUI> Ingredients = GetAllIngredients();
            List<IngredientModelUI> FilteredIngredients = FilterByCategory(Ingredients,category);
            IngredientsList ingredientsList = new IngredientsList()
            {
                Ingredients = FilteredIngredients.Skip((id - 1) * IngredientsPerPage).Take(IngredientsPerPage),
                PaginationInfo = new PaginationInfo()
                {
                    Current = id,
                    ItemsPerPage = IngredientsPerPage,
                    ItemsCount = FilteredIngredients.Count()
                },
                Categories=GetCategories(Ingredients)
            };
            ViewBag.SelectedCategory = category;
            return View(ingredientsList);
        }
        IEnumerable<string> GetCategories(List<IngredientModelUI> ingredients) 
        { 
            var x= ingredients.Select(x => x.Category)
                .Where(x => x != null)
                .StringReplace(" ", "")
                .Distinct();
            var y = ingredients.Select(x => x.Category);
            return x;
        }
        List<IngredientModelUI> GetAllIngredients() 
        {
            List<IngredientModelUI> Ingredients = new List<IngredientModelUI>();
            var data = ingredientProcessor.LoadIngredients();
            foreach (var row in data)
            {
                Ingredients.Add(new IngredientModelUI
                {
                    Name = row.Name,
                    Description = row.Description,
                    Unit = row.Unit,
                    Callories = row.Callories,
                    CostPerUnit = row.CostPerUnit,
                    Category=row.Category
                });
            }
            return Ingredients;
        }
        List<IngredientModelUI> FilterByCategory(List<IngredientModelUI> data, string category)
        {
            var dataFiltered = data.Where(x => category == "" || (x.Category?.Contains(category) ?? false)).ToList();
            return dataFiltered;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(IngredientModelUI ingredient)
        {
            if (ModelState.IsValid)
            {
                ingredientProcessor.CreateIngredient(mapper.Map<IngredientModelDTO>(ingredient));
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
    }
}
