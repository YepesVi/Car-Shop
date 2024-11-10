using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Roles
    {
        [Required(ErrorMessage = "please provide an ID")]
        [Display(Name = "Role Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "please provide a Role")]
        [Display(Name = "Role")]
        public string Role { get; set; }
    }
}
