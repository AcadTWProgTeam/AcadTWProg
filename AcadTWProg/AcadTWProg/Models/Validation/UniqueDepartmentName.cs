using AcadTWProg.Models.MyModels;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AcadTWProg.Models.Validation
{
    public class UniqueDepartmentName : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var department = (Department)validationContext.ObjectInstance;
            ApplicationDbContext _context = new ApplicationDbContext();

            if (_context.Departments.ToList().Any(d => d.Name == department.Name && d.ID != department.ID))
                return new ValidationResult("Department already exists");
            return ValidationResult.Success;
        }
    }
}