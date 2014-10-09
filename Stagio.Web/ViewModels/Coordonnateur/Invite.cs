using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stagio.Web.ViewModels.Coordonnateur
{
    public class Invite
    {
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        public String Message { get; set; }
    }
}