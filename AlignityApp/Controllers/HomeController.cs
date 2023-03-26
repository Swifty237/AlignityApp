using AlignityApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AlignityApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int id)
        {
            using (Dal dal = new Dal())
            {
                Models.User user = dal.GetUser(id);
                return View(user);
            }
        }

        public IActionResult ListUsers()
        {
            using (Dal dal = new Dal())
            {
                List<Models.User> users = dal.GetAllUsers();
               
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
        public IActionResult CreateUser(Models.User userCreated)
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

        public IActionResult Holiday()
        {
            return View();
        }

        public IActionResult ListCras()
        {
            return View();
        }

        public IActionResult ListHolidays()
        {
            return View();
        }

        public IActionResult ListRtt()
        {
            return View();
        }

        public IActionResult Rtt()
        {
            return View();
        }

        public IActionResult Absence()
        {
            return View();
        }

        public IActionResult Training()
        {
            return View();
        }

        public IActionResult Service()
        {
            return View();
        }
    }
}
