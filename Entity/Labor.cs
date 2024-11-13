using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Labor
    {
        [Required(ErrorMessage = "please provide an ID")]
        [Display(Name = "Labor Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "please provide a service")]
        [Display(Name = "Service Id")]
        public int Service_id { get; set; }
        [Required(ErrorMessage = "please provide a Description")]
        [Display(Name = "Labor Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "please provide an amount of hours")]
        [Display(Name = "Hours Worked")]
        [Range(0, 9999.999, ErrorMessage = "Please enter a valid positive number for hours worked (up to 4 digits and 3 decimals).")]
        public decimal HoursWorked { get; set; }
        [Required(ErrorMessage = "please provide a Mechanic")]
        [Display(Name = "Mechanic Id")]
        public int Mechanic_id { get; set; }
    }
}
