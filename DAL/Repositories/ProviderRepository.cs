using DAL.Context;
using DAL.Interfaces;
using ML.Models;

namespace DAL.Repositories;

public class ProviderRepository : IProviderRepository
{
    public readonly AptecaContext _Context;
    public ProviderRepository(AptecaContext context)
    {
        _Context = context;
    }

    public IEnumerable<Provider> GetAll()
    {
        return _Context.Providers.ToList();
    }

    public Provider GetById(int Id)
    {
        return _Context.Providers.FirstOrDefault(x => x.Id == Id);
    }

    public Provider Add(Provider Entity)
    {
        _Context.Providers.Add(Entity);
        _Context.SaveChanges();
        return Entity;
    }

    public Provider UpdateById(int Id, Provider Entity)
    {
        var u= _Context.Providers.FirstOrDefault(x=>x.Id==Entity.Id);
        u.Name = Entity.Name;
        u.EMail = Entity.EMail;
        u.Adress = Entity.Adress;
        _Context.SaveChanges();
        return Entity;
    }

    public void DeleteById(int Id)
    {
        var e= _Context.Providers.FirstOrDefault(x=>x.Id==Id);
        _Context.Providers.Remove(e);
        _Context.SaveChanges();
    }
}