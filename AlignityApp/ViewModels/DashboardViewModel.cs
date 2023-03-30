using AlignityApp.Models;
using System.Collections.Generic;

namespace AlignityApp.ViewModels
{
    public class DashboardViewModel
    {
        public User User { get; set; }
        public List<User> Salaries { get; set; }
    }
}
