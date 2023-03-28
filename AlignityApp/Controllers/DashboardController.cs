using AlignityApp.Models;
using AlignityApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AlignityApp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index(int id)
        {
            using(Dal dal = new Dal())
            {
                DashboardViewModel dvm = new DashboardViewModel()
                {
                    User = dal.GetUser(id)
                };
                return View(dvm);
            }
        }
    }
}
