using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stagio.Web.Automation
{
    public class Navigation
    {
        public class Student
        {
            public class Index
            {
                public static void Select()
                {
                    MenuSelector.SelectTopLevel("index-Student");
                }
            }

            public class EditProfil
            {
                public static void Select()
                {
                    MenuSelector.Select("index-Student", "details-user-page");
                    MenuSelector.SelectTopLevel("edit-Student");
                }
            }

            public class EditProfilInIndex
            {
                public static void Select()
                {
                    MenuSelector.Select("details-user-page", "edit-Student") ;
                }
            }
            public class SeeStages
            {
                public static void Select()
                {
                    MenuSelector.Select("index-Student", "stageList-student");
                }
            }
            public class AddInterview
            {
                public static void Select()
                {
                    MenuSelector.Select("student-menu", "add-entrevue-menu-item");
                }
            }
            public class ListApply
            {
                public static void Select()
                {
                    MenuSelector.Select("student-menu", "apply-list-menu-item");
                }
            }

            public class ApplyStage3
            {
                public static void Select()
                {
                    MenuSelector.Select("index-Student", "stageList-student");
                    MenuSelector.Select("details-stages3", "accept-stage");
                }
            }
            
        }

        public class ContactEnterprise
        {
            public class InviteContactEnterprise
            {
                public static void Select()
                {
                    MenuSelector.Select("index-enterprise", "invite-contact-enterprise");
                }
            }
            public class DetailsApplyStudent1
            {
                public static void Select()
                {
                    MenuSelector.Select("index-enterprise", "listContact");
                    MenuSelector.Select("list-stages1", "list-student1");
                }
            }

            public class CreateStage
            {
                public static void Select()
                {
                    MenuSelector.Select("index-enterprise", "create-stage-enterprise");
                }
            }
            public class ListStages
            {
                public static void Select()
                {
                    MenuSelector.Select("index-enterprise", "listContact");
                }
            }
            public class ListApply1
            {
                public static void Select()
                {
                    MenuSelector.Select("index-enterprise", "listContact");
                    MenuSelector.SelectTopLevel("list-stages1");

                }
            }
        }

        public class Coordinator
        {
            public class InviteCoordinator
            {
                public static void Select()
                {
                    MenuSelector.Select("index-coordonnateur", "create-coordinator");
                }
            }
            public class AddStudents
            {
                public static void Select()
                {
                    MenuSelector.Select("index-coordonnateur", "upload-student");
                }
            }
            public class InviteContactEnterprise
            {
                public static void Select()
                {
                    MenuSelector.Select("index-coordonnateur", "invite-enterprise");
                }
            }
            public class ListAllStages
            {
                public static void Select()
                {
                    MenuSelector.Select("index-coordonnateur", "list");
                }

            }

            public class DetailsStage1
            {
                public static void Select()
                {
                    MenuSelector.Select("index-coordonnateur", "list");
                    MenuSelector.SelectTopLevel("details-stages1");
                }

            }
            public class DetailsStage3
            {
                public static void Select()
                {
                    MenuSelector.Select("index-coordonnateur", "list");
                    MenuSelector.SelectTopLevel("details-stages3");
                }

            }

            public class Index
            {
                public static void Select()
                {
                    MenuSelector.SelectTopLevel("index-Coordinator");
                }
            }
        }

        public class AllUsers
        {
            public class Home
            {

                public static void Select()
                {
                    MenuSelector.SelectTopLevel("home-link");
                }
            }


            public class Login
            {
                public static void Select()
                {
                    MenuSelector.SelectTopLevel("login-link");
                }
            }

            public class CreateStudent
            {
                public static void Select()
                {
                    MenuSelector.SelectTopLevel("create-student");
                }
            }

            
        }
    }
}