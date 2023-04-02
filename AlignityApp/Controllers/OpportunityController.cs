using AlignityApp.Models;
using AlignityApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Xml.Linq;
using System;
using System.Linq;

namespace AlignityApp.Controllers
{
    public class OpportunityController : Controller
    {
        public IActionResult Index(int id)
        {
            using (Dal dal = new Dal())
            {
                List<JobInterview> jobInterviews = dal.GetAllJobInterviews();
                Dictionary<string, List<User>> keyValuePairs = new Dictionary<string, List<User>>();
                
                foreach (var jobInterview in jobInterviews)
                {
                    List<User> salaries = dal.GetSalariedByCustomer(jobInterview.CustomerId);
                    string brand = dal.GetCustomerById(jobInterview.CustomerId).Brand;

                    if (!keyValuePairs.Any(kvp => kvp.Key == brand && kvp.Value.SequenceEqual(salaries)))
                    {
                        keyValuePairs.Add(brand, salaries);
                    }
                }

                OpportunityViewModel ovm = new OpportunityViewModel()
                {
                    User = dal.GetUser(id),
                    JobInterviews = jobInterviews,
                    SalariesCustomer = keyValuePairs              
                };

                return View(ovm);
            }
        }

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
                            Customer = customer,
                        };
                        return View(ovm);
                    }
                    else
                    {
                        OpportunityViewModel ovm2 = new OpportunityViewModel()
                        {
                            User = dal.GetUser(id),
                            Salaries = dal.GetSalariesById(salariedForJob),
                            Customer = new Customer(),
                        };
                        return View(ovm2);
                    }
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
        public IActionResult CreateOpportunity3(int id, int SalariedId)
        {
            using (Dal dal = new Dal())
            {
                if (id != 0)
                {
                    dal.ModifySJobInterview(SalariedId);
                    return RedirectToAction("CreateOpportunity", new { @id = id });
                }
                else
                {
                    return View("Error");
                }
            }
        }

        [HttpPost]
        public IActionResult ValidateOpportunity(int id)
        {
            using (Dal dal = new Dal())
            {
                if (id != 0)
                {
                    dal.UpdateJobInterview(dal.GetJIById(dal.GetJobInterviewId()));
                    return RedirectToAction("CreateOpportunity", new { @id = id });
                }
                else
                {
                    return View("Error");
                }
            }
        }

        [HttpPost]
        public IActionResult DeleteOpportunity(int id)
        {
            using (Dal dal = new Dal())
            {
                if (id != 0)
                {
                    dal.DeleteJobInterview();
                    /*dal.DeleteSJobInterview();*/
                    return RedirectToAction("CreateOpportunity", new { @id = id });
                }
                else
                {
                    return View("Error");
                }
            }
        }
    }
}
