using System;
using ABCar.Models.EntityModels;
using ABCar.Models.EntityModels.Korisnici;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ABCar.Business.Helpers
{
    internal static class SessionExtensionMethods
    {
        private static readonly string Key="ABCar_KEY";

        internal static void SetInSession(this HttpContext httpContext, KorisnickiRacun accForSession)
        {

            if (accForSession == null)
                return;

            var stringForSession = JsonConvert.SerializeObject(accForSession);

            httpContext.Session.SetString(Key, stringForSession);

        }
        
        internal static KorisnickiRacun GetFromSession(this HttpContext httpContext)
        {
            if (httpContext == null)
                return null;

            var stringFromSession = httpContext.Session.GetString(Key);

            return String.IsNullOrEmpty(stringFromSession) ? null : JsonConvert.DeserializeObject<KorisnickiRacun>(stringFromSession);
        }
        
        internal static void ClearSession(this HttpContext httpContext)
        {
            httpContext.Session.Clear();
        }
    }
}
