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

    public Role Add(Role Entity)
    {
        _Context.Roles.Add(Entity);
        _Context.SaveChanges();
        return Entity;
    }

    public Role UpdateById(int Id, Role Entity)
    {
        var u= _Context.Roles.FirstOrDefault(x=>x.Id==Entity.Id);
        u.Name = Entity.Name;
        _Context.SaveChanges();
        return Entity;
    }

    public void DeleteById(int Id)
    {
        var e= _Context.Roles.FirstOrDefault(x=>x.Id==Id);
        _Context.Roles.Remove(e);
        _Context.SaveChanges();
    }
}