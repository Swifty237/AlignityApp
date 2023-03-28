using AlignityApp.Models;
using AlignityApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AlignityApp.Controllers
{
    [Authorize]
    public class TeamCrasController : Controller
    {
        public IActionResult Index(int id)
        {
            using (Dal dal = new Dal())
            {
                TeamsViewModel tvm = new TeamsViewModel() 
                { 
                    User = dal.GetUser(id),
                    Users = dal.GetUsersByManagerId(id),
                    Cras = dal.GetTeamCras(id) 
                };
                return View(tvm); 
            }
        }
    }
}
