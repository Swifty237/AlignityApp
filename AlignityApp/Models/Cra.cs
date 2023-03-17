using System;
using System.Collections.Generic;

namespace AlignityApp.Models
{
    public class Cra
    {
        public int Id { get; set; }
        public CRAState State { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserOfCraId { get; set; }
        public User UserOfCra { get; set; }
        public int? CraCommentsId { get; set; }
        public int? CraActivityId { get; set; }
        public ICollection<Comment> CraComments { get; set; }
        public ICollection<Activity> CraActivities { get; set; }
    }

    public enum CRAState
    {
        DRAFT,
        SENT,
        VALIDATED,
        ALERT
    }

}
