using System;

namespace Stagio.Web.ViewModels.Notification
{
    public class Notification
    {
        public int NotificationId { get; set; }
        
        public String Title { get; set; }
        
        public int For { get; set; }

        public Boolean Seen { get; set; }

        public DateTime Date { get; set; }
    }
}