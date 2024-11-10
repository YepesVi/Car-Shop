using Entity.ViewModels.Attributes;
using System;
using System.Collections.Generic; 
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModels
{
    public class UpdateUserViewModel
    {

        [Required(ErrorMessage = "please provide a id")]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "please provide a Name")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "please provide an Email")]
        [EmailAddress(ErrorMessage = "pleaser provide a valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "please provide a Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "please provide a Role")]
        public string Role { get; set; }


        //person attributes

        [Required(ErrorMessage = "please provide a Name")]
        [Display(Name = "Person Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "please provide a phone")]
        [Display(Name = "Person phone")]
        public long Phone { get; set; }
        [Required(ErrorMessage = "please provide a Document Type")]
        [Display(Name = "Document Type")]
        public int DocumentType_id { get; set; }
        [Required(ErrorMessage = "please provide a Document")]
        [Display(Name = "Person Document")]
        public string DocumentNumber { get; set; }
        [Display(Name = "Person Address")]
        public string? Address { get; set; }

        //Mechanic Attributes
        [RequiredIfMechanic] // Atributo personalizado para validación condicional
        public int? CarCategory_id { get; set; }
        [RequiredIfMechanic] // Atributo personalizado para validación condicional
        public int? Specialization_id { get; set; }


    }
}
