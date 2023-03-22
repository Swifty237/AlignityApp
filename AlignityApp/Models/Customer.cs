﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlignityApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public bool IsCorporation { get; set; }
        [MaxLength(100)]
        public string Brand { get; set; }
        [MaxLength(100)]
        public string Adress { get; set; }
        [MaxLength(50)]
        public string referent { get; set; }
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        public int ActivitiesId { get; set; }
        public int InvoicesId { get; set; }
        public ICollection<Activity> Activities { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
