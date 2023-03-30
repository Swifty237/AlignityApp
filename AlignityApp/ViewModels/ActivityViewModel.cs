using AlignityApp.Models;
using System.Collections.Generic;

namespace AlignityApp.ViewModels
{
    public class ActivityViewModel
    {
        public Activity activity { get; set; }
        public List<Activity> activities { get; set; }

        public Cra cra { get; set; }        
        public User User { get; set; }
    }
}
