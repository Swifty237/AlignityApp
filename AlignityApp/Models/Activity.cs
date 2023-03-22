using System;
using System.Collections.Generic;

namespace AlignityApp.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public ActivityTypes Type { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ActivityPlace Place { get; set; }
        public int CraId { get; set; }
        public Cra Cra { get; set; }
        public int InvoicesId { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }

    public enum ActivityTypes
    {
        SERVICE,
        TRAINING,
        HOLIDAYS,
        RTT,
        INTERCONTRACT
    }

    public enum ActivityPlace
    {
        INTERNAL,
        EXTERNAL
    }
}
