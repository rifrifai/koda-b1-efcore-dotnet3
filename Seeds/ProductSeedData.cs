using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Seeds;

public static class ProductSeedData
{
    private static IEnumerable<Product> InitialProducts()
    {
        yield return new Product("P004", "Keyboard Mekanik", 35000m, 20, "Elektronik", "Deskripsi untuk keyboard mekanik");
        yield return new Product("P002", "Mouse", 20000m, 20, "Mouse", "Mouse adalah alat untuk mengetik yang dimana huruf nya akan ditampilkan di monitor");
        yield return new Product("P003", "Monitori", 15000m, 20, "Screen", "Monitor yang sangat mahal karena merknya samsung 80 inch");
    }

    public static void Seed(DbContext context)
    {
        foreach (var product in InitialProducts())
        {
            bool exists = context.Set<Product>()
                .Any(p => p.ProductCode == product.ProductCode);

            if (!exists)
            {
                context.Set<Product>().Add(product);
            }
        }
        context.SaveChanges();
    }

    public static async Task SeedAsync(DbContext context, CancellationToken ct)
    {
        foreach (var product in InitialProducts())
        {
            bool exists = await context.Set<Product>().AnyAsync(p => p.ProductCode == product.ProductCode, ct);

            if (!exists)
            {
                context.Set<Product>().Add(product);
            }
        }
        await context.SaveChangesAsync(ct);
    }
}