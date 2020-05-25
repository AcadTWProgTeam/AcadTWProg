﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcadTWProg.Models.Dtos
{
    public class RoomDto
    {
        public int ID { get; set; }

        [Required]
        [StringLength(5)]
        public string Name { get; set; }

        [Required]
        [Range(10, 200)]
        public int Capacity { get; set; }
    }
}