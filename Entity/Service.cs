using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Service
    {

        [Required(ErrorMessage = "please provide an ID")]
        [Display(Name = "Service Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "please provide a car ID")]
        [Display(Name = "Car Id")]
        public int Car_id { get; set; }
        [Required(ErrorMessage = "please provide a entrance date")]
        [Display(Name = "Entrance date")]
        public DateTime EntranceDate { get; set; }
        [Display(Name = "Finished date")]
        public DateTime? FinishedDate { get; set; }
        [Required(ErrorMessage = "please provide a total price")]
        [Display(Name = "Total price")]
        [RegularExpression(@"^(0|[1-9]\d*)(\.\d+)?$", ErrorMessage = "Please enter a valid positive total price (including 0).")]
        public decimal TotalPrice { get; set; }
    }
}
