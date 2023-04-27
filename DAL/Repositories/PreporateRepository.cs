using DAL.Context;
using DAL.Interfaces;
using ML.Models;

namespace DAL.Repositories;

public class PreporateRepository : IPreporateRepository
{
    public readonly AptecaContext _Context;
    public PreporateRepository(AptecaContext context)
    {
        _Context = context;
    }

    public IEnumerable<Preporate> GetAll()
    {
        return _Context.Preporates.ToList();
    }

    public Preporate GetById(int Id)
    {
        return _Context.Preporates.FirstOrDefault(x => x.Id == Id);
    }

    public Preporate Add(Preporate Entity)
    {
        _Context.Preporates.Add(Entity);
        _Context.SaveChanges();
        return Entity;
    }

    public Preporate UpdateById(int Id, Preporate Entity)
    {
        var u= _Context.Preporates.FirstOrDefault(x=>x.Id==Entity.Id);
        u.Name = Entity.Name;
        
        u.Name = Entity.Name;
        u.Name = Entity.Name;
        _Context.SaveChanges();
        return Entity;
    }

    public void DeleteById(int Id)
    {
        var e= _Context.Preporates.FirstOrDefault(x=>x.Id==Id);
        _Context.Preporates.Remove(e);
        _Context.SaveChanges();
    }
}