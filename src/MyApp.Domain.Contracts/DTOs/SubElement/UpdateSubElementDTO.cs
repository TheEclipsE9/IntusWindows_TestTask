using MyApp.Domain.Entities;

namespace MyApp.Domain.Contracts.DTOs.SubElement
{
    public sealed class UpdateSubElementDTO
    {
        public SubElementType Type { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }
    }
}
