using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stagio.Web.ViewModels.Coordinator
{
    public class StudentLists
    {
        public List<StudentList>  StudentStageFound{ get; set; }

        public List<StudentList> StudentStageNotFound { get; set; }

    }
}