using Library.Entities.Concrete;
using Library.Entities.Dtos;

namespace Library.Business.Abstract
{
    public interface IBookService
    {
        List<Book> GetAll();
        int Add(BookAddDto bookAddDto);
        Book AddAlternative(BookAddDto bookAddDto);
        int Update(Book book);
        bool Delete(Book book);
        Book GetById(int id); 
    }
}
