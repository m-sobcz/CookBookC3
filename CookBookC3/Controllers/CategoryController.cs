using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CookBookASP.Converters;
using CookBookASP.Models;
using CookBookBLL.Logic;
using CookBookBLL.Models;
using Microsoft.AspNetCore.Mvc;
using static CookBookASP.Converters.ModelConverter;


namespace CookBookASP.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMapper mapper;
        private readonly CategoryProcessor categoryProcessor;

        public CategoryController(CategoryProcessor categoryProcessor, IMapper mapper)
        {
            this.mapper = mapper;
            this.categoryProcessor = categoryProcessor;
        }
        public ActionResult Index()
        {
            List<CategoryUIO> model = categoryProcessor.GetAll().DTOToUIOList(MapCategory);
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
            CategoryUIO model = categoryProcessor.Get(id).DTOToUIO(MapCategory);
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
