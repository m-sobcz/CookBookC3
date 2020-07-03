using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using CookBookC3.Converters;
using CookBookC3.Extensions;
using CookBookC3.Models;
using DataLibrary.DataAccess;
using DataLibrary.Enums;
using DataLibrary.Logic;
using DataLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace CookBookC3.Controllers
{

    public class IngredientController : Controller
    {
        private IMapper mapper;
        private IngredientProcessor ingredientProcessor;
        private CategoryProcessor categoryProcessor;

        public int IngredientsPerPage { get; set; } = 6;
        public IngredientController(IngredientProcessor ingredientProcessor, CategoryProcessor categoryProcessor, IMapper mapper)
        {
            this.mapper = mapper;
            this.ingredientProcessor = ingredientProcessor;
            this.categoryProcessor = categoryProcessor;
        }
        public ActionResult Index(int id = 1, string category=null)
        {
            var loadedIngredients = ingredientProcessor.LoadRowsWithCategories(id - 1, IngredientsPerPage,category);
            var Categories = categoryProcessor.GetAll().DTOToUIOList();
            var ingredientCount = ingredientProcessor.IngredientCount();
            IngredientsList ingredientsList = new IngredientsList()
            {
                Ingredients = loadedIngredients,
                PaginationInfo = new PaginationInfo()
                {
                    Current = id,
                    ItemsPerPage = IngredientsPerPage,
                    ItemsCount = ingredientCount
                },
                Categories= Categories
            };
            ViewBag.SelectedCategory = category;
            return View(ingredientsList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(IngredientUIO ingredient)
        {
            if (ModelState.IsValid)
            {
                ingredientProcessor.Create(mapper.Map<IngredientDTO>(ingredient));
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Edit(IngredientUIO ingredient)
        {
            if (ModelState.IsValid)
            {
                ingredientProcessor.Update(mapper.Map<IngredientDTO>(ingredient));
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(ingredient);
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model=ingredientProcessor.Get(id).DTOToUIO();
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            ingredientProcessor.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Categories(int id)
        {
            var model = ingredientProcessor.LoadCategoriesFor(id).DTOToUIOList();
            return View(model);
        }
        public ActionResult RemoveCategory(int id, int categoryId)
        {
            ingredientProcessor.RemoveCategory(id, categoryId);
            return RedirectToAction(nameof(Categories), new { id });
        }
        public ActionResult AddCategory(int id, int categoryId)
        {
            ingredientProcessor.AddCategory(id, categoryId);
            return RedirectToAction(nameof(Categories), new { id });
        }
    }
}
