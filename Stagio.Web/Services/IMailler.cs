﻿
using Stagio.Domain.Entities;

namespace Stagio.Web.Services
{
    public interface IMailler
    {

        bool SendEmail(string destination, string subject, string content);
        void SetNewSmtpOptions(Misc misc, string destination);
    }
}