﻿using AcadTWProg.Models.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcadTWProg.Models.MyModels
{
    public class Course
    {
        public int ID { get; set; }

        [Required]
        [StringLength(5)]
        [Index(IsUnique = true)]
        [UniqueCourseCode]
        public string Code { get; set; }

        [Required]
        [StringLength(20)]
        [Index(IsUnique = true)]
        [UniqueCourseName]
        public string Name { get; set; }

        [Required]
        [Range(3, 6)]
        public int Credits { get; set; }

        [Required]
        [Range(2, 6)]
        public int Hours { get; set; }
    }
}