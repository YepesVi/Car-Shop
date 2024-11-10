using Entity;
using System.ComponentModel.DataAnnotations;

namespace Entity.ViewModels
{
    public class SignupViewModel
    {
        // when using an object vadations messages doesn't work
        // [Required(ErrorMessage = "The User information is required.")]
        // public User User { get; set; } = new User();
        // [Required(ErrorMessage = "The Person information is required.")]
        // public Person Person { get; set; } = new Person();

        //User attributes

        [Required(ErrorMessage = "please provide a Name")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "please provide an Email")]
        [EmailAddress(ErrorMessage = "pleaser provide a valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "please provide a Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "please comfirm your Password")]
        public string ComfirmedPassword { get; set; }


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
    }
}
