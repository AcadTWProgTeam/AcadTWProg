using AcadTWProg.Models.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcadTWProg.Models.MyModels
{
    public class Room
    {
        public int ID { get; set; }

        [Required]
        [StringLength(5)]
        [Index(IsUnique = true)]
        [UniqueRoomName]
        public string Name { get; set; }

        [Required]
        [Range(10, 200)]
        public int Capacity { get; set; }
    }
}