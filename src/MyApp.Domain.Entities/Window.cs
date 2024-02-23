namespace MyApp.Domain.Entities
{
    public class Window
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public ICollection<SubElement> SubElements { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
