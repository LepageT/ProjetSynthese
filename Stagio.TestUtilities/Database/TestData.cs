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
        static public Coordinator coordinator1
        {
            get
            {
                var user = new Coordinator()
                {

                    Roles = new List<UserRole>()
                   {
                       new UserRole() {RoleName = RoleName.Coordinator},
                   },
                    Password = PasswordHash.CreateHash("test4test1"),
                    Email = "coordonnateur@stagio.com",
                    FirstName = "Jean-Dominic",
                    LastName = "Rousseau",
                    Telephone = "819-764-9999",
                    Active = true,
                    Id = 4
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
                    Telephone = "581-999-4444",
                    Active = true
                };
                coordonnate.UserName = coordonnate.Email;
                return coordonnate;
            }

        }

        #endregion

        #region Student1 - Quentin Tarantino

        public static Student student1
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

        public static Student student2
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
                    Telephone = "123-456-7891",
                    Matricule = 1234560,
                    Email = "1234@stagio.web",
                    Password = PasswordHash.CreateHash("qwerty98"),
                    Active = true
                };

                student.UserName = student.Matricule.ToString();
                return student;
            }
        }

        #endregion

        #region Student3 - Compte non activé.

        public static Student student3
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

        public static Invitation invitation1
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

        public static ContactEnterprise contactEnterprise1
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
                    Telephone = "123-456-7892",
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

        public static ContactEnterprise contactEnterprise3
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
                    Active = true,
                    Id = 6
                };
                enterprise.UserName = enterprise.Email;
                return enterprise;
            }
        }

        #endregion

        #region ContactEnterprise2 - Christopher Nolan

        public static ContactEnterprise contactEnterprise2
        {
            get
            {
                var enterprise = new ContactEnterprise()
                {
                    EnterpriseName = "Stagio",
                    FirstName = "Christopher",
                    LastName = "Nolan",
                    Telephone = "123-456-7893",
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

        public static Stage stage1
        {
            get
            {
                var stage = new Stage()
                {
                    NbApply = 1,
                    LimitDate = DateTime.Today.AddDays(8).ToShortDateString(),
                    PublicationDate = DateTime.Now.ToString(),
                    Status = StageStatus.Accepted,
                    NbrStagiaire = 3,
                    StageTitle = "Apprentis",
                    CompanyName = "MI6",
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

        public static Stage stage2
        {
            get
            {
                var stage = new Stage()
                {
                    PublicationDate = DateTime.Now.ToString(),
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
                    LimitDate = DateTime.Today.AddDays(30).ToShortDateString(),
                    Status = StageStatus.New
                };

                return stage;
            }
        }

        #endregion

        #region Stage 3 - Complet

        public static Stage stage3
        {
            get
            {
                var stage = new Stage()
                {
                    
                    PublicationDate = new DateTime(2008, 9, 28, 16, 5, 7, 123).ToString(),
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
                    EnvironnementDescription =
                        "asdkjlh wef yuijshd jefy wfu scj hldsjyt wu jhlgyaej hhj uiytolral  aluir" +
                                                " laksdjh z;l sdutypa fhhjyla GFHELA /n kkhjgdkhjfL GFOIA /n saut de ligne",
                    StageTitle = "Programmeur C++",
                    NbrStagiaire = 2,
                    StagiaireIfKnew = "",
                    SubmitToName = "Denyse Gilbert",
                    SubmitToTitle = "Coordinatrice aux développements APTIC",
                    SubmitToEmail = "Denyse.Gilbert",
                    LimitDate = DateTime.Today.AddDays(10).ToShortDateString(),
                    Status = StageStatus.Accepted


                };

                return stage;
            }
        }

        #endregion

        #region Stage 4

        public static Stage stage4
        {
            get
            {
                var stage = new Stage()
                {
                    PublicationDate = DateTime.Now.ToString(),
                    CompanyName = "Coveo",
                    Adresse = "1234 rue du Web, Québec",
                    ResponsableToName = "Serge Lavoie",
                    ResponsableToTitle = "Coordonnateur aux développements",
                    ResponsableToPhone = "656-2131",
                    ResponsableToPoste = null,
                    ResponsableToEmail = "serge.lavoie@email.com",
                    StageDescription = "Notre centre dévoloppe des applications web",
                    EnvironnementDescription =
                        "Poste de travail Windows 8.1/Mac OS X, Logiciel Adobe CS6, SQL Server, HTML, CSS",
                    StageTitle = "Programmeur Web",
                    NbrStagiaire = 2,
                    StagiaireIfKnew = "",
                    SubmitToName = "Serge Lavoie",
                    SubmitToTitle = "Coordinateur aux développements Web",
                    SubmitToEmail = "serge.lavoie@email.com",
                    LimitDate = DateTime.Today.AddDays(2).ToShortDateString(),
                    Status = StageStatus.Accepted
                };

                return stage;
            }
        }

        #endregion

        #region Draft 1

        public static Stage draft1
        {
            get
            {
                var stage = new Stage()
                {
                    PublicationDate = DateTime.Now.ToString(),
                    CompanyName = "MI6",
                    Adresse = "1234 rue du Web, Québec",
                    StageDescription = "Notre centre dévoloppe des applications web",
                    EnvironnementDescription =
                        "Poste de travail Windows 8.1/Mac OS X, Logiciel Adobe CS6, SQL Server, HTML, CSS",
                    StageTitle = "Programmeur Web",
                    NbrStagiaire = 2,
                    Status = StageStatus.Draft,
                };

                return stage;
            }
        }

        #endregion

        #region Apply 1

        public static Apply apply1
        {
            get
            {
                var apply = new Apply()
                {
                    IdStage = 1,
                    IdStudent = 3,
                    Status = StatusApply.Accepted,
                    Cv = "Le cv de l'étudiant",
                    Letter = "La lettre de présentation",
                    DateApply = new DateTime(2014, 11, 11)
                };

                return apply;
            }
        }

        #endregion
        #region Apply 2

        public static Apply apply2
        {
            get
            {
                var apply = new Apply()
                {
                    IdStage = 1,
                    IdStudent = 1,
                    Cv = "Le cv de l'étudiant",
                    Letter = "La lettre de présentation.",
                    DateApply = new DateTime(2014, 11, 20)
                };

                return apply;
            }
        }

        #endregion
        #region Apply 3

        static public Apply apply3
        {
            get
            {
                var apply = new Apply()
                {
                    IdStage = 4,
                    IdStudent = 1,
                    Cv = "Le cv de l'étudiant",
                    Letter = "La lettre de présentation.",
                    DateApply = new DateTime(2014, 11, 20)
                };

                return apply;
            }
        }

        #endregion
        #region Apply 4

        static public Apply apply4
        {
            get
            {
                var apply = new Apply()
                {
                    IdStage = 3,
                    IdStudent = 2,
                    Cv = "Le cv de l'étudiant",
                    Letter = "La lettre de présentation.",
                    DateApply = new DateTime(2014, 11, 20)
                };

                return apply;
            }
        }

        #endregion

        #region Interview 1

        static public Interview interview1
        {
            get
            {
                var interview = new Interview()
                {
                    Date = "2014-20-10",
                    StageId = 3,
                    Present = true,
                    StudentId = 2,
                    DateOffer = "2014-22-10",
                    DateAcceptOffer = "2014-23-10"
                };

                return interview;
            }
        }

        #endregion
        #region Interview 2

        static public Interview interview2
        {
            get
            {
                var interview = new Interview()
                {
                    Date = "2014-20-10",
                    StageId = 3,
                    Present = true,
                    StudentId = 1,
                    DateOffer = "2014-22-10"
                };

                return interview;
            }
        }

        #endregion


        #region InvitationContactEnterprise 1

        public static InvitationContactEnterprise invitationContactEnterprise1
        {
            get
            {
                var invitation = new InvitationContactEnterprise()
                {
                    Id = 1,
                    Email = "testemail@enterprise.com",
                    Token = "123456"
                };

                return invitation;
            }
        }

        #endregion

        #region NotificationStudent 1

        public static Notification notificationStudent1
        {
            get
            {
                var notification = new Notification()
                {
                    Title = "Un nouveau stage est disponible",
                    Message =
                        "L'entreprise MI6 a ajouté ce stage: <a href=\"../../Stage/ViewStageInfo/1\">Apprentis</a> ",
                    For = 1,
                    Seen = false,
                    Date = new DateTime(2014, 10, 15)
                };

                return notification;
            }
        }

        #endregion
        #region NotificationStudent 2

        public static Notification notificationStudent2
        {
            get
            {
                var notification = new Notification()
                {
                    Title = "Une entreprise a modifié son offre de stage",
                    Message =
                        "L'entreprise Centre de développement pédagogique a modifié le stage: <a href=\"../../Stage/Details/3\">Programmeur C++</a>",
                    For = 1,
                    Seen = false,
                    Date = new DateTime(2014, 10, 15)
                };

                return notification;
            }
        }

        #endregion


        #region NotificationContactEnterprise 1

        public static Notification notificationContactEnterprise1
        {
            get
            {
                var notification = new Notification()
                {
                    Title = "Votre offre de stage a été acceptée par un coordonnateur",
                    Message =
                        "Votre offre de stage est maintenant visible pour les étudiants.",
                    For = 8,
                    Seen = false,
                    Date = new DateTime(2014, 10, 15)
                };

                return notification;
            }
        }

        #endregion
        #region NotificationContactEnterprise 2

        public static Notification notificationContactEnterprise2
        {
            get
            {
                var notification = new Notification()
                {
                    Title = "Votre offre de stage a été refusée par un coordonnateur",
                    Message =
                        "Votre offre de stage a été refusée. Vous pouvez la modifier et elle devra être approuvée de nouveau.",
                    For = 8,
                    Seen = false,
                    Date = new DateTime(2014, 10, 15)
                };

                return notification;
            }
        }

        #endregion


        #region NotificationCoordinator 1

        public static Notification notificationCoordinator1
        {
            get
            {
                var notification = new Notification()
                {
                    Title = "Un nouveau stage est en attente d'approbation",
                    Message =
                        "L'entreprise Musique inc a ajouté un stage: <a href=\"../../Stage/Details/2\">Programmeur C++</a> Vous devez l'approuver pour qu'il soit visible pour les étudiants.",
                    For = 4,
                    Seen = false,
                    Date = new DateTime(2014, 10, 15)
                };

                return notification;
            }
        }

        #endregion
        #region NotificationCoordinator 2

        public static Notification notificationCoordinator2
        {
            get
            {
                var notification = new Notification()
                {
                    Title = "Une entreprise a modifié un stage",
                    Message =
                        "L'entreprise Centre de développement pédagogique a modifié le stage: <a href=\"../../Stage/Details/3\">Programmeur C++</a>",
                    For = 4,
                    Seen = false,
                    Date = new DateTime(2014, 10, 15)
                };

                return notification;
            }
        }

        #endregion


        #region StageAgreementSigned

        static public StageAgreement stageAgreementSigned
        {
            get
            {
                var stageAgreement = new StageAgreement()
                {
                    StudentHasSigned = true,
                    DateStudentSigned = "2014, 10, 15",
                    IdStudentSigned = 1,
                    CoordinatorHasSigned = true,
                    IdCoordinatorSigned = 4,
                    DateCoordinatorSigned = "2014, 10, 15",
                    ContactEnterpriseHasSigned = true,
                    IdContactEnterpriseSigned = 6,
                    DateContactEnterpriseSigned = "2014, 10, 15",
                    DateStageStart = "2015, 03, 02",
                    DateStageEnd = "2015, 05, 15",
                    SupervisorName = "Bernard Barette",
                    IdStage = 1
                    
                };

                return stageAgreement;
            }
        }

        #endregion
        #region StageAgreementNotSigned

        static public StageAgreement stageAgreementNotSigned
        {
            get
            {
                var stageAgreement = new StageAgreement()
                {
                    StudentHasSigned = false,
                    DateStudentSigned = "2014, 10, 15",
                    IdStudentSigned = 1,
                    CoordinatorHasSigned = false,
                    IdCoordinatorSigned = 4,
                    DateCoordinatorSigned = "2014, 10, 15",
                    ContactEnterpriseHasSigned = false,
                    IdContactEnterpriseSigned = 6,
                    DateContactEnterpriseSigned = "2014, 10, 15",
                    IdStage = 1

                };

                return stageAgreement;
            }
        }

        #endregion

        #region misc

        static public Misc misc
        {
            get
            {
                var miscForTest = new Misc()
                {
                    StartApplyDate = String.Format("{0:yyyy-MM-dd}", DateTime.Today.AddDays(-2)),
                    EndApplyDate = String.Format("{0:yyyy-MM-dd}", DateTime.Today.AddDays(5))
                };
                return miscForTest;
            }

        }
        #endregion

    }

 

}






