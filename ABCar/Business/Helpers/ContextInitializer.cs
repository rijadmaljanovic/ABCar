using Microsoft.AspNetCore.Http;

namespace ABCar.Business.Helpers
{
    internal static class ContextInitializer
    {
        internal static HttpContext GetHttpContext() => new HttpContextAccessor().HttpContext;
    }
}
