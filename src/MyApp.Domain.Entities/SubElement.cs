namespace MyApp.Domain.Entities
{
    public class SubElement
    {
        public int Id { get; set; }

        public SubElementType Type { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public int WindowId { get; set; }

        public Window Window { get; set; }
    }
}
