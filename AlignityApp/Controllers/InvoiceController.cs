using AlignityApp.Models;
using AlignityApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AlignityApp.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Index(int id)
        {
            using(Dal dal = new Dal())
            {
                InvoiceViewModel ivm = new InvoiceViewModel()
                {
                    User = dal.GetUser(id)
                };
                return View(ivm);
            }
        }

        public IActionResult CreateInvoice(int id)
        {
            using (Dal dal = new Dal())
            {
                InvoiceViewModel ivm = new InvoiceViewModel()
                {
                    User = dal.GetUser(id)
                };
                return View(ivm);
            }
        }
    }
}
