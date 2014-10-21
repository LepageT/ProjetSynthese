using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stagio.Web.Services
{
    public interface IMailler
    {

        bool SendEmail(string destination, string subject, string content);
    }
}