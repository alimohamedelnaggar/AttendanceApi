using AttendanceApi.Core.Entities;
using AttendanceApi.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Core.Repository.Contract
{
    public interface IGenericRepository<TEntity> where TEntity :BaseEntity
    {
       public Task<IEnumerable<TEntity>> GetAllAsync();
       public Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecification<TEntity> specification);
       public Task AddAsync(TEntity entity);
       
    }
}
