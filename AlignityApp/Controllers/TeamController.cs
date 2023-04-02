using AlignityApp.Models;
using AlignityApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
                if (id == -1)
                {
                    tvm.getScreen = 1;
                    tvm.Salaries = dal.GetSalariedWithoutManager();
                    tvm.User = dal.GetUser(id);

                    return View(tvm);
                }
                else
                {
                    if (User.IsInRole("ADMINISTRATOR") && id == 0)
                    {
                        tvm.Users = dal.GetAllManager();

                        return View(tvm);
                    }
                    else
                    {
                        tvm.User = dal.GetUser(id);
                        tvm.Users = dal.GetUsersByManagerId(id);
                        tvm.Cras = dal.GetTeamCras(id);

                        if (id == 0)
                        {
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
