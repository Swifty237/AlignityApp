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
                    Cras = dal.GetTeamCras(id),
                    Users = dal.GetAllUsers()
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
                    countTeamCA += dal.SalariedHoursProduction(salaried) * salaried.RateTjm;
                }
                dvm.teamCA = countTeamCA;

                int globalCA = 0;

                foreach (var user in dvm.Users)
                {
                    globalCA += user.CA;
                }

                dvm.GlobalCA = globalCA;

                dvm.CountOpportunities = dal.GetAllJobInterviews().Count;

                return View(dvm);
            }
        }

        public ActionResult TeamData()
        {
            using (Dal dal = new Dal())
            {
                List<User> salaries = dal.GetUsersByManagerId(int.Parse(User.FindFirst("Sid").Value));

                int service = dal.HoursByActivityTypes(ActivityTypes.SERVICE, salaries);
                int holiday = dal.HoursByActivityTypes(ActivityTypes.HOLIDAYS, salaries);
                int rtt = dal.HoursByActivityTypes(ActivityTypes.RTT, salaries);
                int training = dal.HoursByActivityTypes(ActivityTypes.TRAINING, salaries);
                int intercontract = dal.HoursByActivityTypes(ActivityTypes.INTERCONTRACT, salaries);

                var data = new
                {
                    labels = new[] { "Prestation", "Formation", "Vacances", "RTT", "Intercontrat" },
                    datasets = 
                        new[] {
                            new {
                                data = new[] { service, training, holiday, rtt, intercontract },
                                    backgroundColor = new[] { "#16a085", "#2980b9", "#81ecec", "#f1c40f", "#e74c3c" },
                                    hoverBackgroundColor = new[] { "#95a5a6", "#95a5a6", "#95a5a6", "#95a5a6", "#95a5a6"},
                                    hoverBorderColor = "rgba(234, 236, 244, 1)"
                                }
                            }
                };

                JsonResult jsonResult = Json(data);
                return jsonResult;
            }
        }

        public ActionResult AllData()
        {
            using (Dal dal = new Dal())
            {
                List<User> users = dal.GetAllUsers();

                int service = dal.HoursByActivityTypes(ActivityTypes.SERVICE, users);
                int holiday = dal.HoursByActivityTypes(ActivityTypes.HOLIDAYS, users);
                int rtt = dal.HoursByActivityTypes(ActivityTypes.RTT, users);
                int training = dal.HoursByActivityTypes(ActivityTypes.TRAINING, users);
                int intercontract = dal.HoursByActivityTypes(ActivityTypes.INTERCONTRACT, users);

                var data = new
                {
                    labels = new[] { "Prestation", "Formation", "Vacances", "RTT", "Intercontrat" },
                    datasets =
                        new[] {
                            new {
                                data = new[] { service, training, holiday, rtt, intercontract },
                                    backgroundColor = new[] { "#16a085", "#2980b9", "#81ecec", "#f1c40f", "#e74c3c" },
                                    hoverBackgroundColor = new[] { "#95a5a6", "#95a5a6", "#95a5a6", "#95a5a6", "#95a5a6"},
                                    hoverBorderColor = "rgba(234, 236, 244, 1)"
                                }
                            }
                };

                JsonResult jsonResult = Json(data);
                return jsonResult;
            }
        }

    }
}
