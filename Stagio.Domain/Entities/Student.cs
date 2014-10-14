using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Stagio.Domain.Entities
{
    public class Student : ApplicationUser
    {
        [Required]
        public int Matricule { get; set; }
       

   
        //[Required(ErrorMessage = "Requis")]
        //[DataType(DataType.Password)]
        //[MinLength(8)]
        //public string Password { get; set; }


    }
}
