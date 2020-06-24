using CookBookC3.Extensions;
using CookBookC3.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookC3.Session
{
    public class SessionManager
    {
        public ISession Session { get; set; }
        public SessionManager(ISession session)
        {
            this.Session = session;
        }
        //Wykorzystanie mechanizmu sesji - przechowywanie i pobieranie obiektów
        public Purchase GetPurchase()
        {
            Purchase purchase = Session.GetJson<Purchase>(nameof(Purchase)) ?? new Purchase();
            return purchase;
        }

        public void SavePurchase(Purchase purchase)
        {
            Session.SetJson(nameof(Purchase), purchase);
        }
    }
}
