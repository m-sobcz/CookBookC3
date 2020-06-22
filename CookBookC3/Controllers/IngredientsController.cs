using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBookC3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookBookC3.Controllers
{
    public class IngredientsController : Controller
    {
        private IIngredientRepository ingredientRepository;
        public int IngredientsPerPage { get; set; } = 3;

        public IngredientsController(IIngredientRepository ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository;
        }
        public ActionResult List(int currentPage = 1)
        {
            IngredientsList ingredientsList = new IngredientsList()
            {
                Ingredients = ingredientRepository.Ingredients.Skip((currentPage - 1) * IngredientsPerPage).Take(IngredientsPerPage),
                PageInfo = new PageInfo()
                {
                    Current = currentPage,
                    ItemsPerPage = IngredientsPerPage,
                    ItemsCount = ingredientRepository.Ingredients.Count()

                }
            };
            return View(ingredientsList);
        }

        // GET: IngredientsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: IngredientsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IngredientsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IngredientsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IngredientsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IngredientsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IngredientsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IngredientsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
