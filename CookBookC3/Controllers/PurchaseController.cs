using CookBookASP.Converters;
using CookBookASP.Models;
using CookBookASP.Session;
using CookBookBLL.Logic;
using Microsoft.AspNetCore.Mvc;
using static CookBookASP.Converters.ModelConverter;


namespace CookBookASP.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly SessionManager<Purchase> sessionManager;
        private readonly IngredientProcessor ingredientProcessor;

        public PurchaseController(IngredientProcessor ingredientProcessor, SessionManager<Purchase> sessionManager)
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
            IngredientUIO Ingredient = ingredientProcessor.Get(id).DTOToUIO(MapIngredient);
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
            IngredientUIO Ingredient = ingredientProcessor.Get(id).DTOToUIO(MapIngredient);

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
