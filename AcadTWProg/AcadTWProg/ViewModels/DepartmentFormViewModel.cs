using AcadTWProg.Models.MyModels;
using System.ComponentModel.DataAnnotations;

namespace AcadTWProg.ViewModels
{
    public class DepartmentFormViewModel
    {
        public int? ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public string Title { get { return ID == 0 ? "New Department" : "Edit"; } }

        public bool IsEditMode { get { return ID != 0; } }

        public DepartmentFormViewModel()
        {
            ID = 0;
        }

        public DepartmentFormViewModel(Department department)
        {
            ID = department.ID;
            Name = department.Name;
        }
    }
}