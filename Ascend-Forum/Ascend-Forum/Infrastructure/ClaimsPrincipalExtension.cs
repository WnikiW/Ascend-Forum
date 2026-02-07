using System.Security.Claims;
using Ascend_Forum.Infrastructure.Data;

namespace Ascend_Forum.Infrastructure
{
    public static class ClaimsPrincipalExtension
    {
        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(RoleType.Administrator);
        }
    }
}
