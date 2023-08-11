using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SchoolAPI_Service.Data;
using SchoolAPI_Service.Repository.IRepository;

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

        public async Task CreateAsync(T Entity)
        {
            await _dbSet.AddAsync(Entity);
            await SaveAsync();
        }

        public async Task<List<T>> GetAllAsync(string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.None))
                {
                    query = query.Include(includeProp);
                }
            }
            //return query.ToList();

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T,bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
                query = query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.None))
                {
                    query = query.Include(includeProp);
                }
            }
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

