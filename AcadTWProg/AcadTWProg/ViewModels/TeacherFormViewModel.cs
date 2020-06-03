using AcadTWProg.Models.MyModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcadTWProg.ViewModels
{
    public class TeacherFormViewModel
    {
        public int? ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public string Title { get { return ID == 0 ? "New Teacher" : "Edit"; } }

        public bool IsEditMode { get { return ID != 0; } }

        public TeacherFormViewModel()
        {
            ID = 0;
        }

        public TeacherFormViewModel(Teacher teacher)
        {
            ID = teacher.ID;
            Name = teacher.Name;
        }
    }
}