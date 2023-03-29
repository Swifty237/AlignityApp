using AlignityApp.Models;
using AlignityApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Xml.Linq;
using System;

namespace AlignityApp.Controllers
{
    public class OpportunityController : Controller
    {
        public IActionResult Index(int id)
        {
            using (Dal dal = new Dal())
            {
                OpportunityViewModel ovm = new OpportunityViewModel()
                {
                    User = dal.GetUser(id)
                };
                return View(ovm);
            }
        }

        /*        [HttpPost]
                public IActionResult Form1(MyData data)
                {
                    if (ModelState.IsValid)
                    {
                        // Code pour enregistrer la donnée dans la base de données
                        return RedirectToAction("Index");
                    }
                    return View("Index");
                }

                [HttpPost]
                public IActionResult Form2(MyData data)
                {
                    if (ModelState.IsValid)
                    {
                        // Code pour enregistrer la donnée dans la base de données
                        return RedirectToAction("Index");
                    }
                    return View("Index");
                }*/

        public IActionResult CreateOpportunity(int id)
        {
            using (Dal dal = new Dal())
            {
                if (id != 0)
                {
                    List<Customer> customers = dal.GetAllCustomers();
                    ViewBag.listCustomers = customers;

                    List<User> salaries = dal.GetAllSalaries(id);
                    ViewBag.listSalaries = salaries;

                    Customer customer = dal.GetCustomerById(dal.GetJIById(dal.GetJobInterviewId()).CustomerId);
                    
                    List<SJobInterview> salariedForJob = dal.GetSalariesByJId(dal.GetJobInterviewId());

                    if (customer != null)
                    {
                        OpportunityViewModel ovm = new OpportunityViewModel()
                        {
                            User = dal.GetUser(id),
                            Salaries = dal.GetSalariesById(salariedForJob),
                            Customer = customer
                        };
                        return View(ovm);
                    }

                    OpportunityViewModel ovm2 = new OpportunityViewModel()
                    {
                        User = dal.GetUser(id),
                        Salaries = new List<User>(),
                        Customer = new Customer()
                    };
                    return View(ovm2);


                }
                else
                {
                    return View("Error");
                }
            }
        }

        [HttpPost]
        public IActionResult CreateOpportunity2(int id, int CustomerId)
        {
            using (Dal dal = new Dal())
            {
                if (id != 0)
                {
                    dal.CreateJobInterview("Mon contrat", CustomerId);
                    return RedirectToAction("CreateOpportunity", new { @id = id });
                }
                else
                {
                    return View("Error");
                }
            }
        }

        [HttpPost]
        public IActionResult CreateOpportunity3(int id, int salariedId)
        {
            using (Dal dal = new Dal())
            {
                if (id != 0)
                {
                    dal.ModifySJobInterview(salariedId);
                    return RedirectToAction("CreateOpportunity", new { @id = id });
                }
                else
                {
                    return View("Error");
                }
            }
        }

        public IActionResult Contract(int id)
        {
            using (Dal dal = new Dal())
            {
                OpportunityViewModel ovm = new OpportunityViewModel()
                {
                    User = dal.GetUser(id)
                };
                return View(ovm);
            }
        }
    }
}
