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
        //récupérer un Cra par id de cra
        Cra GetCraByCraId(int id);
        //récupérer une liste des activités déjà enregistrées par id de cra
        List<Activity> FindCra(int id);
        //récupérer id de cra qui vient etre cré
        int CreateCra(Cra cra);
        //récupérer id d'un cra par id d'utilisateur qui est en état de Brouiilon
        int FindCraByState(int id);
        //Création d'une activité en récupérant son id
        int CreateActivity(Activity activity);
        //Supprimer d'une activité par id d'activité
        void DeleteActivity(int activityId);
        //Modifier l'état du cra par idCra
        int ModifyCraState(int idCra);
        //Modifier l'état du cra par idCra en état non valide
        int ModifyCraStateToInvalid(int idCra, CRAState state);
        //récupérer une liste de manager
        List<User>GetAllManager();
        //Créer un utilisateur par admin
        void CreateUser(User user);
        //Modify un utilisateur par admin
        void ModifyUser(User user); 
        //Supprimer un utilisateur en changeant son paramètre IsAvalaible
        void DeleteUser(int id);    
        //récupérer une liste de salariés sans manager attribué
        List<User>GetSalariedWithoutManager(); 
        //récupérer une liste de salariés sans manager attribué
        void CreatCommentMannager(Cra cra);

        User Authentifier(string email, string password);
        User GetUser(int id);
        List<User> GetUsersByManagerId(int id);
        User GetUserFromCra(Cra cra);
        List<Customer> GetAllCustomers();
        List<User> GetAllSalaries(int id);
        void CreateJobInterview(string contractAssignement, int customerid);
        void ModifySJobInterview(int salariedId);
        List<SJobInterview> GetSalariesByJId(int jobInterviewId);
        JobInterview GetJIById(int jobInterviewId);
        void UpdateJobInterview(JobInterview jobInterview);
        Customer GetCustomerById(int customerId);
        List<JobInterview> GetAllJobInterviews();
        List<User> GetSalariedByCustomer(int CustomerId);
        List<User> GetSalariesById(List<SJobInterview> sJobList);
        void UpdateTJM(int salariedId, int tjm);
        List<Activity> GetAllActivities();
        int HoursByActivityTypesBySalaried(ActivityTypes activityType, User salaried);
        int HoursByActivityTypes(ActivityTypes activityType, List<User> salaries);
        int SalariedHoursProduction(User salaried);
        int SalariedTotalHours(User salaried);
        int TotalHours(List<User> salaries);
    }
}
