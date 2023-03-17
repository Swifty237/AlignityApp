using AlignityApp.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestApp
{
    public class UnitTest1
    {
       /* [Fact]
        public void CreateUser_Verification()
        {
            // Nous ouvrons un connexion � la db
            using (Dal dal = new Dal())
            {
                // Nous supprimons et cr�ons de nouveau la db avant le test
                dal.DeleteCreateDatabase();
                // Nous cr�ons un User
                dal.CreateUser("dupont", "thomas", new DateTime(1974, 10, 01), "thomas@gmail.com", "1234", Role.SALARIED);
                // Nous v�rifions que le User a bien �t� cr��
                List<User> users = dal.GetAllUsers();
                Assert.NotNull(users);
                Assert.Single(users);
                Assert.Equal("dupont", users[0].Name);
                Assert.Equal("thomas", users[0].Firstname);
                Assert.Equal(new DateTime(1974, 10, 01), users[0].Birthdate);
                Assert.Equal("thomas@gmail.com", users[0].Email);
                Assert.Equal("1234", users[0].Password);
                Assert.Equal(Role.SALARIED, users[0].UserRole);
            }
        }

        [Fact]
        public void CreateCra_Verification()
        {
            // Nous ouvrons une connexion � la db
            using (Dal dal = new Dal())
            {
                // Nous supprimons et cr�ons de nouveau la db avant le test
                dal.DeleteCreateDatabase();
                int userId = dal.CreateUser("John", "Doe", new DateTime(2000, 07, 26), "john_doe@exemple.com", "5678", Role.SALARIED);
                // Nous cr�ons un CRA
                dal.CreateCra(userId);

                // nous v�rifions que le CRA a bien �t� cr��
                List<Cra> cras = dal.GetAllCras();
                Assert.NotNull(cras);
                Assert.Single(cras);
                Assert.Equal(CRAState.DRAFT, cras[0].State);
            }
        }

        [Fact]
        public void ModifyCra_Verification()
        {
            // Ouverture d'une connexion � la db
            using (Dal dal = new Dal())
            {
                // Nous supprimons et cr�ons de nouveau la db avant le test
                dal.DeleteCreateDatabase();
                // Nous cr�ons un User
                int userId = dal.CreateUser("Sylvie", "Ebou�", new DateTime(1987, 04, 18), "eboue_sylivie@exemple.com", "5678", Role.SALARIED);
                // Nous cr�ons un CRA
                int craId = dal.CreateCra(userId);

                // Nous modifions l' �tat du CRA, (DRAFT � la cr�ation)
                dal.ModifyCra(craId, CRAState.SENT);

                // nous v�rifions que le CRA a bien �t� modifi�
                List<Cra> cras = dal.GetAllCras();
                Assert.NotNull(cras);
                Assert.Single(cras);
                Assert.Equal(CRAState.SENT, cras[0].State);
            }
        }*/
    }
}
