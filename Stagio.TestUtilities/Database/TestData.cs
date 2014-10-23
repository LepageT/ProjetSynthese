using System;
using System.Collections.Generic;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Utilities.Encryption;

namespace Stagio.TestUtilities.Database
{
    public class TestData
    {
        #region User (coordonnateur)
        static public ApplicationUser applicationUser
        {
            get
            {
                var user = new ApplicationUser()
                {

                    Roles = new List<UserRole>()
                   {
                       new UserRole() {RoleName = RoleName.Coordinator}
                   },
                    Password = PasswordHash.CreateHash("test4test"),
                    UserName = "coordonnateur@stagio.com",
                    Name = "Super admin coordonnateur Tux"
                };
                return user;
            }
        }
        #endregion

        #region Student1 - Quentin Tarantino

        static public Student student1
        {
            get
            {
                var student = new Student()
                {
                    Roles = new List<UserRole>()
                             {
                                 new UserRole() {RoleName = RoleName.Student}
                             },
                    FirstName = "Quentin",
                    LastName = "Tarantino",
                    Telephone = "123-456-7890",
                    Matricule = 1234567,
                    Password = PasswordHash.CreateHash("qwerty12")
                };

                student.Name = student.FirstName + " " + student.LastName;
                student.UserName = student.Matricule.ToString();
                return student;
            }
        }
        #endregion

        #region Student2 - Christopher Nolan

        static public Student student2
        {
            get
            {
                var student = new Student()
                {
                    Roles = new List<UserRole>()
                             {
                                 new UserRole() {RoleName = RoleName.Student}
                             },
                    FirstName = "Christopher",
                    LastName = "Nolan",
                    Telephone = "123-456-7890",
                    Matricule = 1234560,
                    Password = PasswordHash.CreateHash("qwerty98")
                };

                student.Name = student.FirstName + " " + student.LastName;
                student.UserName = student.Matricule.ToString();
                return student;
            }
        }
        #endregion
        #region Student3 - Thomas Lepage

        static public Student student3
        {
            get
            {
                var student = new Student()
                {
                    Roles = new List<UserRole>()
                             {
                                 new UserRole() {RoleName = RoleName.Student}
                             },
                    FirstName = "Thomas",
                    LastName = "Lepage",
                    Matricule = 1031739,
                };

                student.Name = student.FirstName + " " + student.LastName;
                student.UserName = student.Matricule.ToString();
                return student;
            }
        }
        #endregion
        #region Coordinator1

        public static Coordinator coordonnateur1
        {
            get
            {
                var coordonnate = new Coordinator()
                {
                    Id = 1,
                    FirstName = "Test",
                    LastName = "Test2",
                    Password = PasswordHash.CreateHash("123456QW"),
                    Email = "admin@admin.com"
                };

                return coordonnate;
            }

        }
        #endregion
        #region Invitation 1

        static public Invitation invitation1
        {
            get
            {
                var invitation = new Invitation()
                {
                    Id = 1,
                    Email = "testemail@admin.com",
                    Token = "123456"
                };

                return invitation;
            }
        }

        #endregion

        #region Stage 1

        static public Stage stage1
        {
            get
            {
                var stage = new Stage()
                {
                    LimitDate = DateTime.Now,
                    PublicationDate = DateTime.Now,
                    AcceptedByCoordinator = false,
                    NbrStagiaire = 3,
                    CompanyName = "Bonbon inc",
                    Adresse = "1234 rue des bonbons, Québec"   
                };

                return stage;
            }
        }

        #endregion

        #region Stage 2

        static public Stage stage2
        {
            get
            {
                var stage = new Stage()
                {
                   LimitDate = DateTime.Now,
                    PublicationDate = DateTime.Now,
                    AcceptedByCoordinator = true,
                    NbrStagiaire = 2,
                    CompanyName = "Musique inc",
                    Adresse = "1234 rue de la guitare, Québec"
                };

                return stage;
            }
        }

        #endregion
    }
}
