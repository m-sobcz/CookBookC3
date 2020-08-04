using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CookBookASP.Converters;
using CookBookASP.Models;
using CookBookASP.Session;
using CookBookASP.ViewModels;
using CookBookBLL.Logic;
using CookBookBLL.Models;
using Microsoft.AspNetCore.Mvc;
using static CookBookASP.Converters.ModelConverter;

namespace CookBookASP.Controllers
{

    public class IngredientController :  ControllerBase<IngredientController>
    {
        private readonly IMapper mapper;
        private readonly IngredientProcessor ingredientProcessor;
        private readonly CategoryProcessor categoryProcessor;
        private readonly SessionManager<ItemInfo> sessionManager;
        private readonly CompoundModelBuilder compoundModelBuilder;

        public int IngredientsPerPage { get; set; } = 6;
        public IngredientController(IngredientProcessor ingredientProcessor, CategoryProcessor categoryProcessor, 
            IMapper mapper, SessionManager<ItemInfo> sessionManager, CompoundModelBuilder compoundModelBuilder)
        {
            this.mapper = mapper;
            this.ingredientProcessor = ingredientProcessor;
            this.categoryProcessor = categoryProcessor;
            this.sessionManager = sessionManager;
            this.compoundModelBuilder = compoundModelBuilder;
        }
        public ActionResult Index(int pageId = 1, string category=null)
        {
            var ingredientsList = compoundModelBuilder.GetFullIngredientVM(pageId,category,IngredientsPerPage);
            return View(ingredientsList);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(IngredientVM ingredient)
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
        public ActionResult Edit(IngredientVM ingredient)
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
            IngredientVM model=ingredientProcessor.Get(id).DTOToViewModel(MapIngredient);
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
            List<CategoryVM> model = ingredientProcessor.GetCategories(id).DTOToViewModelList(MapCategory);
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
