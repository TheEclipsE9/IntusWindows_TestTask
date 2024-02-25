using MyApp.Domain.Contracts.Infrastructure;
using MyApp.Domain.Entities;

namespace MyApp.Infrastructure.Data
{
    public class SeedData
    {
        public static void Seed(IAppDbContext context)
        {
            if (context.Orders.Any())
            {
                return;
            }

            context.Orders.Add(new Order
            {
                Id = 1,
                Name = "New York Building 1",
                State = "NY"
            });
            context.Orders.Add(new Order
            {
                Id = 2,
                Name = "California Hotel AJK",
                State = "CA"
            });

            context.Windows.Add(new Window
            {
                Id = 1,
                Name = "A51",
                Quantity = 4,
                OrderId = 1
            });
            context.Windows.Add(new Window
            {
                Id = 2,
                Name = "C Zone 5",
                Quantity = 2,
                OrderId = 1
            });
            context.Windows.Add(new Window
            {
                Id = 3,
                Name = "GLB",
                Quantity = 2,
                OrderId = 2
            });
            context.Windows.Add(new Window
            {
                Id = 4,
                Name = "OHF",
                Quantity = 2,
                OrderId = 2
            });

            context.SubElements.Add(new SubElement
            {
                Id = 1,
                Type = SubElementType.Doors,
                Width = 1200,
                Height = 1850,
                WindowId = 1
            });
            context.SubElements.Add(new SubElement
            {
                Id = 2,
                Type = SubElementType.Window,
                Width = 800,
                Height = 1850,
                WindowId = 1
            });
            context.SubElements.Add(new SubElement
            {
                Id = 3,
                Type = SubElementType.Window,
                Width = 700,
                Height = 1850,
                WindowId = 1
            });
            context.SubElements.Add(new SubElement
            {
                Id = 4,
                Type = SubElementType.Doors,
                Width = 1400,
                Height = 2200,
                WindowId = 3
            });
            context.SubElements.Add(new SubElement
            {
                Id = 5,
                Type = SubElementType.Window,
                Width = 600,
                Height = 2200,
                WindowId = 3
            });

            context.SubElements.Add(new SubElement
            {
                Id = 6,
                Type = SubElementType.Window,
                Width = 1500,
                Height = 2000,
                WindowId = 4
            });
            context.SubElements.Add(new SubElement
            {
                Id = 7,
                Type = SubElementType.Window,
                Width = 1500,
                Height = 2000,
                WindowId = 4
            });

            context.SubElements.Add(new SubElement
            {
                Id = 8,
                Type = SubElementType.Window,
                Width = 700,
                Height = 1850,
                WindowId = 2
            });

            context.SaveChanges();
        }
    }
}
