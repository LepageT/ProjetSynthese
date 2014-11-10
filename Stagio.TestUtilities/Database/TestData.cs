using System;
using System.Collections.Generic;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Utilities.Encryption;

namespace Stagio.TestUtilities.Database
{
    public class TestData
    {
        #region Coordinator1
        static public ApplicationUser coordinator1
        {
            get
            {
                var user = new ApplicationUser()
                {

                    Roles = new List<UserRole>()
                   {
                       new UserRole() {RoleName = RoleName.Coordinator},
                   },
                    Password = PasswordHash.CreateHash("test4test"),
                    Email = "coordonnateur@stagio.com",
                    FirstName = "Jean-Dominic",
                    LastName = "Rousseau",
                    Active = true
                };

                user.UserName = user.Email;
                return user;
            }
        }
        #endregion
        #region Coordinator2

        public static Coordinator coordinator2
        {
            get
            {
                var coordonnate = new Coordinator()
                {
                    Roles = new List<UserRole>()
                   {
                       new UserRole() {RoleName = RoleName.Coordinator},
                   },
                    Password = PasswordHash.CreateHash("123456QW"),
                    Email = "admin@admin.com",
                    FirstName = "Nathalie",
                    LastName = "Leduc",
                    Active = true
                };
                coordonnate.UserName = coordonnate.Email;
                return coordonnate;
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
                    Password = PasswordHash.CreateHash("qwerty12"),
                    Active = true,
                    Id = 1
                };
                
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
                    Email = "1234@stagio.web",
                    Password = PasswordHash.CreateHash("qwerty98")
                };

                student.UserName = student.Matricule.ToString();
                return student;
            }
        }
        #endregion
        #region Student3 - Compte non activé.

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
                    FirstName = "Denis",
                    LastName = "Lebrun",
                    Matricule = 1031739,
                };

                student.UserName = student.Matricule.ToString();
                return student;
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

        #region ContactEnterprise1 - Quentin Tarantino

        static public ContactEnterprise contactEnterprise1
        {
            get
            {
                var enterprise = new ContactEnterprise()
                {
                    Roles = new List<UserRole>()
                             {
                                 new UserRole() {RoleName = RoleName.ContactEnterprise}
                             },
                    EnterpriseName = "L'industrielle Alliance",
                    FirstName = "Quentin",
                    LastName = "Tarantino",
                    Telephone = "123-456-7890",
                    Email = "blabla@hotmail.com",
                    Password = PasswordHash.CreateHash("qwerty12"),
                    Active = false
                };
                enterprise.UserName = enterprise.Email;
                return enterprise;
            }
        }
        #endregion
        #region ContactEnterprise3 - activated

        static public ContactEnterprise contactEnterprise3
        {
            get
            {
                var enterprise = new ContactEnterprise()
                {
                    Roles = new List<UserRole>()
                             {
                                 new UserRole() {RoleName = RoleName.ContactEnterprise}
                             },
                    EnterpriseName = "MI6",
                    FirstName = "James",
                    LastName = "Bond",
                    Telephone = "007-007-7000",
                    Email = "bond.james.007@hotmail.com",
                    Password = PasswordHash.CreateHash("qwerty12"),
                    Active = true
                };
                enterprise.UserName = enterprise.Email;
                return enterprise;
            }
        }
        #endregion
        #region ContactEnterprise2 - Christopher Nolan

        static public ContactEnterprise contactEnterprise2
        {
            get
            {
                var enterprise = new ContactEnterprise()
                {
                    EnterpriseName = "Stagio",
                    FirstName = "Christopher",
                    LastName = "Nolan",
                    Telephone = "123-456-7890",
                    Email = "toto@hotmail.com",
                    Password = PasswordHash.CreateHash("qwerty98"),
                    Active = false
                };
                enterprise.UserName = enterprise.Email;

                return enterprise;
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
                    Id = 1,
                    NbApply = 1,
                    LimitDate = DateTime.Now,
                    PublicationDate = DateTime.Now,
                    Status = 0,
                    NbrStagiaire = 3,
                    StageTitle = "Apprentis",
                    CompanyName = "Bonbon inc",
                    Adresse = "1234 rue des bonbons, Québec",
                    ResponsableToName = "Robert",
                    ResponsableToEmail = "robert@bonbon.com",
                    ResponsableToPhone = "432-432-4324",
                    ResponsableToPoste = "333",
                    ResponsableToTitle = "CEO",
                    ContactToName = "Luc",
                    ContactToEmail = "luc@bonbon.com",
                    ContactToPhone = "123-223-3456",
                    ContactToPoste = "2a",
                    ContactToTitle = "Maitre des bonbons",
                    StageDescription = "Faire des bonbons, Manger des bonbons...",
                    EnvironnementDescription = "Sucre, Mélangeur",
                    SubmitToEmail = "robert@bonbon.com",
                    SubmitToName = "Robert LeBrun",
                    SubmitToTitle = "CEO"
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
                    PublicationDate = DateTime.Now,
                    CompanyName = "Musique inc",
                    Adresse = "1234 rue de la guitare, Québec",
                    ResponsableToName = "Denyse Gilbert",
                    ResponsableToTitle = "Coordonnatrice aux développements",
                    ResponsableToPhone = "656-2131",
                    ResponsableToPoste = null,
                    ResponsableToEmail = "Denyse.Gilbert",
                    StageDescription = "Notre centre dévoloppe des applications pédagogiques multimédias pour" +
                                        " l'enseignement et l'apprentissage dans le domaine dede la musique.",
                    EnvironnementDescription = "Poste de travail Windows 8.1, Visual Studio 2013, SQL Server",
                    StageTitle = "Programmeur C++",
                    NbrStagiaire = 2,
                    StagiaireIfKnew = "",
                    SubmitToName = "Denyse Gilbert",
                    SubmitToTitle = "Coordinatrice aux développements APTIC",
                    SubmitToEmail = "Denyse.Gilbert@musiqueinc.co",
                    LimitDate = new DateTime(2008, 12, 10),
                    Status = 0
                };

                return stage;
            }
        }

        #endregion
        #region Stage 3 - Complet

        static public Stage stage3
        {
            get
            {
                var stage = new Stage()
                {
                    PublicationDate = new DateTime(2008, 9, 28, 16, 5, 7, 123),
                    CompanyName = "Centre de développement pédagogique",
                    Adresse = "Faculté de médecine, 3358 B pav. Vandry, Université Laval, G1K 7P4",
                    ResponsableToName = "Denyse Gilbert",
                    ResponsableToTitle = "Coordonnatrice aux développements",
                    ResponsableToPhone = "656-2131",
                    ResponsableToPoste = null,
                    ResponsableToEmail = "Denyse.Gilbert",
                    StageDescription = "Notre centre de dévoloppe des applications pédagogiques multimédias pour" +
                                        " l'enseignement et l'apprentissage dans le domaine des sciences de la santé au niveau" +
                                        " universitaire. Nous avons remporté le prix du Ministre de l'éducation pour notre application" +
                                        " pédagogique en cardiopédiatrie ainsi que de nombreux prix d'excelloence en développement " +
                                        "d'applications pédagogiques multimédias",
                    EnvironnementDescription = "asdkjlh wef yuijshd jefy wfu scj hldsjyt wu jhlgyaej hhj uiytolral  aluir" +
                                                " laksdjh z;l sdutypa fhhjyla GFHELA /n kkhjgdkhjfL GFOIA /n saut de ligne",
                    StageTitle = "patate",
                    NbrStagiaire = 2,
                    StagiaireIfKnew = "",
                    SubmitToName = "Denyse Gilbert",
                    SubmitToTitle = "Coordinatrice aux développements APTIC",
                    SubmitToEmail = "Denyse.Gilbert",
                    LimitDate = new DateTime(2008, 12, 10),
                    Status = StageStatus.Accepted


                };

                return stage;
            }
        }

        #endregion
        #region Stage 4

        static public Stage stage4
        {
            get
            {
                var stage = new Stage()
                {
                    PublicationDate = DateTime.Now,
                    CompanyName = "Coveo",
                    Adresse = "1234 rue du Web, Québec",
                    ResponsableToName = "Serge Lavoie",
                    ResponsableToTitle = "Coordonnateur aux développements",
                    ResponsableToPhone = "656-2131",
                    ResponsableToPoste = null,
                    ResponsableToEmail = "serge.lavoie@email.com",
                    StageDescription = "Notre centre dévoloppe des applications web",
                    EnvironnementDescription = "Poste de travail Windows 8.1/Mac OS X, Logiciel Adobe CS6, SQL Server, HTML, CSS",
                    StageTitle = "Programmeur Web",
                    NbrStagiaire = 2,
                    StagiaireIfKnew = "",
                    SubmitToName = "Serge Lavoie",
                    SubmitToTitle = "Coordinateur aux développements Web",
                    SubmitToEmail = "serge.lavoie@email.com",
                    LimitDate = new DateTime(2008, 12, 10),
                    Status = 0
                };

                return stage;
            }
        }

        #endregion

        #region Apply 1

        static public Apply apply1
        {
            get
            {
                var apply = new Apply()
                {
                    IdStage = 1,
                    IdStudent = 1,
                    Status = Status.Accepted,
                    Cv = "Le cv de l'étudiant",
                    Letter = "La lettre de présentation"
                };

                return apply;
            }
        }

        #endregion
        #region Apply 2

        static public Apply apply2
        {
            get
            {
                var apply = new Apply()
                {
                    IdStage = 4,
                    IdStudent = 1,
                    Cv = "Le cv de l'étudiant",
                    Letter = "La lettre de présentation."
                };

                return apply;
            }
        }

        #endregion


    }


}
