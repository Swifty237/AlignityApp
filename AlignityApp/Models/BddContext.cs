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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;database=alignity_bdd");
        }
        public void InitializeManagers()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
            this.Users.AddRange(
                new User
                {
                    Name = "Durand",
                    Firstname = "Jeanne",
                    Birthdate = new DateTime(1992, 03, 11),
                    Email = "jeanne123@exemple.fr",
                    Password = "91011",
                    UserRole = Role.MANAGER,
                    CreationDate = DateTime.Now
                },
                new User
                {
                    Name = "Kayser",
                    Firstname = "Sozé",
                    Birthdate = new DateTime(1995, 07, 19),
                    Email = "kaysersoze@exemple.com",
                    Password = "55555",
                    UserRole = Role.MANAGER,
                    CreationDate = DateTime.Now
                });
            this.SaveChanges();
        }
        public void IntializeAdmins()
        {
            this.Users.AddRange(
                new User
                {
                    Name = "Lauga",
                    Firstname = "Matteo",
                    Birthdate = new DateTime(1984, 12, 10),
                    Email = "matteo_lauga@exemple.com",
                    Password = "22222",
                    UserRole = Role.MANAGER
                });
            this.SaveChanges();
        }


        public void InitializeSalaries()
        {
            this.Users.AddRange(
                new User
                {
                    Name = "dupont",
                    Firstname = "thomas",
                    Birthdate = new DateTime(1974, 10, 01),
                    Email = "thomas@gmail.com",
                    Password = "12345",
                    UserRole = Role.SALARIED,
                    ManagerId = 1,
                    RateTjm = 521,
                    CreationDate = DateTime.Now
                },
                new User
                {
                    Name = "John",
                    Firstname = "Doe",
                    Birthdate = new DateTime(2000, 07, 26),
                    Email = "john_doe@exemple.com",
                    Password = "56789",
                    UserRole = Role.SALARIED,
                    ManagerId = 1,
                    RateTjm = 472,
                    CreationDate = DateTime.Now
                },
                new User
                {
                    Name = "Vincent",
                    Firstname = "Claude",
                    Birthdate = new DateTime(1997, 08, 09),
                    Email = "vincent_claude@exemple.com",
                    Password = "12312",
                    UserRole = Role.SALARIED,
                    ManagerId = 1,
                    RateTjm = 537,
                    CreationDate = DateTime.Now
                },
                new User
                {
                    Name = "Tabut",
                    Firstname = "Lucile",
                    Birthdate = new DateTime(1988, 11, 28),
                    Email = "tabutlucile@exemple.com",
                    Password = "11111",
                    UserRole = Role.SALARIED,
                    ManagerId = 2,
                    RateTjm = 516,
                    CreationDate = DateTime.Now
                },
                new User
                {
                    Name = "Maitrias",
                    Firstname = "Camille",
                    Birthdate = new DateTime(1992, 12, 12),
                    Email = "jeanne123@exemple.fr",
                    Password = "95959",
                    UserRole = Role.SALARIED,
                    ManagerId = 2,
                    RateTjm = 633,
                    CreationDate = DateTime.Now
                },
                new User
                {
                    Name = "Bartelet",
                    Firstname = "Claire",
                    Birthdate = new DateTime(1978, 02, 15),
                    Email = "vincent_claude@exemple.com",
                    Password = "31313",
                    UserRole = Role.SALARIED,
                    ManagerId = 2,
                    RateTjm = 615,
                    CreationDate = DateTime.Now
                },
                new User
                {
                    Name = "Zahner",
                    Firstname = "Nicolas",
                    Birthdate = new DateTime(1979, 08, 21),
                    Email = "zahner78@exemple.com",
                    Password = "33333",
                    UserRole = Role.SALARIED,
                    ManagerId = 1,
                    RateTjm = 587,
                    CreationDate = DateTime.Now
                },
                
                new User
                  {
                      Name = "Admin",
                      Firstname = "Admin",
                      Birthdate = new DateTime(1992, 03, 11),
                      Email = "admin@exemple.fr",
                      Password = "12345",
                      UserRole = Role.ADMINISTRATOR,
                      CreationDate = DateTime.Now
                  });

            this.SaveChanges();
        }

        public void InitializeCra()
        {
            this.Cras.AddRange(
                        new Cra { State = CRAState.DRAFT, UserId = 5, CreationDate = new DateTime(2022, 01, 11) },
                        new Cra { State = CRAState.DRAFT, UserId = 1, CreationDate = new DateTime(2022, 01, 11) },
                        new Cra { State = CRAState.DRAFT, UserId = 2, CreationDate = new DateTime(2022, 01, 11) },
                        new Cra { State = CRAState.DRAFT, UserId = 3, CreationDate = new DateTime(2022, 01, 11) },
                        new Cra { State = CRAState.SENT, UserId = 6, CreationDate = new DateTime(2023, 03, 11) },
                        new Cra { State = CRAState.ALERT, UserId = 5, CreationDate = new DateTime(1992, 03, 11) },
                        new Cra { State = CRAState.SENT, UserId = 4, CreationDate = new DateTime(1996, 03, 11) },
                        new Cra { State = CRAState.VALIDATED, UserId = 5, CreationDate = new DateTime(2002, 03, 11) },
                        new Cra { State = CRAState.ALERT, UserId = 4, CreationDate = new DateTime(2002, 03, 11) },
                        new Cra { State = CRAState.SENT, UserId = 5, CreationDate = new DateTime(2002, 03, 11) },
                        new Cra { State = CRAState.VALIDATED, UserId = 4, CreationDate = new DateTime(2002, 03, 11) },
                        new Cra { State = CRAState.VALIDATED, UserId = 5, CreationDate = new DateTime(2002, 03, 11) }
                    );
            this.SaveChanges();
        }

        public void InitializeActivity()
        {


            this.Activities.AddRange(
                            new Activity() { Date = new DateTime(2022, 01, 11), Duration = 8, Type = ActivityTypes.SERVICE, Place = ActivityPlace.EXTERNAL, Description = "j'ai fait 1h de sup", CraId = 5 },
                            new Activity() { Date = new DateTime(2022, 01, 12), Duration = 8, Type = ActivityTypes.INTERCONTRACT, Place = ActivityPlace.INTERNAL, Description = "j'ai fait 1h de sup", CraId = 5 },
                            new Activity() { Date = new DateTime(2022, 01, 13), Duration = 8, Type = ActivityTypes.HOLIDAYS, Place = ActivityPlace.EXTERNAL, Description = "j'ai fait 3h de sup", CraId = 1 },
                            new Activity() { Date = new DateTime(2022, 01, 14), Duration = 8, Type = ActivityTypes.TRAINING, Place = ActivityPlace.INTERNAL, Description = "j'ai fait 4h de sup", CraId = 1 },
                            new Activity() { Date = new DateTime(2022, 01, 11), Duration = 8, Type = ActivityTypes.RTT, Place = ActivityPlace.EXTERNAL, Description = "j'ai fait 5h de sup", CraId = 7 },
                            new Activity() { Date = new DateTime(2022, 01, 12), Duration = 8, Type = ActivityTypes.RTT, Place = ActivityPlace.EXTERNAL, Description = "j'ai fait 5h de sup", CraId = 7 },
                            new Activity() { Date = new DateTime(2022, 01, 11), Duration = 8, Type = ActivityTypes.RTT, Place = ActivityPlace.EXTERNAL, Description = "j'ai fait 5h de sup", CraId = 7 }
                    );

            this.SaveChanges();
        }
    }
}

