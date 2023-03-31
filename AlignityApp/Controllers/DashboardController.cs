using AlignityApp.Models;
using AlignityApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AlignityApp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index(int id)
        {
            using(Dal dal = new Dal())
            {
                DashboardViewModel dvm = new DashboardViewModel()
                {
                    User = dal.GetUser(id),
                    Salaries = dal.GetUsersByManagerId(id),
                    Cras = dal.GetTeamCras(id)
                };

                int count = 0;

                foreach (var cra in dvm.Cras)
                {
                    if (cra.State == CRAState.SENT)
                    {
                        count++;
                    }
                }
                dvm.CountCrasToValidate = count;

                int countTeamCA = 0;

                foreach (var salaried in  dvm.Salaries)
                {
                    countTeamCA += dal.UserHourCount(salaried) * salaried.RateTjm;
                }
                dvm.teamCA = countTeamCA;
                return View(dvm);
            }
        }
    }
}
