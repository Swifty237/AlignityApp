using AlignityApp.Models;
using AlignityApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AlignityApp.Controllers
{
    [Authorize]
    public class TeamController : Controller
    {
        public IActionResult Index(int id)
        {
            TeamsViewModel tvm = new TeamsViewModel();
            using (Dal dal = new Dal()) 
            {
                if (User.IsInRole("ADMINISTRATOR"))
                {
                    tvm.Users = dal.GetAllManager();

                    return View(tvm);
                }
                if (id == 0)
                {
                    tvm.User = dal.GetUser(id);
                    tvm.Users = dal.GetAllUsers();
                    tvm.Cras = dal.GetAllCras();

                    return View(tvm);
                }
                else
                {
                    tvm.User = dal.GetUser(id);
                    tvm.Users = dal.GetUsersByManagerId(id);
                    tvm.Cras = dal.GetTeamCras(id);

                    return View(tvm);
                }
            }
        }
    }
}
