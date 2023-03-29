using System;
using System.Collections.Generic;

namespace AlignityApp.Models
{
    public class Cra
    {
        public int Id { get; set; }
        public CRAState State { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Observation { get; set; }
        public DateTime CreationDate { get; set; }
    }
    public enum CRAState
    {
        DRAFT,
        SENT,
        VALIDATED,
        ALERT
    }

}
