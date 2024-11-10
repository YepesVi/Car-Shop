using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Person_Car
    {
        [Required(ErrorMessage = "please provide an ID")]
        [Display(Name = "Person Id")]
        public int Person_id { get; set; }
        [Required(ErrorMessage = "please provide an ID")]
        [Display(Name = "Car Id")]
        public int Car_id { get; set; }

    }
}
