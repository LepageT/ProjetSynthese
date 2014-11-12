using System;


namespace Stagio.Domain.Entities
{
    public class InvitationContactEnterprise : Entity
    {
        public string Token { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EnterpriseName { get; set; }

        public string Telephone { get; set; }

        public string Poste { get; set; }

        public Boolean Used { get; set; }
    }
}
