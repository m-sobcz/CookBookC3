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

    public class IngredientController : Controller
    {
        private readonly IMapper mapper;
        private readonly IngredientProcessor ingredientProcessor;
        private readonly CategoryProcessor categoryProcessor;
        private readonly SessionManager<ItemInfo> sessionManager;

        public int IngredientsPerPage { get; set; } = 6;
        public IngredientController(IngredientProcessor ingredientProcessor, CategoryProcessor categoryProcessor, 
            IMapper mapper, SessionManager<ItemInfo> sessionManager)
        {
            this.mapper = mapper;
            this.ingredientProcessor = ingredientProcessor;
            this.categoryProcessor = categoryProcessor;
            this.sessionManager = sessionManager;
        }
        public ActionResult Index(int id = 1, string category=null)
        {
            List<IngredientWithCategories> loadedIngredients = ingredientProcessor.GetAllInCategory((id-1)*IngredientsPerPage, IngredientsPerPage,category);
            List<CategoryUIO> Categories = categoryProcessor.GetAll().DTOToUIOList(MapCategory);
            int ingredientCount = loadedIngredients.Count();
            IngredientsList ingredientsList = new IngredientsList()
            {
                Ingredients = loadedIngredients,
                PaginationInfo = new PaginationInfo()
                {
                    Current = id,
                    ItemsPerPage = IngredientsPerPage,
                    ItemsCount = ingredientCount
                },
                Categories= Categories,
                SelectedCategoryName= category
            };          
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
                int id=ingredientProcessor.Create(mapper.Map<IngredientDTO>(ingredient));
                sessionManager.SetItem(new ItemInfo() { Name = ingredient.Name });
                return RedirectToAction(nameof(Categories),new { id });
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
            IngredientUIO model=ingredientProcessor.Get(id).DTOToUIO(MapIngredient);
            sessionManager.SetItem(new ItemInfo() { Name = model.Name });
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
            List<CategoryUIO> model = ingredientProcessor.GetCategories(id).DTOToUIOList(MapCategory);
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
