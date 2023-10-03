using Library.Core.Entities;

namespace Library.Entities.Dtos
{
    public class BookAddDto : IDto
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
