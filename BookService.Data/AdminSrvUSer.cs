using ServiceExtender.Http;
using System.Security.Claims;
using System.Security.Principal;

namespace BookService.Data
{
    public class AdminSrvUSer : SrvUser
    {
        public AdminSrvUSer()
        {
        }

        public AdminSrvUSer(IEnumerable<ClaimsIdentity> identities) : base(identities)
        {
        }

        public AdminSrvUSer(IIdentity identity) : base(identity)
        {
        }

        public AdminSrvUSer(IPrincipal principal) : base(principal)
        {
        }
    }
}
