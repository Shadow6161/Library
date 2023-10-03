using Library.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Library.Entities.Concrete
{
    public class Book : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
