using ServiceExtender.Data.EF;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookService.Data.EF.Models
{
    [Table("Auhtors")]
    public class AuthorModel : BaseModel<int>
    {

        public override int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public virtual ICollection<BookModel> Books { get; set; }
        //public virtual ICollection<GenreModel> Genres { get; set; }
    }
}
