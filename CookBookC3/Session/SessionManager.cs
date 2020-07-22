using CookBookASP.Extensions;
using CookBookASP.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookASP.Session
{
    public class SessionManager<T> where T : new()
    {
        public ISession Session { get; set; }
        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            this.Session = httpContextAccessor.HttpContext.Session;
        }
        //Wykorzystanie mechanizmu sesji - przechowywanie i pobieranie obiektów
        public T GetItem()
        {
            T item = Session.GetJson<T>(nameof(T)) ?? new T();
            return item;
        }
        public void SetItem(T item)
        {
            Session.SetJson(nameof(T), item);
        }

    }
}
