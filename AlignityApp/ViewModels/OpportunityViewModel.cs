using AlignityApp.Models;
using System.Collections.Generic;

namespace AlignityApp.ViewModels
{
    public class OpportunityViewModel
    {
        public User User { get; set; }
        public List<User> Salaries { get; set; }
        public Customer Customer { get; set; }
    }
}
