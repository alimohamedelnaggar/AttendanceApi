using AttendanceApi.Core;
using AttendanceApi.Core.Entities;
using AttendanceApi.Core.Repository.Contract;
using AttendanceApi.Repository.Data.Contexts;
using AttendanceApi.Repository.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AttendanceDbContext dbContext;
        private readonly Hashtable repositories;
        public UnitOfWork(AttendanceDbContext dbContext)
        {
            this.dbContext = dbContext;
            repositories = new Hashtable();
        }

        

        public async Task<int> CompleteAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            var type= typeof(TEntity).Name;
            if (!repositories.ContainsKey(type))
            {
               var repository= new GenericRepository<TEntity>(dbContext);
                repositories.Add(type, repository);
            }
            return repositories[type]as IGenericRepository<TEntity> ;
        }
    }
}
