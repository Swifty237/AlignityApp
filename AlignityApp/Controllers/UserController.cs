using AlignityApp.Models;
using AlignityApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AlignityApp.Controllers
{
    public class UserController : Controller
    {
        UserViewModel userVM = new UserViewModel();
        public IActionResult Index(int id)
        {
            return View();
        }

        public IActionResult AjouterUser()
        {
            using (Dal dal = new Dal())
            {
                userVM.listUsers = dal.GetAllManager();
            }


            return View(userVM);
        }

        [HttpPost]
        public IActionResult AjouterUser(User user)
        {
            user.CreationDate = DateTime.Now;
            using (Dal dal = new Dal())
            {
                userVM.listUsers = dal.GetAllManager();
                dal.CreateUser(user);
            }


            return View(userVM);
        }
    }

}
