﻿using AlignityApp.Models;
using AlignityApp.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace AlignityApp.Controllers
{
    public class LoginController : Controller
    {
        private Dal dal;
        public LoginController()
        {
            dal = new Dal();
        }
        public IActionResult Index()
        {
            UserViewModel viewModel = new UserViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            if (viewModel.Authentifie)
            {
                viewModel.User = dal.GetUser(HttpContext.User.Identity.Name);
                return View(viewModel);
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(UserViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Models.User user = dal.Authentifier(viewModel.User.Email, viewModel.User.Password);
                if (user != null)
                {
                    var userClaims = new List<Claim>()
                    {
                        new Claim("Sid", user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Name.ToString()),
                        new Claim(ClaimTypes.Role, user.UserRole.ToString())
                    };
                    var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                    var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });

                    HttpContext.SignInAsync(userPrincipal);

                    if(user.UserRole.ToString() == "SALARIED")
                        return Redirect("listCra?id=" + user.Id);

                    if (user.UserRole.ToString() == "MANAGER")
                        return Redirect("Dashboard/Index/" + user.Id);

                    if (user.UserRole.ToString() == "ADMINISTRATOR")
                        return Redirect("/Dashboard");

                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);

                    return Redirect("/");
                }
                ModelState.AddModelError("User.Email", "Email et/ou mot de passe incorrect(s)");
            }
            return View(viewModel);
        }
       
        public ActionResult Deconnexion()
        {
            HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
