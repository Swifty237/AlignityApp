﻿using System.Collections.Generic;
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
        int CreateCra(int userId);
        void ModifyCra(int id, CRAState state);
    }
}
