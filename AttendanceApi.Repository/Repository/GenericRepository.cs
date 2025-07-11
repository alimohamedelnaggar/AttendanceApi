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

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecification<TEntity> specification)
        {
            var query= SpecificationEvaluator<TEntity>.GetQuery(dbContext.Set<TEntity>(), specification);  
            return await query.ToListAsync();
        }
    }
}
