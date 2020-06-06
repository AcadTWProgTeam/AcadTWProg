using System.ComponentModel.DataAnnotations;

namespace AcadTWProg.Models.Dtos
{
    public class ScheduleDto
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public DepartmentDto Department { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        [Range(1, 10)]
        public int Semester { get; set; }
    }
}