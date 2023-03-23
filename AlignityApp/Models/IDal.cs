using System.Collections.Generic;
using System;

namespace AlignityApp.Models
{
    public interface IDal : IDisposable
    {
        void DeleteCreateDatabase();
        List<User> GetAllUsers();
        List<Cra> GetAllCras();
        List<Cra> GetCrasByUserId(int id);
        List<Activity> FindCra(int id);
        int CreateCra(Cra cra);
		User Authentifier(string email, string password);
        User GetUser(int id);
    }
}
