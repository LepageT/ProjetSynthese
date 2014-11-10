using System;

namespace Stagio.Domain.Entities
{
    public class Invitation : Entity
    {
        public string Token { get; set; }

        public string Email { get; set; }

        public Boolean Used { get; set; }
    }
}
