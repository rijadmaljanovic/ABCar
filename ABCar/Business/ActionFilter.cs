using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ABCar.Business.Helpers;
using ABCar.DAL;
using ABCar.Models.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace ABCar.Business
{
    public class ActionFilter : TypeFilterAttribute
    {
        public ActionFilter(bool admin = false, bool kupac = false, bool zaposlenik = false) : base(typeof(MyImplementation))
        {
            Arguments = new object[] { admin, kupac, zaposlenik };
        }
    }

    public class MyImplementation : IActionFilter
    {
        private readonly bool admin;
        private readonly bool kupac;
        private readonly bool zaposlenik;

        public MyImplementation(bool a, bool k, bool p)
        {
            admin = a;
            kupac = k;
            zaposlenik = p;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (admin && SessionCookieHelper.IsUserLoggedIn(TipKorisnika.Administrator))
                return;
            if (kupac && SessionCookieHelper.IsUserLoggedIn(TipKorisnika.Kupac))
                return;
            if (zaposlenik && SessionCookieHelper.IsUserLoggedIn(TipKorisnika.Zaposlenik))
                return;

            context.Result = new RedirectToActionResult("Index", "Home", new { area = "Login" });
        }

    }
}
