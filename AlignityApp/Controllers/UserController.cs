using AlignityApp.Models;
using AlignityApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AlignityApp.Controllers
{
    public class UserController : Controller
    {
        UserViewModel userVM = new UserViewModel();
        public IActionResult Index(int id)
        {
            using (Dal dal = new Dal())
            {
                userVM.User = dal.GetUser(id);

                userVM.listCras = dal.GetCrasByUserId(id);

                userVM.listActivities=dal.FindActivitysByUserId(id); 
   

            }

            return View(userVM);
        }

        public IActionResult AjouterUser(int id)
        {
            using (Dal dal = new Dal())
            {
                if (id == 0)
                {
                    userVM.listUsers = dal.GetAllManager();
                    return View(userVM);

                }
                else
                {
                    userVM.listUsers = dal.GetAllManager();
                    userVM.User = dal.GetUser(id);
                    return View(userVM);
                }
            }


        }

        [HttpPost]
        public IActionResult AjouterUser(User user)
        {
            
            using (Dal dal = new Dal())
            {
                User userCopy = dal.GetAllUsers().Where(r => r.Email == user.Email).FirstOrDefault();
                if (userCopy ==null)
                {
                    user.CreationDate = DateTime.Now;
                    user.IsAvalaible = true;    
                    dal.CreateUser(user);
                    return Redirect("/team");

                }
                else
                {
                    user.Id = userCopy.Id;
                    user.IsAvalaible = true;
                    user.CreationDate=userCopy.CreationDate;
                    if(user.UserRole.ToString()=="MANAGER"|| user.UserRole.ToString() == "ADMINISTRATOR")
                    {
                        user.Manager = null;
                        user.ManagerId = null;
                    }
                    dal.ModifyUser(user);
                    return Redirect("/team");
                }
            }


        }

        [HttpPost]
        public IActionResult DeleteUser(int id)
        {

            using (Dal dal = new Dal())
            {
                dal.DeleteUser(id);
            }

            return Redirect("/team");
        }
    }

}
