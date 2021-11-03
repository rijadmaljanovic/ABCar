using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABCar.Business.Helpers;
using ABCar.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ABCar.WebApp.ViewComponents
{
    public class UserNotificationComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new NotificationRepository().GetNumberOfNewNotifications(SessionCookieHelper.GetLoggedKupac().Id);

            return View(model);
        }

    }
}
