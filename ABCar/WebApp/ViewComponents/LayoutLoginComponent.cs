using System.Threading.Tasks;
using ABCar.Business;
using ABCar.Business.Helpers;
using ABCar.DAL;
using Microsoft.AspNetCore.Mvc;

namespace ABCar.WebApp.ViewComponents
{
    public class LayoutLoginComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // provjera je li user postoji u sesiji
            var accountFromSession = SessionCookieHelper.GetUserFromSession();
        
            return View(accountFromSession);

        }

    }

   

}
