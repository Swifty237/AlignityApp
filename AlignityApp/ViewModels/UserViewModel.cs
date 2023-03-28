using AlignityApp.Models;
using System.Collections.Generic;

namespace AlignityApp.ViewModels
{
    public class UserViewModel
    {
        public User User { get; set; }
        public bool Authentifie { get; set; }
        public List<User> listUsers { get; set; }
    }
}
