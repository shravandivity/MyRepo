using System;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
	public class ProductRepository : IProductRepository
	{
        private readonly ApplicationDbContext _db;
		public ProductRepository(ApplicationDbContext db)
		{
            _db = db;
		}

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync()
        {
            var prodBrand = await _db.ProductBrands.ToListAsync();
            return prodBrand;
        }

        public async Task<ProductBrand> GetProductBrandByIdAsync(int Id)
        {
            var prodBrand = await _db.ProductBrands.FirstOrDefaultAsync(p=>p.Id == Id);
            return prodBrand;
        }

        public async Task<Product> GetProductByIdAsync(int Id)
        {
            var prod = await _db.Products.Include(p => p.ProductBrand).Include(p => p.ProductType).FirstOrDefaultAsync(p => p.Id == Id);
            return prod;
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            var prod = await _db.Products.Include(p=>p.ProductBrand).Include(p=>p.ProductType).ToListAsync();
            return prod;
        }

        public async Task<ProductType> GetProductTypeByIdAsync(int Id)
        {
            var prodType = await _db.ProductTypes.FirstOrDefaultAsync(p => p.Id == Id);
            return prodType;
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            var prodType = await _db.ProductTypes.ToListAsync();
            return prodType;
        }
    }
}

