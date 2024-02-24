using MyApp.Domain.Entities;

namespace MyApp.Domain.Contracts.DTOs.Window
{
    public sealed class WindowDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }
    }
}
