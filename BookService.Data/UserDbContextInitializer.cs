using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BookService.Data
{
    public class UserDbContextInitializer
    {
        public static void Initialize(IApplicationBuilder applicationBuilder)
        {
            var password = "Tga4jx0fxf";

            var scope = applicationBuilder.ApplicationServices.CreateScope();

            var userMenager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var role = new IdentityRole()
            {
                Id = "d4109238-49de-4945-9e0a-6176f93316be",
                Name = "admin"
            };
            var roleUser = new IdentityRole()
            {
                Id = "dfa33bfb-127e-4101-9590-3b1787139ff0",
                Name = "user"
            };

            var user = new User()
            {
                Id = "57a09a25-db13-44b9-a80e-a34794298b7f",
                Name = "Мирон",
                Surname = "Асмыкович",
                Email = "goker21@inbox.ru",
                UserName = "admin",
                PhoneNumber = "89841721907",
                BirthDate = DateTime.Parse("21.05.1997")
            };

            if (roleManager.FindByIdAsync(role.Id).Result == null)
            {
                var resultRole = roleManager.CreateAsync(role).Result;
                if (!resultRole.Succeeded)
                {
                    throw new ArgumentNullException(nameof(resultRole));
                }
            }
            if (roleManager.FindByIdAsync(roleUser.Id).Result == null)
            {
                var resultRole = roleManager.CreateAsync(roleUser).Result;
                if (!resultRole.Succeeded)
                {
                    throw new ArgumentNullException(nameof(resultRole));
                }
            }

            if (userMenager.FindByIdAsync(user.Id).Result == null)
            {
                var resultUser = userMenager.CreateAsync(user, password).Result;
                if (!resultUser.Succeeded) { throw new ArgumentNullException(nameof(userMenager)); }
            }

            var userRole = userMenager.GetRolesAsync(user).Result;

            if (!userRole.Any(x => x == role.Name))
            {
                var bindedRoleToUserResult = userMenager.AddToRoleAsync(user, role.Name).Result;
                if (!bindedRoleToUserResult.Succeeded)
                    throw new ArgumentNullException(nameof(userMenager));
            }


        }
    }
}
