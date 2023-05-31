using System.ComponentModel.DataAnnotations;

namespace WebApplication4_WebAPI_115.Models.DTOs
{
    public class NationalParkDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string State { get; set; }
        public byte[]? Picture { get; set; }
        public DateTime Created { get; set; }
        public DateTime Established { get; set; }
    }
}
