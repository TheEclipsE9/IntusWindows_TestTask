using System.ComponentModel.DataAnnotations;

namespace MyApp.Domain.Contracts.DTOs.Order
{
    public sealed class UpdateOrderDTO
    {
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Minimum lenghs is 3, and Maximum is 30")]
        public string Name { get; set; }

        [Required()]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Minimum lenghs is 2, and Maximum is 30")]
        public string State { get; set; }
    }
}
