using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBookC3.Converters;
using CookBookC3.Extensions;
using CookBookC3.Models;
using DataLibrary.Logic;
using Microsoft.AspNetCore.Mvc;

namespace CookBookC3.Controllers
{
    public class ShoppingController : Controller
    {
        private IIngredientProcessor ingredientProcessor;

        public ShoppingController(IIngredientProcessor ingredientProcessor)
        {
            this.ingredientProcessor = ingredientProcessor;
        }

        public ViewResult Index()
        {
            return View(GetShoppingList());
        }

        public ActionResult Add(string ingredientName)
        {
            IngredientModelUI Ingredient = GetIngredientByName(ingredientName);
            if (Ingredient != null)
            {
                ShoppingList cart = GetShoppingList();
                cart.AddItem(Ingredient, 1);
                SaveShoppingList(cart);
            }
            return RedirectToAction(nameof(Index));
        }
        IngredientModelUI GetIngredientByName(string ingredientName) 
        {
            return ingredientProcessor.LoadIngredients().FirstOrDefault(p => p.Name == ingredientName).DTOToUI();
        }

        public RedirectToActionResult Remove(string ingredientName)
        {
            IngredientModelUI Ingredient = GetIngredientByName(ingredientName);

            if (Ingredient != null)
            {
                ShoppingList cart = GetShoppingList();
                cart.RemovePosition(Ingredient);
                SaveShoppingList(cart);
            }
            return RedirectToAction("Index");
        }
        //Wykorzystanie mechanizmu sesji - przechowywanie i pobieranie obiektów
        private ShoppingList GetShoppingList()
        {
            ShoppingList shoppingList = HttpContext.Session.GetJson<ShoppingList>(nameof(ShoppingList)) ?? new ShoppingList();
            return shoppingList;
        }

        private void SaveShoppingList(ShoppingList shoppingList)
        {
            HttpContext.Session.SetJson(nameof(ShoppingList), shoppingList);
        }
    }
}
