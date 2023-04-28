using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BLL.Services.Interfaces;
using DAL.Context;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using ML.Mapper;
using ML.Models;

namespace BLL.Services.Implementations;

public class AuthenticationService : IAuthenticationService
{
    private readonly AptecaContext _context;
    private readonly IRoleRepository _roleRepository;

    public AuthenticationService(AptecaContext context, IRoleRepository roleRepository)
    {
        _context = context;
        _roleRepository = roleRepository;
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
            new Claim(ClaimTypes.Role, _roleRepository.GetById(result.RoleId).Name)
        };

        var identity = new ClaimsIdentity(claims, "Token");

        return identity;
    }

}