using System;
using System.ComponentModel;

namespace Stagio.Web.ViewModels.Notification
{
    public class Notification
    {
        public int NotificationId { get; set; }
                
        [DisplayName("Titre")]
        public String Title { get; set; }
        
        public int For { get; set; }

        public Boolean Seen { get; set; }

        [DisplayName("Date")]
        public DateTime Date { get; set; }
    }
}