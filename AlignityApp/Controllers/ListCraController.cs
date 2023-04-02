using AlignityApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using AlignityApp.ViewModels;

namespace AlignityApp.Controllers
{
    public class ListCraController : Controller
    {
        ActivityViewModel activityVM = new ActivityViewModel();
        private int idCra;

        public IActionResult Index(int id)
        {
            CraViewModel craVM = new CraViewModel();
            using (Dal dal = new Dal())
            {
                craVM.User = dal.GetUser(id);
                craVM.listCras = dal.GetCrasByUserId(id);
                return View(craVM);

            }
        }

        public IActionResult CreateCra(int id, int todo)
        {
            using (Dal dal = new Dal())
            {
                if (todo == 1)
                {
                    int count = 0;
                    List<Cra> listCra = dal.GetCrasByUserId(int.Parse(User.FindFirst("Sid").Value));
                    listCra.ForEach(c =>
                    {

                        if (c.State.ToString() == "DRAFT")
                        {
                            count++;
                        }
                    });
                    if (count == 0)
                    {
                        activityVM.cra = new Cra() { State = CRAState.DRAFT, UserId = id, CreationDate = DateTime.Now };

                        this.idCra = dal.CreateCra(activityVM.cra);
                        TempData["idCra"] = this.idCra;

                    
                        activityVM.activities = new List<Models.Activity>();

                        return View(activityVM);
                    }
                    else
                    {
                        Console.WriteLine("haha");
                        idCra = dal.FindCraByState(int.Parse(User.FindFirst("Sid").Value));
                        TempData["idCra"] = this.idCra;

                     
                        activityVM.activities = dal.FindCra(idCra);
                        activityVM.cra = dal.GetCraByCraId(id);

                        return View(activityVM);
                    }

                }
                else
                {
                    activityVM.activities = dal.FindCra(id);
                    activityVM.cra = dal.GetCraByCraId(id);
                    idCra = id;
                    TempData["idCra"] = this.idCra;
                    return View(activityVM);

                }
            }
        }

        [HttpPost]
        public IActionResult CreateCra(DateTime Date, ActivityTypes Type, ActivityPlace Place, int Duration, String Comments)
        {

            int id = (int)TempData["idCra"];
            Models.Activity activity = new Models.Activity() { Date = Date, CraId = id, Place = Place, Type = Type, Duration = Duration, Description = Comments };

            using (Dal dal = new Dal())
            {
                dal.CreateActivity(activity);

                return Redirect("/listCra/createCra/?id=" + id + "&todo=0");

            }
        }

        [HttpPost]
        public int DeleteActivity(int activityId)
        {
            int idCra = (int)TempData["idCra"];

            using (Dal dal = new Dal())
            {
                dal.DeleteActivity(activityId);

                return idCra;
            }
        }

        [HttpPost]
        public int ModifyCra()
        {
            int idCra = (int)TempData["idCra"];

            using (Dal dal = new Dal())
            {
                return dal.ModifyCraState(idCra);

            }
        }

        [HttpPost]
        public int ModifyCraByState(int id)
        {

            using (Dal dal = new Dal())
            {
                return dal.ModifyCraStateToInvalid(id, CRAState.ALERT);

            }
        }
        [HttpPost]
        public int CreateCommentManager(string comment, int statut)
        {
            int id = (int)TempData["idCra"];
            using (Dal dal = new Dal())
            {
                Cra cra = dal.GetCraByCraId(id);
                cra.Observation = comment;
                if (statut == 0)
                {
                    cra.State = CRAState.ALERT;

                }
                else
                {
                    cra.State = CRAState.VALIDATED;
                }
                dal.CreatCommentMannager(cra);
                return cra.UserId;
            }

        }
    }
}
