﻿using AcadTWProg.Models.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    public class ScheduleData
    {
        public int Day { get; set; }

        public int Time { get; set; }

        public int ColSpan { get; set; }

        public string Code { get; set; }

        public string TeacherName { get; set; }

        public string Room { get; set; }
    }
}