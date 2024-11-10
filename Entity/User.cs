using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class User
    {
        [Required( ErrorMessage = "please provide an ID")]
        [Display(Name = "User Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "please provide a Name")]
        [Display(Name = "User Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "please provide an Email")]
        [EmailAddress(ErrorMessage = "pleaser provide a valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "please provide a Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "please provide a Role")]
        public string Role { get; set; }
    }
}
