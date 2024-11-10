using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModels
{
    public class CarsViewModel
    {
        [Required(ErrorMessage = "please provide an ID")]
        [Display(Name = "Car Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "please provide a plate")]
        [Display(Name = "Car Plate")]
        public string Plate { get; set; }
        [Required(ErrorMessage = "please provide a brand")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "please provide a Model")]
        public string Model { get; set; }
        [Required(ErrorMessage = "please provide a Year")]
        public int Year { get; set; }
        [Required(ErrorMessage = "please provide a category")]
        public string CarCategory { get; set; }
    }
}
