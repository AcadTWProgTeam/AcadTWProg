using AcadTWProg.Models.MyModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AcadTWProg.Models.Validation
{
    public class UniqueTeacherName : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var teacher = (Teacher)validationContext.ObjectInstance;
            ApplicationDbContext _context = new ApplicationDbContext();

            if (_context.Teachers.ToList().Any(t => t.Name == teacher.Name && t.ID != teacher.ID))
                return new ValidationResult("Teacher already exists");
            return ValidationResult.Success;
        }
    }
}