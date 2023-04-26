using System.Security.Claims;

namespace BLL.Services.Interfaces;

public interface IAuthorizationService
{
    bool IsUserAuthorized(ClaimsIdentity identity, string requiredRole);
}