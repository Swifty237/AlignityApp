using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;

namespace AlignityApp.Models
{
    public class BddContext : DbContext
    {
        public DbSet<ActivitiesCra> ActivitiesCras { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Observation> Observations { get; set; }
        public DbSet<Cra> Cras { get; set; }
        public DbSet<CrasUser> CraUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ObservationsUser> CommentsUsers { get; set; }
        public DbSet<UsersManager> UsersManagers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerActivity> CustomerActivities { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<JobInterview> JobInterviews { get; set; }
        public DbSet<SJobInterview> SJobInterviews { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;database=alignity_bdd");
        }
        public void InitializeUsers()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
            this.Users.AddRange(

                new User
                {
                    Name = "Admin",
                    Firstname = "Admin",
                    Birthdate = new DateTime(1992, 03, 11),
                    Email = "admin@exemple.fr",
                    Password = "12345",
                    UserRole = Role.ADMINISTRATOR,
                    CreationDate = new DateTime(1974, 10, 01),
                    IsAvalaible = true
                },
                new User
                {
                    Name = "Durand",
                    Firstname = "Jeanne",
                    Birthdate = new DateTime(1992, 03, 11),
                    Adress = "15 rue drouot",
                    City = "Paris",
                    PostalCode = 75009,
                    PhoneNumber = "0667605968",
                    Email = "jeanne123@exemple.fr",
                    Password = "12345",
                    UserJob = Job.COMMERCIAL,
                    UserRole = Role.MANAGER,
                    RateTjm = 521,
                    CreationDate = new DateTime(2019, 10, 01),
                    IsAvalaible = true
                },
                new User
                {
                    Name = "Kayser",
                    Firstname = "Sozé",
                    Birthdate = new DateTime(1995, 07, 19),
                    Adress = "13 rue Paris",
                    City = "Paris",
                    PostalCode = 75020,
                    PhoneNumber = "0666615768",
                    Email = "kaysersoze@exemple.com",
                    Password = "12345",
                    UserJob = Job.TECHNICIAN,
                    UserRole = Role.MANAGER,
                    RateTjm = 530,
                    CreationDate = new DateTime(2017, 12, 01),
                    IsAvalaible = true
                },
                new User
                {
                    Name = "Lauga",
                    Firstname = "Matteo",
                    Birthdate = new DateTime(1992, 06, 19),
                    Adress = "13 rue Lucien Sampaix",
                    City = "Paris",
                    PostalCode = 75010,
                    PhoneNumber = "0756615712",
                    Email = "lauga@exemple.com",
                    Password = "12345",
                    UserRole = Role.MANAGER,
                    RateTjm = 530,
                    UserJob = Job.HR_MANAGER,
                    CreationDate = new DateTime(2017, 12, 01),
                    IsAvalaible = true
                }, new User
                {
                    Name = "dupont",
                    Firstname = "thomas",
                    Birthdate = new DateTime(1974, 10, 01),
                    Email = "thomas@gmail.com",
                    Password = "12345",
                    Adress = "15 rue drouot",
                    City = "Paris",
                    PostalCode = 75009,
                    PhoneNumber = "0667605968",
                    UserRole = Role.SALARIED,
                    UserJob = Job.COMMERCIAL,
                    ManagerId = 2,
                    RateTjm = 221,
                    CreationDate = new DateTime(2020, 10, 01),
                    IsAvalaible = true
                },
                new User
                {
                    Name = "John",
                    Firstname = "Doe",
                    Birthdate = new DateTime(2000, 07, 26),
                    Email = "john_doe@exemple.com",
                    Password = "56789",
                    Adress = "11 rue paradis",
                    City = "Paris",
                    PostalCode = 75009,
                    PhoneNumber = "0767266968",
                    UserRole = Role.SALARIED,
                    UserJob = Job.SECRETARY,
                    ManagerId = 2,
                    RateTjm = 521,
                    CreationDate = new DateTime(2019, 10, 01),
                    IsAvalaible = true
                },
                new User
                {
                    Name = "Vincent",
                    Firstname = "Claude",
                    Birthdate = new DateTime(1997, 08, 09),
                    Email = "vincent_claude@exemple.com",
                    Password = "12312",
                    Adress = "13 rue Rome",
                    City = "Paris",
                    PostalCode = 75017,
                    PhoneNumber = "0668242974",
                    UserRole = Role.SALARIED,
                    UserJob = Job.SECRETARY,
                    ManagerId = 2,
                    RateTjm = 321,
                    CreationDate = new DateTime(2012, 10, 01),
                    IsAvalaible = true
                },
                new User
                {
                    Name = "Tabut",
                    Firstname = "Lucile",
                    Birthdate = new DateTime(1988, 07, 28),
                    Email = "tabutlucile@exemple.com",
                    Password = "11111",
                    Adress = "13 rue Saint-Paul",
                    City = "Paris",
                    PostalCode = 75005,
                    PhoneNumber = "0768651276",
                    UserRole = Role.SALARIED,
                    UserJob = Job.TECHNICIAN,
                    ManagerId = 3,
                    RateTjm = 442,
                    CreationDate = new DateTime(2000, 05, 01),
                    IsAvalaible = true
                },
                new User
                {
                    Name = "Maitrias",
                    Firstname = "Camille",
                    Birthdate = new DateTime(1992, 12, 12),
                    Email = "camille@exemple.fr",
                    Password = "95959",
                    Adress = "13 rue Lion",
                    City = "Paris",
                    PostalCode = 75005,
                    PhoneNumber = "0168645276",
                    UserRole = Role.SALARIED,
                    UserJob = Job.COMMERCIAL,
                    ManagerId = 3,
                    RateTjm = 342,
                    CreationDate = new DateTime(2002, 05, 01),
                    IsAvalaible = true
                },
                new User
                {
                    Name = "Bartelet",
                    Firstname = "Claire",
                    Birthdate = new DateTime(1978, 02, 15),
                    Email = "claire@exemple.com",
                    Password = "31313",
                    Adress = "13 rue Thibault",
                    City = "Paris",
                    PostalCode = 75005,
                    PhoneNumber = "0667623276",
                    UserRole = Role.SALARIED,
                    UserJob = Job.TECHNICIAN,
                    ManagerId = 3,
                    RateTjm = 542,
                    CreationDate = new DateTime(2004, 08, 01),
                    IsAvalaible = true
                },
                new User
                {
                    Name = "Zahner",
                    Firstname = "Nicolas",
                    Birthdate = new DateTime(1979, 08, 21),
                    Email = "zahner78@exemple.com",
                    Password = "33333",
                    Adress = "13 rue paul",
                    City = "Paris",
                    PostalCode = 75003,
                    PhoneNumber = "0268456276",
                    UserRole = Role.SALARIED,
                    UserJob = Job.TECHNICIAN,
                    ManagerId = 4,
                    RateTjm = 482,
                    CreationDate = new DateTime(2010, 05, 01),
                    IsAvalaible = true
                },

                new User
                {
                    Name = "Roche",
                    Firstname = "Lucie",
                    Birthdate = new DateTime(1993, 03, 11),
                    Email = "lucie@exemple.fr",
                    Password = "12345",
                    Adress = "13 rue Nantes",
                    City = "Paris",
                    PostalCode = 75016,
                    PhoneNumber = "0650654276",
                    UserRole = Role.SALARIED,
                    UserJob = Job.SECRETARY,
                    ManagerId = 4,
                    RateTjm = 462,
                    CreationDate = new DateTime(2011, 05, 01),
                    IsAvalaible = true
                }

                );
            this.SaveChanges();
        }

        public void InitializeCra()
        {
            this.Cras.AddRange(
                        new Cra { State = CRAState.VALIDATED, UserId = 5, CreationDate = new DateTime(2022, 12, 03) },
                        new Cra { State = CRAState.VALIDATED, UserId = 5, CreationDate = new DateTime(2023, 01, 05) },
                        new Cra { State = CRAState.SENT, UserId = 5, CreationDate = new DateTime(2023, 02, 06) },
                        new Cra { State = CRAState.ALERT, UserId = 5, CreationDate = new DateTime(2023, 03, 07) },
                        new Cra { State = CRAState.DRAFT, UserId = 5, CreationDate = new DateTime(2023, 04, 01) },
                        new Cra { State = CRAState.VALIDATED, UserId = 6, CreationDate = new DateTime(2023, 01, 05) },
                        new Cra { State = CRAState.SENT, UserId = 6, CreationDate = new DateTime(2023, 02, 06) },
                        new Cra { State = CRAState.ALERT, UserId = 6, CreationDate = new DateTime(2023, 03, 07) },
                        new Cra { State = CRAState.DRAFT, UserId = 6, CreationDate = new DateTime(2023, 04, 01) },
                           new Cra { State = CRAState.VALIDATED, UserId = 7, CreationDate = new DateTime(2023, 01, 05) },
                        new Cra { State = CRAState.SENT, UserId = 7, CreationDate = new DateTime(2023, 02, 06) },
                        new Cra { State = CRAState.ALERT, UserId = 7, CreationDate = new DateTime(2023, 03, 07) },
                        new Cra { State = CRAState.DRAFT, UserId = 7, CreationDate = new DateTime(2023, 04, 01) },
                           new Cra { State = CRAState.VALIDATED, UserId = 8, CreationDate = new DateTime(2023, 01, 05) },
                        new Cra { State = CRAState.SENT, UserId = 8, CreationDate = new DateTime(2023, 02, 06) },
                        new Cra { State = CRAState.ALERT, UserId = 8, CreationDate = new DateTime(2023, 03, 07) },
                        new Cra { State = CRAState.DRAFT, UserId = 8, CreationDate = new DateTime(2023, 04, 01) },
                           new Cra { State = CRAState.VALIDATED, UserId = 9, CreationDate = new DateTime(2023, 01, 05) },
                        new Cra { State = CRAState.SENT, UserId = 9, CreationDate = new DateTime(2023, 02, 06) },
                        new Cra { State = CRAState.ALERT, UserId = 9, CreationDate = new DateTime(2023, 03, 07) },
                        new Cra { State = CRAState.DRAFT, UserId = 9, CreationDate = new DateTime(2023, 04, 01) },
                           new Cra { State = CRAState.VALIDATED, UserId = 10, CreationDate = new DateTime(2023, 01, 05) },
                        new Cra { State = CRAState.SENT, UserId = 10, CreationDate = new DateTime(2023, 02, 06) },
                        new Cra { State = CRAState.ALERT, UserId = 10, CreationDate = new DateTime(2023, 03, 07) },
                        new Cra { State = CRAState.DRAFT, UserId = 10, CreationDate = new DateTime(2023, 04, 01) },
                           new Cra { State = CRAState.VALIDATED, UserId = 11, CreationDate = new DateTime(2023, 01, 05) },
                        new Cra { State = CRAState.SENT, UserId = 11, CreationDate = new DateTime(2023, 02, 06) },
                        new Cra { State = CRAState.ALERT, UserId = 11, CreationDate = new DateTime(2023, 03, 07) },
                        new Cra { State = CRAState.DRAFT, UserId = 11, CreationDate = new DateTime(2023, 04, 01) }



                    );
            this.SaveChanges();
        }

        public void InitializeActivity()
        {
            this.Activities.AddRange(
                            new Activity() { Date = new DateTime(2023, 03, 01), Duration = 8, Type = ActivityTypes.SERVICE, Place = ActivityPlace.EXTERNAL, CraId = 17 },
                            new Activity() { Date = new DateTime(2023, 03, 02), Duration = 9, Type = ActivityTypes.INTERCONTRACT, Place = ActivityPlace.INTERNAL, Description = "j'ai fait 1h de sup", CraId = 17 },
                            new Activity() { Date = new DateTime(2023, 03, 03), Duration = 8, Type = ActivityTypes.HOLIDAYS, Place = ActivityPlace.EXTERNAL, CraId = 17 },
                            new Activity() { Date = new DateTime(2023, 03, 04), Duration = 10, Type = ActivityTypes.TRAINING, Place = ActivityPlace.INTERNAL, Description = "j'ai fait 2h de sup", CraId = 17 },
                            new Activity() { Date = new DateTime(2023, 03, 05), Duration = 9, Type = ActivityTypes.RTT, Place = ActivityPlace.EXTERNAL, CraId = 17 },
                            new Activity() { Date = new DateTime(2023, 03, 06), Duration = 9, Type = ActivityTypes.RTT, Place = ActivityPlace.EXTERNAL, CraId = 17 },
                            new Activity() { Date = new DateTime(2023, 03, 07), Duration = 8, Type = ActivityTypes.SERVICE, Place = ActivityPlace.EXTERNAL, CraId = 17 },
                            new Activity() { Date = new DateTime(2023, 04, 07), Duration = 8, Type = ActivityTypes.SERVICE, Place = ActivityPlace.EXTERNAL, CraId = 18 },
                            new Activity() { Date = new DateTime(2023, 04, 01), Duration = 8, Type = ActivityTypes.SERVICE, Place = ActivityPlace.EXTERNAL, CraId = 25 },
                            new Activity() { Date = new DateTime(2023, 04, 02), Duration = 9, Type = ActivityTypes.INTERCONTRACT, Place = ActivityPlace.INTERNAL, Description = "j'ai fait 1h de sup", CraId = 25 },
                            new Activity() { Date = new DateTime(2023, 04, 03), Duration = 8, Type = ActivityTypes.HOLIDAYS, Place = ActivityPlace.EXTERNAL, CraId = 25 },
                            new Activity() { Date = new DateTime(2023, 04, 04), Duration = 10, Type = ActivityTypes.SERVICE, Place = ActivityPlace.INTERNAL, Description = "j'ai fait 2h de sup", CraId = 25 },
                            new Activity() { Date = new DateTime(2023, 04, 05), Duration = 9, Type = ActivityTypes.RTT, Place = ActivityPlace.EXTERNAL, CraId = 25 },
                            new Activity() { Date = new DateTime(2023, 04, 06), Duration = 9, Type = ActivityTypes.RTT, Place = ActivityPlace.EXTERNAL, CraId = 25 },
                            new Activity() { Date = new DateTime(2023, 04, 07), Duration = 8, Type = ActivityTypes.SERVICE, Place = ActivityPlace.EXTERNAL, CraId = 25 },
                            new Activity() { Date = new DateTime(2023, 03, 07), Duration = 8, Type = ActivityTypes.SERVICE, Place = ActivityPlace.EXTERNAL, CraId = 8 }
                    );
            this.SaveChanges();
        }
            public void InitializeCustomers()
            {
                this.Customers.AddRange(
                    new Customer() { Brand = "Hopital de Créteil" },
                    new Customer() { Brand = "Pharmacie des Lilas" },
                    new Customer() { Brand = "Pharmacie les coteaux" },
                    new Customer() { Brand = "CHU Nanterre" }
                );
                this.SaveChanges();
            }
        }
    }

