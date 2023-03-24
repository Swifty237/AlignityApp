using System;

namespace AlignityApp.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime conDate { get; set; }
        public int amount { get; set; }
        public int InvoiceActivityId { get; set; }
        public int InvoiceCustomerId { get; set; }
        public Activity InvoiceActivity { get; set; }
        public Customer InvoiceCustomer { get; set; }
    }
}
