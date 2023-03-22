using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

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

        public List<Cra> GetCrasByUserId(int id)
        {
            List<Cra> cras = _bddContext.Cras.Where(c => c.UserId == id).ToList();
            return cras;
        }

        public List<User> GetUsersByManagerId(int id)
        {
            List<User> users = _bddContext.Users.Where(u => u.ManagerId == id).ToList();
            return users;
        }

        //public int CreateCra(int userId)
        //{
        //    Cra cra = new Cra() { 
        //        State = CRAState.DRAFT, 
        //        CreationDate = DateTime.Now, 
        //        UserOfCraId = userId  
        //    };

        //    _bddContext.Cras.Add(cra);
        //    _bddContext.SaveChanges();
        //    return cra.Id;
        //}

        //public void ModifyCra(int craId, CRAState state)
        //{
        //    Cra cra = _bddContext.Cras.Find(craId);

        //    if (cra != null && cra.UserOfCra != null)
        //    {
        //        cra.State = state;
        //        _bddContext.SaveChanges();
        //    }
        //}

        public User Authentifier(string email, string password)
        {
            //string motDePasse = EncodeMD5(password);
            User user = this._bddContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            return user;

        }
        public User GetUser(int id)
        {
            return this._bddContext.Users.Find(id);
        }

        public User GetUser(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
            {
                return this.GetUser(id);
            }
            return null;
        }

        public static string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "ChoixResto" + motDePasse + "ASP.NET MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }

        public void Dispose()
        {
            _bddContext.Dispose();
        }
    }
}
