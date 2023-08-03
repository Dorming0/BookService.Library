using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ServiceExtender.Data.EF;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookService.Data.EF.Models
{
    [Table("Books")]
    public class BookModel : BaseModel<int>
    {
        public override int Id { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public decimal Price { get; set; }

        public int Status { get; set; }
        public int AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public virtual AuthorModel Author { get; set; }
        public virtual ICollection<GenreBookModel> GenreBooks { get; set; }
    }
}
