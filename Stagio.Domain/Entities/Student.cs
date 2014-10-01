using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Stagio.Domain.Entities
{
    public class Student : Entity
    {
        public int Matricule { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Telephone { get; set; }

        public string Password { get; set; }


    }
}
