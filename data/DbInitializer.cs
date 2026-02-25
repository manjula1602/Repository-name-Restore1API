using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Data
{
    public class DbInitializer
    {
        public static void InitDb(WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<StoreContext>();

            context.Database.Migrate();

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Angular Speedster Board 2000",
                        Description = "Lorem ipsum dolor sit amet",
                        Price = 20000,
                        PictureUrl = "/images/products/sb-ang1.png",
                        Brand = "Angular",
                        Type = "Boards",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Green Angular Board 3000",
                        Description = "Nunc viverra imperdiet enim",
                        Price = 15000,
                        PictureUrl = "/images/products/sb-ang2.png",
                        Brand = "Angular",
                        Type = "Boards",
                        QuantityInStock = 100
                    }
                );

                context.SaveChanges();
            }
        }
    }
}