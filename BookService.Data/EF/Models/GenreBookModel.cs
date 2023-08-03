using ServiceExtender.Data.EF;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookService.Data.EF.Models
{
    [Table("GenreBooks")]
    public class GenreBookModel : BaseModel<int>
    {
        public override int Id { get; set; }
        public int GenreId { get; set; }
        public int BookId { get; set; }
         public virtual BookModel Book { get; set; } 
        public virtual GenreModel Genre { get; set; }
    }
}
