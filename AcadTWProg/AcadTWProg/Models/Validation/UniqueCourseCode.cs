using AcadTWProg.Models.MyModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AcadTWProg.Models.Validation
{
    public class UniqueCourseCode : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var course = (Course)validationContext.ObjectInstance;
            ApplicationDbContext _context = new ApplicationDbContext();

            if (_context.Courses.ToList().Any(c => c.Code == course.Code && c.ID != course.ID))
                return new ValidationResult("Code already exists");
            return ValidationResult.Success;
        }
    }
}