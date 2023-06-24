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

        public async Task<Product> GetProductByIdAsync(int Id)
        {
            var prod = await _db.Products.Where(p=>p.Id == Id).FirstOrDefaultAsync();
            return prod;
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            var prod = await _db.Products.ToListAsync();
            return prod;
        }
    }
}

