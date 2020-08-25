using AcadTWProg.Models.Validation;
using System.ComponentModel.DataAnnotations;

namespace AcadTWProg.Models.MyModels
{
    public class Schedule
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        [UniqueScheduleName]
        public string Name { get; set; }

        public Department Department { get; set; }

        [Required]
        [Display(Name = "Department")]
        [UniqueSchedule]
        public int DepartmentId { get; set; }

        [Required]
        [Range(1, 10)]
        [UniqueSchedule]
        public int Semester { get; set; }

        public string ScheduleData { get; set; }
    }
}