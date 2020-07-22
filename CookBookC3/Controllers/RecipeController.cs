using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CookBookASP.Converters;
using CookBookASP.Models;
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
        public int RecipesPerPage { get; set; } = 6;
        public RecipeController(RecipeProcessor recipeProcessor, CuisineProcessor cuisineProcessor, IMapper mapper)
        {
            this.mapper = mapper;
            this.recipeProcessor = recipeProcessor;
            this.cuisineProcessor = cuisineProcessor;
        }
        public ActionResult Index(int id = 1, string cuisine = null)
        {
            List<RecipeWithCuisines> loadedRecipes = recipeProcessor.GetAllInCuisine((id - 1) * RecipesPerPage, RecipesPerPage, cuisine);
            List<CuisineUIO> cuisines = cuisineProcessor.GetAll().DTOToUIOList(MapCuisine);
            int recipeCount = loadedRecipes.Count();
            RecipesList recipesList = new RecipesList()
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
        public ActionResult Create(RecipeUIO ingredient)
        {
            if (ModelState.IsValid)
            {
                recipeProcessor.Create(mapper.Map<RecipeDTO>(ingredient));
                return RedirectToAction(nameof(Index));
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
    }
}
