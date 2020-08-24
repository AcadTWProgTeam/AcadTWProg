using AcadTWProg.Models.MyModels;
using System.Collections.Generic;
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
        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }

        public IEnumerable<Department> Departments { get; set; }

        [Required]
        [Range(3, 6)]
        public int Credits { get; set; }

        [Required]
        public float Hours { get; set; }

        [Required]
        public int Semester { get; set; }

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
            DepartmentId = course.DepartmentId;
            Credits = course.Credits;
            Hours = course.Hours;
            Semester = course.Semester;
        }
    }
}