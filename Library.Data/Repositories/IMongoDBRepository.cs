using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Library.Data.Repositories
{
    public interface IMongoDBRepository<T> where T : IEntity
    {
        Task<T> Get(string id);
        Task<T> Get(Expression<Func<T, Boolean>> predicate);
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> DeletePermanent(string id);
        Task<bool> Delete(T entity);
        Task<List<T>> GetAll(Expression<Func<T, Boolean>> predicate);
        Task<List<T>> GetAll();
    }
}
