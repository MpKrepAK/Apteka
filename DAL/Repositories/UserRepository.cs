using DAL.Context;
using DAL.Interfaces;
using ML.Models;

namespace DAL.Repositories;

public class UserRepository : IUserRepository
{
    public readonly AptecaContext _Context;
    public UserRepository(AptecaContext context)
    {
        _Context = context;
    }

    public IEnumerable<User> GetAll()
    {
        return _Context.Users.ToList();
    }

    public User GetById(int Id)
    {
        return _Context.Users.FirstOrDefault(x => x.Id == Id);
    }

    public User Add(User Entity)
    {
        _Context.Users.Add(Entity);
        _Context.SaveChanges();
        return Entity;
    }

    public User UpdateById(int Id, User Entity)
    {
        var u= _Context.Users.FirstOrDefault(x=>x.Id==Entity.Id);
        u.FirstName = Entity.FirstName;
        u.LastName = Entity.LastName;
        u.EMail = Entity.EMail;
        u.Password = Entity.Password;
        u.RoleId = Entity.RoleId;
        _Context.SaveChanges();
        return Entity;
    }

    public void DeleteById(int Id)
    {
        var e= _Context.Users.FirstOrDefault(x=>x.Id==Id);
        _Context.Users.Remove(e);
        _Context.SaveChanges();
    }
}