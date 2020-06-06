using AcadTWProg.Models.MyModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AcadTWProg.Models.Validation
{
    public class UniqueRoomName : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var room = (Room)validationContext.ObjectInstance;
            ApplicationDbContext _context = new ApplicationDbContext();

            if (_context.Rooms.ToList().Any(r => r.Name == room.Name))
                return new ValidationResult("Room already exists");
            return ValidationResult.Success;
        }
    }
}