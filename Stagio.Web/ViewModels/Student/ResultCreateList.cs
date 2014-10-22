using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stagio.Web.ViewModels.Student
{
    public class ResultCreateList
    {
        public List<ListStudent> ListStudentAdded { get; set; }
        public List<ListStudent> ListStudentNotAdded { get; set; }
    }
}