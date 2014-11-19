using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

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

            public class ListInterview
            {
                public static void Select()
                {
                    MenuSelector.Select("student-interview-menu", "list-interview");
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
                    MenuSelector.Select("student-stage-menu", "stageList-student");
                }
            }
            public class AddInterview
            {
                public static void Select()
                {
                    MenuSelector.Select("student-interview-menu", "add-entrevue-menu-item");
                }
            }
            public class ListApply
            {
                public static void Select()
                {
                    MenuSelector.Select("student-stage-menu", "apply-list-menu-item");
                }
            }

            public class ApplyStage3
            {
                public static void Select()
                {
                    MenuSelector.Select("student-stage-menu", "stageList-student");
                    MenuSelector.Select("details-stages3", "accept-stage");
                }
            }

            public class ReplyApplyStage1
            {
                public static void Select()
                {
                    MenuSelector.Select("student-stage-menu", "apply-list-menu-item");
                    MenuSelector.SelectTopLevel("reply-stage1");
                }
            }

            public class EditInterview
            {
                public static void Select()
                {
                    MenuSelector.Select("student-interview-menu", "list-interview");
                    MenuSelector.SelectTopLevel("list-interview1");
                }
            }

            public class EditInterviewInIndex
            {
            }
        }

        public class ContactEnterprise
        {
            public class Index
            {
                public static void Select()
                {
                    MenuSelector.SelectTopLevel("index-enterprise");
                }
            }

            public class InviteContactEnterprise
            {
                public static void Select()
                {
                    MenuSelector.Select("contactEnterprise-menu", "invite-contact-enterprise");
                }
            }
            public class DetailsApplyStudent1
            {
                public static void Select()
                {
                    MenuSelector.Select("contactEnterprise-menu", "listContact");
                    MenuSelector.Select("list-stages1", "list-student1");
                }
            }

            public class CreateStage
            {
                public static void Select()
                {
                    MenuSelector.Select("contactEnterprise-menu", "create-stage-enterprise");
                }
            }
            public class ListStages
            {
                public static void Select()
                {
                    MenuSelector.Select("contactEnterprise-menu", "listContact");
                }
            }
            public class ListApply1
            {
                public static void Select()
                {
                    MenuSelector.Select("contactEnterprise-menu", "listContact");
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
                    MenuSelector.SelectTopLevel("index-coordonnateur");
                }
            }

            public class StudentList
            {
                public static void Select()
                {
                    MenuSelector.Select("index-coordonnateur", "student-list");
                }
            }

            public class StudentApplyList1
            {
                public static void Select()
                {
                    MenuSelector.Select("index-coordonnateur", "student-list");
                    MenuSelector.SelectTopLevel("student-stages1");
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

            public class Notification
            {
                public static void Select()
                {
                    MenuSelector.SelectTopLevel("notification-list");
                }
            }

            
        }
    }
}