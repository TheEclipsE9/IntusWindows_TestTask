namespace MyApp.Domain.Contracts.DTOs.Window
{
    public sealed class CreateWindowDTO
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public int OrderId { get; set; }
    }
}
