using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Specializations
    {
        [Required(ErrorMessage = "please provide an ID")]
        [Display(Name = "Specialization Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "please provide a Specialization")]
        [Display(Name = "Specialization")]
        public string Specialization { get; set; }
    }
}
