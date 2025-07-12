using AttendanceApi.Core.Entities;
using AttendanceApi.Core.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Core
{
    public interface IUnitOfWork:IDisposable
    {
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;


        //public Task<int> AddAsync<TEntity>(TEntity entity) where TEntity : BaseEntity;


        
        public Task<int> CompleteAsync();
    }
}
