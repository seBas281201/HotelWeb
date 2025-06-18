using System.Security.Claims;

namespace HotelWeb.Helpers
{
    public static class ClaimsHelper
    {
        public static string? GetUserId(ClaimsPrincipal user) =>
            user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        public static string? GetEmail(ClaimsPrincipal user) =>
            user.FindFirst(ClaimTypes.Email)?.Value;

        public static string? GetRole(ClaimsPrincipal user) =>
            user.FindFirst(ClaimTypes.Role)?.Value;
    }

}
