using System.ComponentModel.DataAnnotations;

namespace MyApp.Domain.Contracts.DTOs.Window
{
    public sealed class CreateWindowDTO
    {
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Minimum lenghs is 3, and Maximum is 30")]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Minimal value is 1")]
        public int Quantity { get; set; }

        [Required]
        public int OrderId { get; set; }
    }
}
