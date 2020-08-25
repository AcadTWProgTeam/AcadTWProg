using AcadTWProg.Models.MyModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcadTWProg.ViewModels
{
    public class ScheduleFormViewModel
    {
        public int? ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }

        public IEnumerable<Department> Departments { get; set; }

        public IEnumerable<Course> Courses { get; set; }

        public IEnumerable<Teacher> Teachers { get; set; }

        public IEnumerable<Room> Rooms { get; set; }

        [Required]
        [Range(1, 10)]
        public int? Semester { get; set; }

        public string ScheduleData { get; set; }

        public string Title { get { return ID == 0 ? "New Schedule" : "Edit"; } }

        public bool IsEditMode { get { return ID != 0; } }

        public ScheduleFormViewModel()
        {
            ID = 0;
        }

        public ScheduleFormViewModel(Schedule schedule)
        {
            ID = schedule.ID;
            Name = schedule.Name;
            DepartmentId = schedule.DepartmentId;
            Semester = schedule.Semester;
            ScheduleData = schedule.ScheduleData;
        }
    }
}