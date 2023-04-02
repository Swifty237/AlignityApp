using AlignityApp.Models;
using AlignityApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AlignityApp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index(int id)
        {
            using (Dal dal = new Dal())
            {
                DashboardViewModel dvm = new DashboardViewModel()
                {
                    User = dal.GetUser(id)
                };
                return View(dvm);
            }
        }

        public ActionResult EarningsAlignity()
        {

            using (Dal dal = new Dal())
            {
                if (User.IsInRole("MANAGER"))
                {
                List<double> list = dal.EarningsByTeam(int .Parse(User.FindFirst("Sid").Value));
                JsonResult jsonResult = Json(list);
                return jsonResult;

                }
                else
                {
                    List<double> list = dal.Earnings();
                    JsonResult jsonResult = Json(list);
                    return jsonResult;
                }
            }


        }
    }
}
