using MyApp.Domain.Entities;

namespace MyApp.Domain.Contracts.DTOs.SubElement
{
    public sealed class SubElementDTO
    {
        public int Id { get; set; }

        public SubElementType Type { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }
    }
}
