using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CookBookASP.Converters;
using CookBookASP.Models;
using CookBookASP.Session;
using CookBookASP.ViewModels;
using CookBookBLL.Logic;
using CookBookBLL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static CookBookASP.Converters.ModelConverter;


namespace CookBookASP.Controllers
{
    public class CategoryController : ControllerBase<CategoryController>
    {
        private readonly SessionManager<ItemInfo> sessionManager;
        private readonly IMapper mapper;
        private readonly CategoryProcessor categoryProcessor;

        public CategoryController(CategoryProcessor categoryProcessor, IMapper mapper, SessionManager<ItemInfo> sessionManager)
        {
            this.sessionManager = sessionManager;
            this.mapper = mapper;
            this.categoryProcessor = categoryProcessor;
        }
        public ActionResult Index()
        {
            List<CategoryVM> model = categoryProcessor.GetAll().DTOToViewModelList(MapCategory);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CategoryVM category)
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
        public ActionResult Edit(CategoryVM category)
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
            CategoryVM model = categoryProcessor.Get(id).DTOToViewModel(MapCategory);
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
