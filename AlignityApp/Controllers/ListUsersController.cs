using AlignityApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AlignityApp.Controllers
{
    public class ListUsersController : Controller
    {
        public IActionResult Index(int id)
        {
            using (Dal dal = new Dal())
            {
                if (id == 0)
                {
                    List<User> list = dal.GetAllUsers();
                    return View(list);

                }
                else
                {
                    List<User> list = dal.GetUsersByManagerId(id);
                    return View(list);
                }
            }
        }
    }
}
