using System;
using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
	public class StoreContextSeed
	{
		public StoreContextSeed()
		{
		}

		public static async Task SeedAsync(ApplicationDbContext db)
		{
			if(!db.ProductBrands.Any())
			{
				var brandData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
				var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
				db.ProductBrands.AddRange(brands);
			}

            if (!db.ProductTypes.Any())
            {
                var prodTypeData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var prodType = JsonSerializer.Deserialize<List<ProductType>>(prodTypeData);
                db.ProductTypes.AddRange(prodType);
            }

            if (!db.Products.Any())
            {
                var prodData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var product = JsonSerializer.Deserialize<List<Product>>(prodData);
                db.Products.AddRange(product);
            }

			if (db.ChangeTracker.HasChanges())
				await db.SaveChangesAsync();
        }
	}
}

