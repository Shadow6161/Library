using Library.Core.Entities;
using System.Linq.Expressions;

namespace Library.Core.DataAccess
{
    public interface IRepository <T> where T : class, IEntity, new()
    { 
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        int Add(T entity);
        T AddAlternative(T entity);
        int Update(T entity);
        bool Delete(T entity);
    }
}
