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
                    MenuSelector.Select("index-Student", "edit-student");
                }
            }

            public class EditProfilInIndex
            {
                public static void Select()
                {
                    MenuSelector.SelectTopLevel("edit-student");
                }
            }
            public class SeeStages
            {
                public static void Select()
                {
                    MenuSelector.Select("index-Student", "stageList-student");
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
        }
    }
}