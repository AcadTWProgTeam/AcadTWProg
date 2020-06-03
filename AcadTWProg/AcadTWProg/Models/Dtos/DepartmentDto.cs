using System.ComponentModel.DataAnnotations;

namespace AcadTWProg.Models.Dtos
{
    public class DepartmentDto
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}