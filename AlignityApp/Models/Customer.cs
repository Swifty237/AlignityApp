using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlignityApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Brand { get; set; }
        [MaxLength(100)]
        public string Adress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        [MaxLength(50)]
        public string Referent { get; set; }
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int JobInterviewsId { get; set; }
        public int InvoicesId { get; set; }
        public ICollection<JobInterview> JobInterviews { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
