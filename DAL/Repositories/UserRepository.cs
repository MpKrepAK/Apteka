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
}