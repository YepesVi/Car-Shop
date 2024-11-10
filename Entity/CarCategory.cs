using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CarCategory
    {
        [Required(ErrorMessage = "please provide an ID")]
        [Display(Name = "Car Category Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "please provide a Category")]
        [Display(Name = "Category")]
        public string Category { get; set; }
        [Required(ErrorMessage = "please provide a price for hour of labor")]
        public decimal LaborPriceHour {  get; set; }

    }
}
