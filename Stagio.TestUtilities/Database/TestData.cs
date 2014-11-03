using System;
using System.Collections.Generic;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Utilities.Encryption;

namespace Stagio.TestUtilities.Database
{
    public class TestData
    {
        #region User (Test user, this user has all access for testing purpose)
        static public ApplicationUser applicationUser
        {
            get
            {
                var user = new ApplicationUser()
                {

                    Roles = new List<UserRole>()
                   {
                       new UserRole() {RoleName = RoleName.Coordinator},
                       new UserRole() {RoleName = RoleName.Student},
                       new UserRole() {RoleName = RoleName.ContactEnterprise}
                   },
                    Password = PasswordHash.CreateHash("test4test"),
                    UserName = "coordonnateur@stagio.com",
                    FirstName = "Super admin coordonnateur Tux",
                    LastName = " ",
                    Active = true
                };
                user.Email = user.UserName;
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
                    Password = PasswordHash.CreateHash("qwerty12"),
                    Active = true
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
                coordonnate.UserName = coordonnate.Email;
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

        #region ContactEnterprise1 - Quentin Tarantino

        static public ContactEnterprise contactEnterprise1
        {
            get
            {
                var enterprise = new ContactEnterprise()
                {
                    Id = 1,
                    Roles = new List<UserRole>()
                             {
                                 new UserRole() {RoleName = RoleName.ContactEnterprise}
                             },
                    EnterpriseName = "test",
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
                    Id = 1007,
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
                    Id = 2,
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
                    StageTitle = "[Inserer titre ici]",
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
                    ContactToPoste = "2",
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
                   LimitDate = DateTime.Now,
                    PublicationDate = DateTime.Now,
                    Status = 1,
                    NbrStagiaire = 2,
                    StageTitle = "[Inserer titre ici]",
                    CompanyName = "Musique inc",
                    Adresse = "1234 rue de la guitare, Québec"
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
                    LimitDate = new DateTime(2008,12,10),
                    Status = 0
                    
                    
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
                    LimitDate = DateTime.Now,
                    PublicationDate = DateTime.Now,
                    Status = 1,
                    NbrStagiaire = 2,
                    StageTitle = "Programmeur Web",
                    CompanyName = "Coveo",
                    Adresse = "1234 rue de la guitare, Québec"
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
                    Cv = "jfdhvldshgsdljhk",
                    Letter = "xljvbvdsve efhnboseif ierhgtbcwl gkf kg fdi"
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
