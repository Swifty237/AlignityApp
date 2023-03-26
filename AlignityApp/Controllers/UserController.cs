using Microsoft.AspNetCore.Mvc;

namespace AlignityApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index(int id)
        {
            return View();
        }
    }
}
