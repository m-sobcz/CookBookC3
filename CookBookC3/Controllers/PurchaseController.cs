using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBookC3.Converters;
using CookBookC3.Extensions;
using CookBookC3.Models;
using DataLibrary.Enums;
using DataLibrary.Logic;
using Microsoft.AspNetCore.Mvc;

namespace CookBookC3.Controllers
{
    public class PurchaseController : Controller
    {
        private IIngredientProcessor ingredientProcessor;

        public PurchaseController(IIngredientProcessor ingredientProcessor)
        {
            this.ingredientProcessor = ingredientProcessor;
        }

        public ViewResult Index()
        {
            return View(GetPurchase());
        }

        public ActionResult Add(string ingredientName)
        {
            IngredientModelUI Ingredient = GetIngredientByName(ingredientName);
            if (Ingredient != null)
            {
                Purchase purchase = GetPurchase();
                purchase.AddItem(Ingredient, 1);
                SavePurchase(purchase);
            }
            return RedirectToAction(nameof(Index));
        }
        IngredientModelUI GetIngredientByName(string ingredientName)
        {
            //return ingredientProcessor.LoadIngredients().FirstOrDefault(p => p.Name == ingredientName).DTOToUI();
            var x=ingredientProcessor.LoadIngredients(IngredientColumn.Name, ingredientName);
            return ingredientProcessor.LoadIngredients().FirstOrDefault(p => p.Name == ingredientName).DTOToUI();
        }

        public RedirectToActionResult Remove(string ingredientName)
        {
            IngredientModelUI Ingredient = GetIngredientByName(ingredientName);

            if (Ingredient != null)
            {
                Purchase purchase = GetPurchase();
                purchase.RemovePosition(Ingredient);
                SavePurchase(purchase);
            }
            return RedirectToAction(nameof(Index));
        }
        //Wykorzystanie mechanizmu sesji - przechowywanie i pobieranie obiektów
        public Purchase GetPurchase()
        {
            Purchase purchase = HttpContext.Session.GetJson<Purchase>(nameof(Purchase)) ?? new Purchase();
            return purchase;
        }

        public void SavePurchase(Purchase purchase)
        {
            HttpContext.Session.SetJson(nameof(Purchase), purchase);
        }
    }
}
