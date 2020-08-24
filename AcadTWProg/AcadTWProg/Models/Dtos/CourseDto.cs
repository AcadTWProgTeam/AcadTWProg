using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcadTWProg.Models.Dtos
{
    public class CourseDto
    {
        public int ID { get; set; }

        [Required]
        [StringLength(5)]
        public string Code { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public DepartmentDto Department { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        [Range(3, 6)]
        public int Credits { get; set; }

        [Required]
        public float Hours { get; set; }

        [Required]
        public int Semester { get; set; }
    }
}