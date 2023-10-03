using AutoMapper;
using Library.Business.Abstract;
using Library.DataAccess.Abstract;
using Library.Entities.Concrete;
using Library.Entities.Dtos;

namespace Library.Business.Concrete.Managers
{
    public class BookManager : IBookService
    {
        private readonly IBookDal _bookDal;
        private readonly IMapper _mapper;

        public BookManager(IBookDal bookDal, IMapper mapper)
        {
            _bookDal = bookDal;
            _mapper = mapper;
        }

        public int Add(BookAddDto bookAddDto)
        { 
            var mappedBook = _mapper.Map<Book>(bookAddDto);
            var book = _bookDal.Add(mappedBook);
            return book;
        }

        public Book AddAlternative(BookAddDto bookAddDto)
        { 
            var mappedBook = _mapper.Map<Book>(bookAddDto);
            var book = _bookDal.AddAlternative(mappedBook);
            return book;
        }

        public bool Delete(Book book)
        {
            return _bookDal.Delete(book);
        }

        public List<Book> GetAll()
        {
            return _bookDal.GetList();
        }

        public Book GetById(int id)
        {
            return _bookDal.Get(x => x.Id == id);
        }

        public int Update(Book book)
        {
            return _bookDal.Update(book);
        }
    }
}
