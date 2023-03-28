using System;
using System.Collections.Generic;

namespace AlignityApp.Models
{
    public class JobInterview
    {
        public int Id { get; set; }
        public DateTime? InterviewDate { get; set; }
        public StateContract Contract { get; set; } = StateContract.INTERVIEW;
        public string ContractAssignement { get; set; } // Mission
        public DateTime? ContractStartAt { get; set; }
        public DateTime? ContractEndAt { get; set; }
        public int? InterviewDuration { get; set; }
        public int? SalariesId { get; set; }
        public int CustomerId { get; set; }
        public List<User> Salaries { get; set; }
        public Customer Customer { get; set; }
    }

    public enum StateContract
    {
        INTERVIEW,
        VALIDATED,
        IN_PROGRESS,
        END,
        CANCELED
    }
}
