using System;

namespace Stagio.Web.ViewModels.Notification
{
    public class Detail
    {
        public int NotificationId { get; set; }
        
        public String Title { get; set; }
        
        public String Message { get; set; }

        public DateTime Date { get; set; }
    }
}