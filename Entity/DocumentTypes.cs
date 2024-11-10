using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DocumentTypes
    {
        [Required(ErrorMessage = "please provide an ID")]
        [Display(Name = "Document Type Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "please provide a DocumentType")]
        [Display(Name = "Document Type")]
        public string DocumentType { get; set; }
    }
}
