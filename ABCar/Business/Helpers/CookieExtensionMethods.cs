using System;
using Microsoft.AspNetCore.Http;

namespace ABCar.Business.Helpers
{
    internal static class CookieExtensionMethods
    {
        private static readonly string Key = "ABCar_KEY";

        internal static void SetToCookie(this HttpContext httpContext, string GUID)
        {
            httpContext.Response.Cookies.Append(Key, GUID, new CookieOptions { Expires = DateTime.Now.AddMinutes(10) });

        }

        internal static string  GetFromCookie(this HttpContext httpContext)
        {
            if (httpContext == null)
                return null;

            return  httpContext.Request.Cookies[Key]?.ToString();

        }

        internal static void ClearCookie(this HttpContext httpContext)
        {
            httpContext.Response.Cookies.Delete(Key);

        }

    }
}
