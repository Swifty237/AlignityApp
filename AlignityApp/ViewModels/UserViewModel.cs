using AlignityApp.Models;
using System.Collections.Generic;

namespace AlignityApp.ViewModels
{
    public class UserViewModel
    {
        public User User { get; set; }
        public bool Authentifie { get; set; }
        public List<User> listUsers { get; set; }

        public List<Cra> listCras { get; set; }

        public List<T> listActivities { get; set; }
    }

    public class T
    {
        public string Type { get; set; }
        public int Duration { get; set; }
        public double Ration { get; internal set; }
    }
}
