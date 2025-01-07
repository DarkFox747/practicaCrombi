using Microsoft.EntityFrameworkCore;
using TestEntityFrameworkProyecto1.Context;
using TestEntityFrameworkProyecto1.Models;
using TestEntityFrameworkProyecto1.Service;

namespace TestEntityFrameworkProyecto1.seeds
{
    public static class DatabaseSeeder
    {
        public static async Task SeedDatabase(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var authService = scope.ServiceProvider.GetRequiredService<IAuthService>();

            // Verificar si ya hay datos
            if (await context.Users.AnyAsync())
                return;

            // Crear usuarios de prueba
            var adminUser = await authService.RegisterUser(
                username: "admin",
                email: "admin@example.com",
                password: "Admin123!"
            );

            // Asignar rol de administrador
            adminUser.Role = UserRole.Admin;
            await context.SaveChangesAsync();

            var regularUser = await authService.RegisterUser(
                username: "user",
                email: "user@example.com",
                password: "User123!"
            );

            // Crear productos de ejemplo
            var products = new List<Product>
        {
            new Product
            {
                Name = "Laptop Gaming Pro",
                Description = "Laptop gaming de alta gama con RTX 3080",
                Price = 1499.99m,
                ImageUrl = "/images/laptop-gaming.jpg",
                Stock = 10,
                CreatedAt = DateTime.UtcNow
            },
            new Product
            {
                Name = "Smartphone Ultra",
                Description = "Smartphone de última generación con cámara 108MP",
                Price = 899.99m,
                ImageUrl = "/images/smartphone.jpg",
                Stock = 15,
                CreatedAt = DateTime.UtcNow
            },
            new Product
            {
                Name = "Auriculares Wireless",
                Description = "Auriculares bluetooth con cancelación de ruido",
                Price = 199.99m,
                ImageUrl = "/images/headphones.jpg",
                Stock = 30,
                CreatedAt = DateTime.UtcNow
            },
            new Product
            {
                Name = "Monitor 4K",
                Description = "Monitor gaming 4K 144Hz",
                Price = 499.99m,
                ImageUrl = "/images/monitor.jpg",
                Stock = 8,
                CreatedAt = DateTime.UtcNow
            },
            new Product
            {
                Name = "Teclado Mecánico RGB",
                Description = "Teclado gaming con switches Cherry MX",
                Price = 129.99m,
                ImageUrl = "/images/keyboard.jpg",
                Stock = 20,
                CreatedAt = DateTime.UtcNow
            }
        };

            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();

            // Crear WishLists de ejemplo
            var wishLists = new List<WishList>
        {
            new WishList
            {
                Name = "Mi Setup Gaming",
                UserId = regularUser.Id,
                CreatedAt = DateTime.UtcNow,
                Items = new List<WishListItem>
                {
                    new WishListItem
                    {
                        ProductId = products[0].Id, // Laptop Gaming
                        CreatedAt = DateTime.UtcNow
                    },
                    new WishListItem
                    {
                        ProductId = products[3].Id, // Monitor
                        CreatedAt = DateTime.UtcNow
                    },
                    new WishListItem
                    {
                        ProductId = products[4].Id, // Teclado
                        CreatedAt = DateTime.UtcNow
                    }
                }
            },
            new WishList
            {
                Name = "Tecnología Móvil",
                UserId = regularUser.Id,
                CreatedAt = DateTime.UtcNow,
                Items = new List<WishListItem>
                {
                    new WishListItem
                    {
                        ProductId = products[1].Id, // Smartphone
                        CreatedAt = DateTime.UtcNow
                    },
                    new WishListItem
                    {
                        ProductId = products[2].Id, // Auriculares
                        CreatedAt = DateTime.UtcNow
                    }
                }
            }
        };

            await context.WishLists.AddRangeAsync(wishLists);
            await context.SaveChangesAsync();
        }
    }
}
