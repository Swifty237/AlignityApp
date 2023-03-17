using System;
using System.Collections.Generic;
using System.Linq;

namespace AlignityApp.Models
{
    public class Dal : IDal
    {
        private BddContext _bddContext;

        public Dal()
        {
            _bddContext = new BddContext();
        }

        public void DeleteCreateDatabase()
        {
            _bddContext.Database.EnsureDeleted();
            _bddContext.Database.EnsureCreated();
        }

        public List<User> GetAllUsers()
        {
            return _bddContext.Users.ToList();
        }
        public int CreateUser(
            string name, 
            string firstname,
            DateTime birthdate,
            string email,
            string password, 
            Role role
            )
        {
            User user = new User { 
                Name = name, 
                Firstname = firstname,
                Birthdate = birthdate,
                Email = email, 
                Password = password, 
                CreationDate = DateTime.Now, 
                UserRole = role  
                };

            _bddContext.Users.Add(user);
            _bddContext.SaveChanges();
            return user.Id;
        }

        public List<Cra> GetAllCras()
        {
            return _bddContext.Cras.ToList();
        }

        public int CreateCra(int userId)
        {
            Cra cra = new Cra() { 
                State = CRAState.DRAFT, 
                CreationDate = DateTime.Now, 
                UserOfCraId = userId  
            };

            _bddContext.Cras.Add(cra);
            _bddContext.SaveChanges();
            return cra.Id;
        }

        public void ModifyCra(int craId, CRAState state)
        {
            Cra cra = _bddContext.Cras.Find(craId);

            if (cra != null && cra.UserOfCra != null)
            {
                cra.State = state;
                _bddContext.SaveChanges();
            }
        }

        public void Dispose()
        {
            _bddContext.Dispose();
        }
    }
}
