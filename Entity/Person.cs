using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Person
    {
        [Required(ErrorMessage = "please provide an ID")]
        [Display(Name = "Perosn Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "please provide an ID")]
        [Display(Name = "User Id")]
        public int User_id { get; set; }
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


    }
}
