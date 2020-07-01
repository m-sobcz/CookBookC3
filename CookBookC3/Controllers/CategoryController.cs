using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CookBookC3.Converters;
using DataLibrary.Logic;
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
            var model = categoryProcessor.LoadCategories().DTOToUIOList();
            return View(model);
        }
    }
}
