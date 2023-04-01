using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace AlignityApp.Models
{
    public class Dal : IDal
    {
        private BddContext _bddContext;

        public Dal()
        {
            _bddContext = new BddContext();
            this.AddCA();
        }

        public void DeleteCreateDatabase()
        {
            _bddContext.Database.EnsureDeleted();
            _bddContext.Database.EnsureCreated();
        }

        public List<User> GetAllUsers()
        {
            return _bddContext.Users.Where(c => c.IsAvalaible==true).ToList();
        }

        public void CreateUser(User user) { 
            _bddContext.Users.Add(user);
            _bddContext.SaveChanges();
        }

       public void ModifyUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var existingUser = _bddContext.Users.Find(user.Id);
            if (existingUser != null)
            {
                _bddContext.Entry(existingUser).CurrentValues.SetValues(user);
                _bddContext.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
          User user=_bddContext.Users.Find(id);
            user.IsAvalaible = false;
            _bddContext.Users.Update(user);
            _bddContext.SaveChanges();
        }

        public List<User> GetSalariedWithoutManager()
        {
            List<User> users = _bddContext.Users.Where(c => c.IsAvalaible && c.ManagerId !=0 && !c.Manager.IsAvalaible ).ToList();

            return users;   
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

        public Cra GetCraByCraId(int id)
        {
            Cra cra= _bddContext.Cras.Where(c=>c.Id==id).FirstOrDefault();  

            return cra; 
        }

        public List<Cra> GetTeamCras(int id)
        {
            var query = from c in _bddContext.Cras join u in _bddContext.Users on c.UserId equals u.Id where u.ManagerId == id select c;
            List<Cra> cras = query.ToList();
            return cras;
        }

        public List<Activity> FindCra(int id)
        {
            List<Activity> list = _bddContext.Activities.Where(b => b.CraId == id).ToList();
            return list;
        }

        public int FindCraByState(int id)
        {
            var draftState = CRAState.DRAFT;
            List<Cra> list = _bddContext.Cras.Where(b => b.UserId == id && b.State == draftState).ToList();

            return list[0].Id;
        }

        public int CreateCra(Cra cra)
        {
            _bddContext.Cras.Add(cra);
            _bddContext.SaveChanges();
            return cra.Id;
        }

        public int CreateActivity(Models.Activity activity)
        {
            _bddContext.Activities.Add(activity);
            _bddContext.SaveChanges();
            return activity.Id;
        }
        public void DeleteActivity(int activityId)
        {
            var activity = _bddContext.Activities.FirstOrDefault(a => a.Id == activityId);

            if (activity != null)
            {
                _bddContext.Activities.Remove(activity);
                _bddContext.SaveChanges();
            }
        }

        public int ModifyCraState(int idCra)
        {
            var cra = _bddContext.Cras.FirstOrDefault(p => p.Id == idCra);

            if (cra != null)
            {

                cra.State = CRAState.SENT;

                _bddContext.Entry(cra).State = EntityState.Modified;
                _bddContext.SaveChanges();
            }
                return cra.UserId;

        }

        public int ModifyCraStateToInvalid(int idCra,CRAState state)
        {
            var cra = _bddContext.Cras.FirstOrDefault(p => p.Id == idCra);

            if (cra != null)
            {

                cra.State = state;

                _bddContext.Entry(cra).State = EntityState.Modified;
                _bddContext.SaveChanges();
            }
            return cra.UserId;
        }

        public List<User> GetAllManager()
        {
            List<User> user = _bddContext.Users.Where(c => c.UserRole ==Role.MANAGER && c.IsAvalaible==true).ToList();
            return user;
        }

        public List<User> GetUsersByManagerId(int id)
        {
            List<User> users = _bddContext.Users.Where(u => u.ManagerId == id && u.IsAvalaible == true).ToList();
            return users;
        }

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

        public void CreatCommentMannager(Cra cracopy)
        {
            Cra cra = _bddContext.Cras.Find(cracopy.Id);
            cra.Observation = cracopy.Observation;
            _bddContext.Cras.Update(cra);
            _bddContext.SaveChanges();
        }

        public User GetUserFromCra(Cra cra)
        {
            return this.GetUser(cra.UserId);
        }

        public List<Customer> GetAllCustomers()
        {
            return _bddContext.Customers.ToList();
        }

        public List<User> GetAllSalaries(int id)
        {
            return _bddContext.Users.Where(s => s.UserRole == Role.SALARIED && s.ManagerId == id && s.IsAvalaible == true).ToList();
        }

        public void CreateJobInterview(string contractAssignement, int customerId)
        {
            JobInterview interview = new JobInterview()
            {
                ContractAssignement = contractAssignement,
                CustomerId = customerId,
            };

            _bddContext.JobInterviews.Add(interview);
            _bddContext.SaveChanges();
        }

        public int GetJobInterviewId()
        {
            JobInterview jobInterview = _bddContext.JobInterviews.Where(j => j.Contract == StateContract.CREATION).FirstOrDefault();
            if (jobInterview != null)
            {
                return jobInterview.Id;
            }
            return 0; 
        }

        public List<JobInterview> GetAllJobInterviews()
        {
            return _bddContext.JobInterviews.Where(j => j.Contract == StateContract.INTERVIEW).ToList();
        }

        public List<User> GetSalariedByCustomer(int CustomerId)
        {
            var query = from j in _bddContext.JobInterviews 
                        join sj in _bddContext.SJobInterviews 
                        on j.Id equals sj.JobInterviewId
                        join u in _bddContext.Users
                        on sj.SalariedId equals u.Id
                        where j.CustomerId == CustomerId && j.Contract == StateContract.INTERVIEW select u;

            List<User> jobInterviews = query.ToList();

            if (query != null)
            {
                return jobInterviews;
            }
            return new List<User>();
        }

        /*public List<SJobInterview> GetAllSJobInterviews()
        {
            var query = _bddContext.SJobInterviews.ToList();
            if (query != null)
            {
                return query;
            }
            return new List<SJobInterview>();
        }*/

        public void ModifySJobInterview(int salariedId)
        {
            SJobInterview sInterview = new SJobInterview()
            {
                SalariedId = salariedId,
                JobInterviewId = this.GetJobInterviewId()
            };
            
            _bddContext.SJobInterviews.Add(sInterview);
            _bddContext.SaveChanges();
            
        }

        public List<SJobInterview> GetSalariesByJId(int jobInterviewId)
        {
            List<SJobInterview> sJobList = _bddContext.SJobInterviews.Where(sji => sji.JobInterviewId == jobInterviewId).ToList();
            if (sJobList != null)
            {
                return sJobList;
            }
            return new List<SJobInterview>();
        }

        public JobInterview GetJIById(int jobInterviewId)
        {
            JobInterview jobInterview = _bddContext.JobInterviews.Where(ji => ji.Id == jobInterviewId).FirstOrDefault();
            if (jobInterview != null)
            {
                return jobInterview;
            }
            return new JobInterview();
        }

        public List<User> GetSalariesById(List<SJobInterview> sJobList)
        {
            List<User> listSalaried = new List<User>();
            foreach (var item  in sJobList)
            {
                listSalaried.Add(this.GetUser(item.SalariedId));
            }
            return listSalaried;
        }

        public void UpdateJobInterview(JobInterview jobInterview)
        {
            jobInterview.InterviewDate = DateTime.Now;
            jobInterview.Contract = StateContract.INTERVIEW;
            _bddContext.JobInterviews.Update(jobInterview);
            _bddContext.SaveChanges();
        }

        public Customer GetCustomerById(int customerId)
        {
            return _bddContext.Customers.Where(c => c.Id == customerId).FirstOrDefault();
        }

        public void UpdateTJM(int salariedId, int tjm)
        {
            User salaried = this.GetUser(salariedId);

            if (salaried != null)
            {
                salaried.RateTjm = tjm;
                _bddContext.Users.Update(salaried);
                _bddContext.SaveChanges();
            }
        }

        public List<Activity> GetAllActivities()
        {
            return _bddContext.Activities.ToList();
        }

        public List<Activity> GetUserActivities(User salaried)
        {
            var query = from a in _bddContext.Activities 
                        join c in _bddContext.Cras
                        on a.CraId equals c.Id
                        where c.UserId == salaried.Id
                        select a;
            
            return query.ToList();
        }

        public int HoursByActivityTypesBySalaried(ActivityTypes activityType, User salaried)
        {
            int count = 0;
            foreach (var activity in this.GetUserActivities(salaried))
            {
                if (activity.Type == activityType)
                {
                    count += activity.Duration;
                }
            }
            return count;
        }

        public int HoursByActivityTypes(ActivityTypes activityType, List<User> salaries)
        {
            int count = 0;
            foreach (var salaried in salaries)
            {
                count += this.HoursByActivityTypesBySalaried(activityType, salaried);
            }
            return count;
        }

        public int SalariedHoursProduction(User salaried)
        {
            int count = 0;
            foreach (var activity in this.GetUserActivities(salaried))
            {
                if (activity.Type == ActivityTypes.SERVICE)
                {
                    count += activity.Duration;
                }
            }
            return count;
        }

        public int SalariedTotalHours(User salaried)
        {
            int count = 0;
            foreach (var activity in this.GetUserActivities(salaried))
            {
                count += activity.Duration;
            }
            return count;
        }

        public int TotalHours(List<User> salaries)
        {
            int count = 0;
            foreach (var salaried in salaries)
            {
                count += this.SalariedTotalHours(salaried);
            }
            return count;
        }

        private void AddCA()
        {
            List<User> salaries = this.GetAllUsers();
            foreach(var salaried in salaries)
            {
                salaried.CA = this.SalariedHoursProduction(salaried) * salaried.RateTjm;
            }
            _bddContext.SaveChanges();
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
