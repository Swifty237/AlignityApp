using AlignityApp.Models;
using AlignityApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
                    tvm.Salaries = dal.GetAllManager();

                    return View(tvm);
                }
                if (id == 0)
                {
                    tvm.User = dal.GetUser(id);
                    tvm.Salaries = dal.GetAllUsers();
                    tvm.Cras = dal.GetAllCras();
                    return View(tvm);
                }
                else
                {
                    tvm.User = dal.GetUser(id);
                    tvm.Salaries = dal.GetUsersByManagerId(id);
                    tvm.Cras = dal.GetTeamCras(id);
                    return View(tvm);
                }
            }
        }

        [HttpPost]
        public IActionResult ModalIndex(int id, TeamsViewModel tvm)
        {
            using (Dal dal = new Dal())
            {
                if (id != 0)
                {
                    dal.UpdateTJM(tvm.Salaried.Id, tvm.Salaried.RateTjm);
                    return RedirectToAction("Index", new { @id = id });
                }
                else
                {
                    return View("Error");
                }
            }
        }
    }
}
