using System.Security.Claims;
using ML.Mapper;
using ML.Models;

namespace BLL.Services.Interfaces;

public interface IAuthenticationService
{
    Task<ClaimsIdentity> AuthenticateUser(UserAuth user);
}