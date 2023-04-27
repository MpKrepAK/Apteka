using DAL.Context;
using DAL.Interfaces;
using ML.Models;

namespace DAL.Repositories;

public class RoleRepository : IRoleRepository
{
    public readonly AptecaContext _Context;
    public RoleRepository(AptecaContext context)
    {
        _Context = context;
    }

    public IEnumerable<Role> GetAll()
    {
        return _Context.Roles.ToList();
    }

    public Role GetById(int Id)
    {
        return _Context.Roles.FirstOrDefault(x => x.Id == Id);
    }
}