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
            var loadedIngredients = ingredientProcessor.LoadIngredientsWithCategories(id - 1, IngredientsPerPage);
            IngredientsList ingredientsList = new IngredientsList()
            {
                Ingredients = loadedIngredients,
                PaginationInfo = new PaginationInfo()
                {
                    Current = id,
                    ItemsPerPage = IngredientsPerPage,
                    ItemsCount = 20//!!
                },
                Categories= ingredientProcessor.LoadCategories().DTOToUIOList()
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
                ingredientProcessor.CreateIngredient(mapper.Map<IngredientDTO>(ingredient));
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
    }
}
