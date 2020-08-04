using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CookBookASP.Converters;
using CookBookASP.Models;
using CookBookASP.ViewModels;
using CookBookBLL.Logic;
using CookBookBLL.Models;
using Microsoft.AspNetCore.Mvc;
using static CookBookASP.Converters.ModelConverter;

namespace CookBookASP.Controllers
{
    public class CuisineController : ControllerBase<CuisineController>
    {
        private readonly IMapper mapper;
        private readonly CuisineProcessor cuisineProcessor;

        public CuisineController(CuisineProcessor cuisineProcessor, IMapper mapper)
        {
            this.mapper = mapper;
            this.cuisineProcessor = cuisineProcessor;
        }
        public ActionResult Index()
        {
            List<CuisineVM> model = cuisineProcessor.GetAll().DTOToViewModelList(MapCuisine);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CuisineVM cuisine)
        {
            if (ModelState.IsValid)
            {
                cuisineProcessor.Create(mapper.Map<CuisineDTO>(cuisine));
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Edit(CuisineVM category)
        {
            if (ModelState.IsValid)
            {
                cuisineProcessor.Update(mapper.Map<CuisineDTO>(category));
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
            CuisineVM model = cuisineProcessor.Get(id).DTOToViewModel(MapCuisine);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            cuisineProcessor.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
