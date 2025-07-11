using AttendanceApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Core.Specifications
{
    public interface ISpecification<TEntity> where TEntity : BaseEntity
    {
        //public Expression<Func<TEntity,bool>> Criteria { get; set; }
        public List<Expression<Func<TEntity, object>>> Includes { get; set; }

    }
}
