using CookBookC3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookC3.Components
{
    public class ShoppingCountViewComponent : ViewComponent
    {
        private Purchase shoppingList;

        public ShoppingCountViewComponent(Purchase shoppingList)
        {
            this.shoppingList = shoppingList;
        }

        public IViewComponentResult Invoke()
        {
            return View(shoppingList);
        }
    }
}
