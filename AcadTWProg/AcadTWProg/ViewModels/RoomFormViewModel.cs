using AcadTWProg.Models.MyModels;
using AcadTWProg.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AcadTWProg.ViewModels
{
    public class RoomFormViewModel
    {
        public int? ID { get; set; }

        [Required]
        [StringLength(5)]
        public string Name { get; set; }

        [Required]
        [Range(10, 200)]
        public int? Capacity { get; set; }

        public string Title { get { return ID == 0 ? "New Room" : "Edit"; } }

        public bool IsEditMode { get { return ID != 0; } }

        public RoomFormViewModel()
        {
            ID = 0;
        }

        public RoomFormViewModel(Room room)
        {
            ID = room.ID;
            Name = room.Name;
            Capacity = room.Capacity;
        }
    }
}