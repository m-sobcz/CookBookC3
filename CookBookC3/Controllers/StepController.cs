using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class StepController : Controller
    {
        private readonly SessionManager<ItemInfo> sessionManager;
        private readonly IMapper mapper;
        private readonly StepProcessor stepProcessor;

        public StepController(StepProcessor stepProcessor, IMapper mapper, SessionManager<ItemInfo> sessionManager)
        {
            this.sessionManager = sessionManager;
            this.mapper = mapper;
            this.stepProcessor = stepProcessor;
        }
        public ActionResult Get(int id)
        {
            List<StepUIO> model = stepProcessor.Get(id).DTOToUIOList(MapStep);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            stepProcessor.Delete(id);
            return RedirectToAction(nameof(Get), new { id });
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(StepUIO model)
        {
            if (ModelState.IsValid)
            {
                int id = stepProcessor.Create(mapper.Map<StepDTO>(model));
                return RedirectToAction(nameof(Get), new { id });
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Update(StepUIO model)
        {
            if (ModelState.IsValid)
            {
                stepProcessor.Update(mapper.Map<StepDTO>(model));
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }
    }
}
