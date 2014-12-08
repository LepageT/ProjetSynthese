using System.ComponentModel.DataAnnotations;

namespace Stagio.Web.ViewModels.Account
{
    public class Login
    {
        [Required(ErrorMessage = "Le champ courriel est requis")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Le champ mot de passe est requis")]
        public string Password { get; set; }
    }
}