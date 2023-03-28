﻿using AlignityApp.Models;
using AlignityApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
                HomeViewModel hvm = new HomeViewModel()
                {
                    User = dal.GetUser(id)
                };
                return View(hvm);
            }
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
