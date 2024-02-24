using MyApp.Domain.Entities;

namespace MyApp.Domain.Contracts.DTOs.SubElement
{
    public sealed class CreateSubElementDTO
    {
        public SubElementType Type { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public int WindowId { get; set; }
    }
}
