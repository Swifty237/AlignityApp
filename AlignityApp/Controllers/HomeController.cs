using AlignityApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;

namespace AlignityApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListUsers()
        {
            using (Dal dal = new Dal())
            {
                List<User> users = dal.GetAllUsers();
                if (users == null)
                {
                    return View("Error");
                }
                return View(users);
            }
            
        }

        public IActionResult CreateUser()
        {
                return View();
            
        }

        [HttpPost]
        public IActionResult CreateUser(User userCreated)
        {
            using (Dal dal = new Dal())
            {
                dal.CreateUser(
                    userCreated.Name, 
                    userCreated.Firstname, 
                    userCreated.Birthdate, 
                    userCreated.Email, 
                    userCreated.Password, 
                    userCreated.UserRole
                    );
                return RedirectToAction("ListUsers");
            }
        }
    }
}
