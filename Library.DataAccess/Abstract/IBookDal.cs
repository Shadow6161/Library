using Library.Core.DataAccess;
using Library.Entities.Concrete;

namespace Library.DataAccess.Abstract
{
    public interface IBookDal : IRepository<Book>
    {
    }
}
