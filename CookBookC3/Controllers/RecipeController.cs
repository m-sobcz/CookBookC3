using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CookBookASP.Converters;
using CookBookASP.Models;
using CookBookASP.Session;
using CookBookBLL.Logic;
using CookBookBLL.Models;
using Microsoft.AspNetCore.Mvc;
using static CookBookASP.Converters.ModelConverter;

namespace CookBookASP.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IMapper mapper;
        private readonly RecipeProcessor recipeProcessor;
        private readonly CuisineProcessor cuisineProcessor;
        private readonly SessionManager<ItemInfo> sessionManager;

        public int RecipesPerPage { get; set; } = 6;
        public RecipeController(RecipeProcessor recipeProcessor, CuisineProcessor cuisineProcessor, IMapper mapper,
            SessionManager<ItemInfo> sessionManager)
        {
            this.mapper = mapper;
            this.recipeProcessor = recipeProcessor;
            this.cuisineProcessor = cuisineProcessor;
            this.sessionManager = sessionManager;
        }
        public ActionResult Index(int id = 1, string cuisine = null)
        {
            List<RecipeWithCuisines> loadedRecipes = recipeProcessor.GetAllInCuisine((id - 1) * RecipesPerPage, RecipesPerPage, cuisine);
            List<CuisineUIO> cuisines = cuisineProcessor.GetAll().DTOToUIOList(MapCuisine);
            int recipeCount = loadedRecipes.Count();
            RecipeViewModel recipesList = new RecipeViewModel()
            {
                Recipes = loadedRecipes,
                PaginationInfo = new PaginationInfo()
                {
                    Current = id,
                    ItemsPerPage = RecipesPerPage,
                    ItemsCount = recipeCount
                },
                Cuisines = cuisines,
                SelectedCuisineName = cuisine
            };
            return View(recipesList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(RecipeUIO recipe)
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
        public ActionResult Edit(RecipeUIO recipe)
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
            RecipeUIO model = recipeProcessor.Get(id).DTOToUIO(MapRecipe);
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
            List<CuisineUIO> model = recipeProcessor.GetCuisines(id).DTOToUIOList(MapCuisine);
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
        public ActionResult Ingredients(int recipeId, int id=1, string category=null)
        {
            ViewBag.id = id;
            ViewBag.category = category;
            List<IngredientUIO> model = recipeProcessor.GetIngredients(recipeId).DTOToUIOList(MapIngredient);
            return View(model);
        }
        public ActionResult AddIngredient(int recipeId, int ingredientId)
        {
            recipeProcessor.AddIngredient(recipeId, ingredientId);
            return RedirectToAction(nameof(Ingredients), new { recipeId });
        }
        public ActionResult RemoveIngredient(int recipeId, int ingredientId)
        {
            recipeProcessor.RemoveIngredient(recipeId, ingredientId);
            return RedirectToAction(nameof(Ingredients), new { recipeId });
        }
        public ActionResult EditIngredientCount(int recipeId, int ingredientId,int count)
        {
            recipeProcessor.EditIngredientCount(recipeId, ingredientId, count);
            return RedirectToAction(nameof(Ingredients), new { recipeId });
        }

    }
}
