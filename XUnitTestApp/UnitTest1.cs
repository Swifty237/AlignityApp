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
            // Nous ouvrons un connexion à la db
            using (Dal dal = new Dal())
            {
                // Nous supprimons et créons de nouveau la db avant le test
                dal.DeleteCreateDatabase();
                // Nous créons un User
                dal.CreateUser("dupont", "thomas", new DateTime(1974, 10, 01), "thomas@gmail.com", "1234", Role.SALARIED);
                // Nous vérifions que le User a bien été créé
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
            // Nous ouvrons une connexion à la db
            using (Dal dal = new Dal())
            {
                // Nous supprimons et créons de nouveau la db avant le test
                dal.DeleteCreateDatabase();
                int userId = dal.CreateUser("John", "Doe", new DateTime(2000, 07, 26), "john_doe@exemple.com", "5678", Role.SALARIED);
                // Nous créons un CRA
                dal.CreateCra(userId);

                // nous vérifions que le CRA a bien été créé
                List<Cra> cras = dal.GetAllCras();
                Assert.NotNull(cras);
                Assert.Single(cras);
                Assert.Equal(CRAState.DRAFT, cras[0].State);
            }
        }

        [Fact]
        public void ModifyCra_Verification()
        {
            // Ouverture d'une connexion à la db
            using (Dal dal = new Dal())
            {
                // Nous supprimons et créons de nouveau la db avant le test
                dal.DeleteCreateDatabase();
                // Nous créons un User
                int userId = dal.CreateUser("Sylvie", "Eboué", new DateTime(1987, 04, 18), "eboue_sylivie@exemple.com", "5678", Role.SALARIED);
                // Nous créons un CRA
                int craId = dal.CreateCra(userId);

                // Nous modifions l' état du CRA, (DRAFT à la création)
                dal.ModifyCra(craId, CRAState.SENT);

                // nous vérifions que le CRA a bien été modifié
                List<Cra> cras = dal.GetAllCras();
                Assert.NotNull(cras);
                Assert.Single(cras);
                Assert.Equal(CRAState.SENT, cras[0].State);
            }
        }*/
    }
}
