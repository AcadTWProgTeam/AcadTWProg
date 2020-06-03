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

        [Required]
        [Range(3, 6)]
        public int Credits { get; set; }

        [Required]
        [Range(2, 6)]
        public int Hours { get; set; }
    }
}