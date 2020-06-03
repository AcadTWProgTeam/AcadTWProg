using AcadTWProg.Models.MyModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcadTWProg.ViewModels
{
    public class CourseFormViewModel
    {
        public int? ID { get; set; }

        [Required]
        [StringLength(5)]
        public string Code { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [Range(3, 6)]
        public int Credits { get; set; }

        [Required]
        [Range(2, 6)]
        public int Hours { get; set; }

        public string Title { get { return ID == 0 ? "New Course" : "Edit"; } }

        public bool IsEditMode { get { return ID != 0; } }

        public CourseFormViewModel()
        {
            ID = 0;
        }

        public CourseFormViewModel(Course course)
        {
            ID = course.ID;
            Code = course.Code;
            Name = course.Name;
            Credits = course.Credits;
            Hours = course.Hours;
        }
    }
}