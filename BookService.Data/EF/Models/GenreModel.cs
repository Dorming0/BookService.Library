using ServiceExtender.Data.EF;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookService.Data.EF.Models
{
    [Table("Genres")]
    public class GenreModel : BaseModel<int>
    {
        public override int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public virtual ICollection<GenreBookModel> GenreBooks { get; set; }
        //public virtual ICollection<AuthorModel> Authors { get; set; }
        //public virtual ICollection<BookModel> Books { get; set; }
    }
}
