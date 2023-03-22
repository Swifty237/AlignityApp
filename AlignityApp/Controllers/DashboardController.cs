using Microsoft.AspNetCore.Mvc;

namespace AlignityApp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
