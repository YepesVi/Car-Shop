using System.ComponentModel.DataAnnotations;

namespace Entity.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "please provide an Email")]
        [EmailAddress(ErrorMessage = "please provide a valid Email")]
        public string? Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "please provide a Password")]
        public string? Password { get; set; }

    }
}
