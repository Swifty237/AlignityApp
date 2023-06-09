﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlignityApp.Models
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Firstname { get; set; }
        public DateTime Birthdate { get; set; }
        [MaxLength(100)]
        public string Adress { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        public int? PostalCode { get; set; }
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "Le champs Email est vide!")]
        public string Email { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Le champs Password est vide!")]
        public string Password { get; set; }
        public Job UserJob { get; set; }
        public int RateTjm { get; set; }
        public DateTime CreationDate { get; set; }
        public Role UserRole { get; set; }
        public int? ManagerId { get; set; }
        public User Manager { get; set; }
        public bool IsAvalaible { get; set; }
        public int? UserCrasId { get; set; }
        public ICollection<Cra> UserCras { get; set; }
        public int CA { get; set; }
    }
    public enum Role
    {
        SALARIED, 
        MANAGER, 
        ADMINISTRATOR
     
    }

    public enum Job
    {
        TECHNICIAN,
        HR_MANAGER,
        COMMERCIAL,
        SECRETARY,
        DIRECTOR
    }

    public enum Status
    {
        INTERNAL_PROVIDER,
        EXTERNAL_PROVIDER,
        CUSTOMER_CONTACT
    }
}
