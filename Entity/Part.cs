using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Part
    {
        [Required(ErrorMessage = "please provide an ID")]
        [Display(Name = "Part Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "please provide a service")]
        [Display(Name = "Service Id")]
        public int Service_id { get; set; }
        [Required(ErrorMessage = "please provide a Name")]
        [Display(Name = "Part Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide a price")]
        [Display(Name = "Price")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Please enter a valid positive price.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please provide an amount of parts")]
        [Display(Name = "Amount of parts used")]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Please enter a valid positive quantity.")]
        public int Quantity { get; set; }
    }
}
