using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SchoolAPI_Service.Data;
using SchoolAPI_Service.IRepository;

namespace SchoolAPI_Service.Repository
{
	public class Repository<T> : IRepository<T> where T:class
	{
        private readonly AppDbContext _dbContext;
        internal DbSet<T> _dbSet;

		public Repository(AppDbContext dbContext)
		{
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
		}

        public virtual async Task CreateAsync(T Entity)
        {
            await _dbSet.AddAsync(Entity);
            await SaveAsync();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> GetAsync(Expression<Func<T,bool>>? filter = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
                query = query.Where(filter);
            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task RemoveAsync(T Entity)
        {
            _dbSet.Remove(Entity);
            await SaveAsync();
        }

        public virtual async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<T> UpdateAsync(T Entity)
        {
            _dbSet.Update(Entity);
            await SaveAsync();
            return Entity;
        }
    }
}

