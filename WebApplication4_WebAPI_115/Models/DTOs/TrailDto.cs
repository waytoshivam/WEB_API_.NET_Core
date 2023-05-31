﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static WebApplication4_WebAPI_115.Models.Trail;

namespace WebApplication4_WebAPI_115.Models.DTOs
{
    public class TrailDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Distance { get; set; }
        [Required]
        public string Elevation { get; set; }
        public DifficultyType Difficulty { get; set; }

        public int NationalParkId { get; set; }
        public NationalPark NationalPark { get; set; }
    }
}
