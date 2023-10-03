using Library.Core.DataAccess.Dapper;
using Library.DataAccess.Abstract;
using Library.Entities.Concrete;

namespace Library.DataAccess.Concrete.Dapper
{
    public class DpBookDal : Repository<Book> , IBookDal
    {
    }
}
