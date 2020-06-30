using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBookC3.Converters;
using CookBookC3.Extensions;
using CookBookC3.Models;
using CookBookC3.Session;
using DataLibrary.Enums;
using DataLibrary.Logic;
using Microsoft.AspNetCore.Mvc;

namespace CookBookC3.Controllers
{
    public class PurchaseController : Controller
    {
        private SessionManager<Purchase> sessionManager;
        private IIngredientProcessor ingredientProcessor;

        public PurchaseController(IIngredientProcessor ingredientProcessor, SessionManager<Purchase> sessionManager)
        {
            this.sessionManager = sessionManager;
            this.ingredientProcessor = ingredientProcessor;
        }

        public ViewResult Index()
        {
            return View(sessionManager.GetItem());
        }

        public ActionResult Add(int id)
        {    
            IngredientUIO Ingredient = ingredientProcessor.Load(id).DTOToUIO();
            if (Ingredient != null)
            {
                Purchase purchase = sessionManager.GetItem();
                purchase.AddItem(Ingredient, 1);
                sessionManager.SetItem(purchase);
            }
            return RedirectToAction(nameof(Index));
        }

        public RedirectToActionResult Remove(int id)
        {
            IngredientUIO Ingredient = ingredientProcessor.Load(id).DTOToUIO();

            if (Ingredient != null)
            {
                Purchase purchase = sessionManager.GetItem();
                purchase.RemovePosition(Ingredient);
                sessionManager.SetItem(purchase);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
