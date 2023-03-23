using AlignityApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Collections.Generic;
using System;

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

        public IActionResult CreateCra(int id, int todo)
        {
            using (Dal dal = new Dal())
            {
                if (todo == 1)
                {
                    int count = 0;
                    List<Cra> listCra = dal.GetCrasByUserId(int.Parse(User.FindFirst(ClaimTypes.Sid).Value));
                    listCra.ForEach(c =>
                    {

                        if (c.State.ToString() == "DRAFT")
                        {
                            count++;
                        }
                    });
                    if (count == 0)
                    {
                        Cra cra = new Cra() { State = CRAState.DRAFT, UserId = id, CreationDate = DateTime.Now };

                        List<Activity> list=new List<Activity>();   

                        dal.CreateCra(cra);

                        return View(list);
                    }
                    else
                    {
                        return View("Error");
                    }

                }
                else
                {

                    List<Activity> list = dal.FindCra(id);
                    
                        return View(list);

                    


                }
            }
        }

        //[HttpPost]
        //public ActionResult ActioCreateCra(int value)
        //{
        //    Cra cra = new Cra() { State = CRAState.DRAFT, UserId = value, CreationDate = DateTime.Now };
        //    using (Dal dal = new Dal())
        //    {
        //        var result = dal.CreateCra(cra);

        //        return View(result);

        //    }
        //}
    }
}
