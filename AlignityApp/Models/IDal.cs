using System.Collections.Generic;
using System;

namespace AlignityApp.Models
{
    public interface IDal : IDisposable
    {
        void DeleteCreateDatabase();
        List<User> GetAllUsers();
        int CreateUser(
            string name, 
            string firstname,
            DateTime birthdate,
            string email,
            string password,
            Role role
            );
        List<Cra> GetAllCras();
        List<Cra> GetCrasByUserId(int id);
        List<Cra> GetTeamCras(int id);
        User Authentifier(string email, string password);
        User GetUser(int id);
        List<User> GetUsersByManagerId(int id);
    }
}
