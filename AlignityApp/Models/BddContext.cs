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
            optionsBuilder.UseMySql("server=localhost;user id=root;database=alignity_bdd");
        }

        public void InitializeDb()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();

            this.Users.AddRange(

                new User { 
                    Name ="dupont", 
                    Firstname = "thomas", 
                    Birthdate = new DateTime(1974, 10, 01), 
                    Email = "thomas@gmail.com", 
                    Password = "1234", 
                    UserRole = Role.SALARIED 
                },

                new User
                {
                    Name = "John",
                    Firstname = "Doe",
                    Birthdate = new DateTime(2000, 07, 26),
                    Email = "john_doe@exemple.com",
                    Password = "5678",
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
                    Password = "1231",
                    UserRole = Role.ADMINISTRATOR
                });

            /*            this.Cras.AddRange(
                            new Cra {},
                            new Cra {},
                            new Cra { },
                            new Cra { },
                            new Cra { },
                            new Cra { }
                        );*/

/*            this.Activities.AddRange(
                new Activity() { },
                new Activity() { },
                new Activity() { },
                new Activity() { }
            );*/

/*            this.Customers.AddRange(
                new Customer { },
                new Customer { },
                new Customer { }
            );*/

            this.SaveChanges();
        }
    }
}
