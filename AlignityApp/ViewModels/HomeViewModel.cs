using AlignityApp.Models;
using System;

namespace AlignityApp.ViewModels
{
    public class HomeViewModel
    {
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public User Salaried { get; set; }
    }
}
