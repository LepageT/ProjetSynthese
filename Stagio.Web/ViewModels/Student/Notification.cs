using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stagio.Domain.Entities;

namespace Stagio.Web.ViewModels.Student
{
    public class Notification
    {
        public int NotificationId { get; set; }
        
        public String Title { get; set; }
        
        public String Message { get; set; }

        public int For { get; set; }

        public Boolean Seen { get; set; }

        public DateTime Date { get; set; }
    }
}