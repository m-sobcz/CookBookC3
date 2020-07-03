using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CookBookC3.Converters;
using CookBookC3.Models;
using DataLibrary.Logic;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace CookBookC3.Controllers
{
    public class CategoryController : Controller
    {
        private IMapper mapper;
        private CategoryProcessor categoryProcessor;

        public CategoryController(CategoryProcessor categoryProcessor, IMapper mapper)
        {
            this.mapper = mapper;
            this.categoryProcessor = categoryProcessor;
        }
        public ActionResult Index()
        {
            var model = categoryProcessor.GetAll().DTOToUIOList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CategoryUIO category)
        {
            if (ModelState.IsValid)
            {
                categoryProcessor.Create(mapper.Map<CategoryDTO>(category));
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Edit(CategoryUIO category)
        {
            if (ModelState.IsValid)
            {
                categoryProcessor.Update(mapper.Map<CategoryDTO>(category));
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(category);
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = categoryProcessor.Get(id).DTOToUIO();
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            categoryProcessor.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
