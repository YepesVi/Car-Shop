using Entity.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Entity.ViewModels.Attributes
{
    public class RequiredIfMechanicAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (UpdateUserViewModel)validationContext.ObjectInstance;

            // Verificar si el rol es "Mechanic"
            if (model.Role == "Mechanic" && (value == null || (int)value <= 0))
            {
                return new ValidationResult("Car Category and Specialization are required when the role is Mechanic.");
            }

            return ValidationResult.Success;
        }
    }
}
