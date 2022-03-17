using CustomersAPI.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomersAPI.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        T Get(Expression<Func<T,bool>>filter);
        List<T> GetAll(Expression<Func<T,bool>>filter=null);
    }
}
