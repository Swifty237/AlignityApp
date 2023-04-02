using AlignityApp.Models;
using System.Collections.Generic;

namespace AlignityApp.ViewModels
{
    public class DashboardViewModel
    {
        public User User { get; set; }
        public List<User> Salaries { get; set; }
        public List<User> Users { get; set; }
        public List<Cra> Cras { get; set; }
        public int CountCrasToValidate { get; set; }
        public int teamCA { get; set; }
        public int GlobalCA { get; set; }
        public int CountOpportunities { get; set; }
    }
}
