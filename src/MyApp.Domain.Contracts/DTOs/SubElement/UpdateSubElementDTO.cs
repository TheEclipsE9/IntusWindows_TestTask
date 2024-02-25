using MyApp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Domain.Contracts.DTOs.SubElement
{
    public sealed class UpdateSubElementDTO
    {
        [Required]
        public SubElementType Type { get; set; }
        
        [Required]
        [Range(100, double.MaxValue, ErrorMessage = "Minimal value is 100")]
        public double Width { get; set; }
        
        [Required]
        [Range(100, double.MaxValue, ErrorMessage = "Minimal value is 100")]
        public double Height { get; set; }
    }
}
