using AlignityApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AlignityApp.Controllers
{
    public class ListCraController : Controller
    {

        public IActionResult Index(int id)
        {
            using (Dal dal = new Dal())
            {
                if (id == 0)
                {
                    List<Cra> list = dal.GetAllCras();
                return View(list);

                }
                else
                {
                List<Cra> list = dal.GetCrasByUserId(id);
                    return View(list);
                }


            }
        }
    }
}
