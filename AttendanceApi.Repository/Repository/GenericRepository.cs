using AttendanceApi.Core.Entities;
using AttendanceApi.Core.Repository.Contract;
using AttendanceApi.Core.Specifications;
using AttendanceApi.Repository.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Repository.Repository
{
    internal class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AttendanceDbContext dbContext;

        public GenericRepository(AttendanceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            await dbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecification<TEntity> specification)
        {
            var query= SpecificationEvaluator<TEntity>.GetQuery(dbContext.Set<TEntity>(), specification);  
            return await query.ToListAsync();
        }

        public async Task<TEntity> GetWithSpecAsync(ISpecification<TEntity> specification)
        {
            var query= SpecificationEvaluator<TEntity>.GetQuery(dbContext.Set<TEntity>(), specification);
            return await query.FirstOrDefaultAsync();
        }



        //public async Task<TEntity> GetByCodeAsync(string code)
        //{
        //   var course=  await dbContext.Set<TEntity>().FindAsync(code);
        //    if (course is null) return null;
        //    return course;
        //}

        public async Task<TEntity> GetByCodeAsync(ISpecification<TEntity> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public void Remove(TEntity entity)
        {
             dbContext.Set<TEntity>().Remove(entity);
        }
        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification)
        {
            return SpecificationEvaluator<TEntity>.GetQuery(dbContext.Set<TEntity>(), specification);
        }
    }
}
