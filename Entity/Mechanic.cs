using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Mechanic
    {
        [Required(ErrorMessage = "please provide an ID")]
        [Display(Name = "Person Id")]
        public int Id_Person { get; set; }
        [Required(ErrorMessage = "please provide an Specialization")]
        [Display(Name = "Specialization Id")]
        public int Specialization_id { get; set; }
        [Required(ErrorMessage = "please provide an Category")]
        [Display(Name = "Category Id")]
        public int CarCategory_id { get; set; }
    }
}
