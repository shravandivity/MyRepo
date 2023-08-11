using System;
using System.Linq.Expressions;

namespace SchoolAPI_Service.Repository.IRepository
{
	public interface IRepository<T> where T:class
	{
		Task<List<T>> GetAllAsync(string? includeProperties = null);
		Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
		Task CreateAsync(T Entity);
		Task RemoveAsync(T Entity);
		Task<T> UpdateAsync(T Entity);
		Task SaveAsync();
	}
}

