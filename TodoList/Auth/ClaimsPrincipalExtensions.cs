using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace TodoList.Auth
{
    public static class ClaimsPrincipalExtensions
    {
        public static int? GetUserId(this ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirst(JwtRegisteredClaimNames.Sub)
                ?? user.FindFirst(ClaimTypes.NameIdentifier);

            return userIdClaim != null && int.TryParse(userIdClaim.Value, out var userId)
                ? userId
                : null;
        }
    }
}
