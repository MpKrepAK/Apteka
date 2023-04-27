using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BLL.Services.Interfaces;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using ML.Mapper;
using ML.Models;

namespace BLL.Services.Implementations;

public class AuthenticationService : IAuthenticationService
{
    private readonly AptecaContext _context;

    public AuthenticationService(AptecaContext context)
    {
        _context = context;
    }

    public async Task<ClaimsIdentity> AuthenticateUser(UserAuth user)
    {
        var result = await _context.Users.FirstOrDefaultAsync(u => u.EMail == user.EMail && u.Password == user.Password);

        if (result == null)
        {
            return null;
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()),
            new Claim(ClaimTypes.Email, result.EMail),
            new Claim(ClaimTypes.Role, result.Role.Name)
        };

        var identity = new ClaimsIdentity(claims, "Token");

        return identity;
    }

}