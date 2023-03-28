using System;

namespace AlignityApp.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int TjmToInvoiced { get; set; }
        public int amount { get; set; }
        public CRAState InvoiceState { get; set; }
        public int InvoiceCraId { get; set; }
        public int InvoiceCustomerId { get; set; }
        public Activity InvoiceCra { get; set; }
        public Customer InvoiceCustomer { get; set; }
        public string InvoiceIssuer { get; set; } // Emetteur de la facture
    }
}
