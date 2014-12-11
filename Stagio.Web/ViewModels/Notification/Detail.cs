using System;
using System.ComponentModel;

namespace Stagio.Web.ViewModels.Notification
{
    public class Detail
    {
        public int NotificationId { get; set; }

        [DisplayName("Titre")]
        public String Title { get; set; }
        
        public String Message { get; set; }

        [DisplayName("Date")]
        public DateTime Date { get; set; }
    }
}