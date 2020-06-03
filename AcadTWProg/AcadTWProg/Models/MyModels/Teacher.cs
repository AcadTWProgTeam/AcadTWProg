using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcadTWProg.Models.MyModels
{
    public class Teacher
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
    }
}