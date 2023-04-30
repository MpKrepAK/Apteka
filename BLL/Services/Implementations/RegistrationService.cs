using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using BLL.Services.Interfaces;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using ML.Mapper;
using ML.Models;

namespace BLL.Services.Implementations;

public class RegistrationService : IRegistrationService
{
    private readonly AptecaContext _context;
    private readonly IMapper _mapper;

    public RegistrationService(AptecaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> RegisterUser(UserRegistration user)
    {
        if (await _context.Users.AnyAsync(u => u.EMail == user.EMail))
        {
            return false;
        }

        user.Password = user.Password;
        
        var u = _mapper.Map<UserRegistration, User>(user);

        u.RoleId = 1;
        
        
        _context.Users.Add(u);
        await _context.SaveChangesAsync();

        return true;
    }
}