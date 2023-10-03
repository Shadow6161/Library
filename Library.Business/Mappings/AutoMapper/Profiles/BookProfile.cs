using AutoMapper;
using Library.Entities.Concrete;
using Library.Entities.Dtos;

namespace Library.Business.Mappings.AutoMapper.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookAddDto,Book>().ReverseMap();
        }
    }
}
