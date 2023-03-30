using AlignityApp.Models;
using System.Collections.Generic;

namespace AlignityApp.ViewModels
{
    public class TeamsViewModel
    {
        public User User { get; set; }
        public List<User> Salaries { get; set; }
        public List<Cra> Cras { get; set; }
        public User Salaried { get; set; }
    }
}
