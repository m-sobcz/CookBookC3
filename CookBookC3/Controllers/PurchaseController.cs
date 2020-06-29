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

        public ActionResult Add(string ingredientName)
        {
            IngredientUIO Ingredient = GetIngredientByName(ingredientName);
            if (Ingredient != null)
            {
                Purchase purchase = sessionManager.GetItem();
                purchase.AddItem(Ingredient, 1);
                sessionManager.SetItem(purchase);
            }
            return RedirectToAction(nameof(Index));
        }
        IngredientUIO GetIngredientByName(string ingredientName)
        {
            var x=ingredientProcessor.LoadIngredients(IngredientColumn.Name, ingredientName);
            return ingredientProcessor.LoadIngredients().FirstOrDefault(p => p.Name == ingredientName).DTOToUIO();
        }

        public RedirectToActionResult Remove(string ingredientName)
        {
            IngredientUIO Ingredient = GetIngredientByName(ingredientName);

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
