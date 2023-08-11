using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using SchoolAPI_Service.Data;
using SchoolAPI_Service.Model;
using SchoolAPI_Service.Repository.IRepository;

namespace SchoolAPI_Service.Repository
{
	public class StudentRepository : Repository<Student>,IStudentRepository
	{
		private readonly AppDbContext _dbContext;

		public StudentRepository(AppDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

        //public override async Task<List<Student>> GetAllAsync()
        //{
        //    return await _dbSet.Include(c => c.Correspondence).ToListAsync();
        //}

        //public override async Task<Student> GetAsync(Expression<Func<Student, bool>>? filter = null)
        //{
        //    IQueryable<Student> query = _dbSet;
        //    if (filter != null)
        //        query = query.Where(filter).Include(c=>c.Correspondence);
        //    return await query.FirstOrDefaultAsync();
        //}

        //public override async Task CreateAsync(Student student)
        //{
        //    await _dbSet.AddAsync(student);
        //    await SaveAsync();
        //}
    }
}

