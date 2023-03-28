using System.Collections.Generic;
using System;

namespace AlignityApp.Models
{
    public interface IDal : IDisposable
    {
        void DeleteCreateDatabase();
        //récupérer une liste tous les utilisateurs
        List<User> GetAllUsers();
        //récupérer une liste de tous les Cras
        List<Cra> GetAllCras();
        //récupérer une liste des cras par id d'utilisateur
        List<Cra> GetCrasByUserId(int id);
        //récupérer une liste des activités déjà enregistrées par id de cra
        List<Activity> FindCra(int id);
        //récupérer id de cra qui vient etre cré
        int CreateCra(Cra cra);
        //récupérer id d'un cra par id d'utilisateur qui est en état de Brouiilon
        int FindCraByState(int id);
        User Authentifier(string email, string password);
        User GetUser(int id);
        List<User> GetUsersByManagerId(int id);
        User GetUserFromCra(Cra cra);
        List<Customer> GetAllCustomers();
        List<User> GetAllSalaries(int id);
        /*int CreateJobInterview(string contractAssignement, Customer customer);*/
        /*int ModifyJobInterview(List<User> salaries);*/
    }
}
