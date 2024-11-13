using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Car
    {
        [Required(ErrorMessage = "please provide an ID")]
        [Display(Name = "Car Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "please provide a plate")]
        [RegularExpression(@"^[A-Z]{3}[0-9]{3}$", ErrorMessage = "Plate must be exactly 3 uppercase letters followed by 3 digits.(AAAXXX)")]
        [Display(Name = "Car Plate")]
        public string Plate { get; set; }
        [Required(ErrorMessage = "please provide a brand")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "please provide a Model")]
        public string Model { get; set; }
        [Required(ErrorMessage = "please provide a Year")]
        [Range(1900, 2099, ErrorMessage = "Year must be between 1900 and 2099.")]
        public int Year { get; set; }
        [Required(ErrorMessage = "please provide a category")]
        public int CarCategory_id { get; set; }

    }
}
