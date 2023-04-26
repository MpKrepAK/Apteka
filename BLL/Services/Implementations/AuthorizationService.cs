using System.Security.Claims;
using BLL.Services.Interfaces;

namespace BLL.Services.Implementations;

public class AuthorizationService : IAuthorizationService
{
    public bool IsUserAuthorized(ClaimsIdentity identity, string requiredRole)
    {
        return identity != null && identity.IsAuthenticated && identity.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == requiredRole);
    }
}