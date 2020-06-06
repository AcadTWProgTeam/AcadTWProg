using AcadTWProg.Models.MyModels;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AcadTWProg.Models.Validation
{
    public class UniqueScheduleName : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var schedule = (Schedule)validationContext.ObjectInstance;
            ApplicationDbContext _context = new ApplicationDbContext();

            if (_context.Schedules.ToList().Any(s => s.Name == schedule.Name))
                return new ValidationResult("Schedule name already exists");
            return ValidationResult.Success;
        }
    }
}