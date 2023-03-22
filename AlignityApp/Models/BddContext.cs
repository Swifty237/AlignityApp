using Microsoft.EntityFrameworkCore;
using System;

namespace AlignityApp.Models
{
    public class BddContext : DbContext
    {
        public DbSet<ActivitiesCra> ActivitiesCras { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Cra> Cras { get; set; }
        public DbSet<CrasUser> CraUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CommentsUser> CommentsUsers { get; set; }
        public DbSet<UsersManager> UsersManagers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<UsersCustomer> UsersCustomers { get; set; }
        public DbSet<CustomerActivity> CustomerActivities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=password;database=alignity_bdd");
        }

        public void InitializeDb()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();

            this.Users.AddRange(

            new User
            {
                Name = "dupont",
                Firstname = "thomas",
                Birthdate = new DateTime(1974, 10, 01),
                Email = "thomas@gmail.com",
                Password = "12345",
                UserRole = Role.SALARIED
            },

            new User
            {
                Name = "John",
                Firstname = "Doe",
                Birthdate = new DateTime(2000, 07, 26),
                Email = "john_doe@exemple.com",
                Password = "56789",
                UserRole = Role.SALARIED
            },

            new User
            {
                Name = "Durand",
                Firstname = "Jeanne",
                Birthdate = new DateTime(1992, 03, 11),
                Email = "jeanne123@exemple.fr",
                Password = "91011",
                UserRole = Role.MANAGER
            },

            new User
            {
                Name = "Vincent",
                Firstname = "Claude",
                Birthdate = new DateTime(1997, 08, 09),
                Email = "vincent_claude@exemple.com",
                Password = "12312",
                UserRole = Role.ADMINISTRATOR
            },

            new User
            {
                Name = "Tabut",
                Firstname = "Lucile",
                Birthdate = new DateTime(1988, 11, 28),
                Email = "tabutlucile@exemple.com",
                Password = "11111",
                UserRole = Role.SALARIED
            },

            new User
            {
                Name = "Kayser",
                Firstname = "Sozé",
                Birthdate = new DateTime(1995, 07, 19),
                Email = "kayser-soze@exemple.com",
                Password = "55555",
                UserRole = Role.MANAGER
            });

            this.SaveChanges();
        }

        public void InitializeUser()
        {
            this.Users.AddRange(

            new User
            {
                Name = "Tabut",
                Firstname = "Lucile",
                Birthdate = new DateTime(1988, 11, 28),
                Email = "tabutlucile@exemple.com",
                Password = "11111",
                UserRole = Role.SALARIED
            },

            new User
            {
                Name = "Kayser",
                Firstname = "Sozé",
                Birthdate = new DateTime(1995, 07, 19),
                Email = "kayser-soze@exemple.com",
                Password = "55555",
                UserRole = Role.SALARIED
            },

            new User
            {
                Name = "Maitrias",
                Firstname = "Camille",
                Birthdate = new DateTime(1992, 12, 12),
                Email = "jeanne123@exemple.fr",
                Password = "95959",
                UserRole = Role.SALARIED
            },

            new User
            {
                Name = "Bartelet",
                Firstname = "Claire",
                Birthdate = new DateTime(1978, 15, 02),
                Email = "vincent_claude@exemple.com",
                Password = "31313",
                UserRole = Role.SALARIED
            },

            new User
            {
                Name = "Zahner",
                Firstname = "Nicolas",
                Birthdate = new DateTime(1979, 21, 08),
                Email = "zahner78@exemple.com",
                Password = "33333",
                UserRole = Role.SALARIED
            },

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



        public void InitializeCra()
        {
            this.Cras.AddRange(
            new Cra { State = CRAState.DRAFT, UserId = 1, CreationDate = new DateTime(2022, 01, 11) },
            new Cra { State = CRAState.SENT, UserId = 2, CreationDate = new DateTime(2023, 03, 11) },
            new Cra { State = CRAState.ALERT, UserId = 1, CreationDate = new DateTime(1992, 03, 11) },
            new Cra { State = CRAState.VALIDATED, UserId = 2, CreationDate = new DateTime(1996, 03, 11) },
            new Cra { State = CRAState.VALIDATED, UserId = 1, CreationDate = new DateTime(2002, 03, 11) });

            this.SaveChanges();
        }
    }
}
