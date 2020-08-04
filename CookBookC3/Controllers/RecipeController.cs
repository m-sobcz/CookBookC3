using AutoMapper;
using CookBookASP.Converters;
using CookBookASP.Models;
using CookBookASP.Session;
using CookBookASP.ViewModels;
using CookBookBLL.Logic;
using CookBookBLL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static CookBookASP.Converters.ModelConverter;

namespace CookBookASP.Controllers
{
    public class RecipeController : ControllerBase<RecipeController>
    {
        private readonly CompoundModelBuilder compoundModelBuilder;
        private readonly IMapper mapper;
        private readonly RecipeProcessor recipeProcessor;
        private readonly SessionManager<ItemInfo> sessionManager;

        public int RecipesPerPage { get; set; } = 6;
        public RecipeController(RecipeProcessor recipeProcessor, IMapper mapper,
            SessionManager<ItemInfo> sessionManager, CompoundModelBuilder compoundModelBuilder)
        {
            this.compoundModelBuilder = compoundModelBuilder;
            this.mapper = mapper;
            this.recipeProcessor = recipeProcessor;
            this.sessionManager = sessionManager;
        }
        public ActionResult Index(int pageId = 1, string cuisine = null)
        {
            var model = compoundModelBuilder.GetRecipeIndexVM(pageId, cuisine, RecipesPerPage);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(RecipeVM recipe)
        {
            if (ModelState.IsValid)
            {
                int id = recipeProcessor.Create(mapper.Map<RecipeDTO>(recipe));
                sessionManager.SetItem(new ItemInfo() { Name = recipe.Name });
                return RedirectToAction(nameof(Cuisines), new { id });
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Edit(RecipeVM recipe)
        {
            if (ModelState.IsValid)
            {
                recipeProcessor.Update(mapper.Map<RecipeDTO>(recipe));
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(recipe);
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            RecipeVM model = recipeProcessor.Get(id).DTOToViewModel(MapRecipe);
            sessionManager.SetItem(new ItemInfo() { Name = model.Name });
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            recipeProcessor.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Cuisines(int id)
        {
            List<CuisineVM> model = recipeProcessor.GetCuisines(id).DTOToViewModelList(MapCuisine);
            return View(model);
        }
        public ActionResult RemoveCuisine(int id, int cuisineId)
        {
            recipeProcessor.RemoveCuisine(id, cuisineId);
            return RedirectToAction(nameof(Cuisines), new { id });
        }
        public ActionResult AddCuisine(int id, int cuisineId)
        {
            recipeProcessor.AddCuisine(id, cuisineId);
            return RedirectToAction(nameof(Cuisines), new { id });
        }
        public ActionResult Ingredients(int id, int pageId = 1, string category = null)
        {
            IngredientsPageVM model = new IngredientsPageVM()
            {
                Category = category,
                PageId = pageId,
                RecipeId = id
            };
            model.Ingredients = recipeProcessor.GetIngredientsWithCount(id).DTOToViewModelList(MapIngredientWithCount);
            return View(model);
        }
        public ActionResult AddIngredient(int id, int ingredientId)
        {
            recipeProcessor.AddIngredient(id, ingredientId);
            return RedirectToAction(nameof(Ingredients), new { id });
        }
        public ActionResult RemoveIngredient(int id, int ingredientId)
        {
            recipeProcessor.RemoveIngredient(id, ingredientId);
            return RedirectToAction(nameof(Ingredients), new { id });
        }
        public ActionResult EditIngredientCount(int id, int ingredientId, decimal count)
        {
            recipeProcessor.EditIngredientCount(id, ingredientId, count);
            return RedirectToAction(nameof(Ingredients), new { id });
        }
        public ActionResult Details(int id)
        {
            var model = recipeProcessor.GetFull(id).DTOToViewModel(MapFullRecipe);
            return View(model);
        }

    }
}
