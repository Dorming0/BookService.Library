using Microsoft.AspNetCore.Identity;

namespace BookService.Data
{
    public class User : IdentityUser
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
