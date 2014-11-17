using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stagio.Web.ViewModels.Notification
{
    public class Detail
    {
        public int NotificationId { get; set; }
        
        public String Title { get; set; }
        
        public String Message { get; set; }

        public DateTime Date { get; set; }

        public ActionResult PreviousUrl { get; set; }
    }
}