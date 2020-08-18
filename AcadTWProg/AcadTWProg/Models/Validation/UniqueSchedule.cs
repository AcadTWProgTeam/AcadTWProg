using AcadTWProg.Models.MyModels;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AcadTWProg.Models.Validation
{
    public class UniqueSchedule : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var schedule = (Schedule)validationContext.ObjectInstance;
            ApplicationDbContext _context = new ApplicationDbContext();

            if (_context.Schedules.ToList().Any(s => s.DepartmentId == schedule.DepartmentId
                                                    && s.Semester == schedule.Semester
                                                    && s.ID != schedule.ID))
                return new ValidationResult("Schedule already exists");
            return ValidationResult.Success;
        }
    }
}