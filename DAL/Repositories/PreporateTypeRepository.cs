using DAL.Context;
using DAL.Interfaces;
using ML.Models;

namespace DAL.Repositories;

public class PreporateTypeRepository : IPreporateTypeRepository
{
    public readonly AptecaContext _Context;
    public PreporateTypeRepository(AptecaContext context)
    {
        _Context = context;
    }

    public IEnumerable<PreporateType> GetAll()
    {
        return _Context.Types.ToList();
    }

    public PreporateType GetById(int Id)
    {
        return _Context.Types.FirstOrDefault(x => x.Id == Id);
    }

    public PreporateType Add(PreporateType Entity)
    {
        _Context.Types.Add(Entity);
        _Context.SaveChanges();
        return Entity;
    }

    public PreporateType UpdateById(int Id, PreporateType Entity)
    {
        var u= _Context.Types.FirstOrDefault(x=>x.Id==Entity.Id);
        u.Name = Entity.Name;
        _Context.SaveChanges();
        return Entity;
    }

    public void DeleteById(int Id)
    {
        var e= _Context.Types.FirstOrDefault(x=>x.Id==Id);
        _Context.Types.Remove(e);
        _Context.SaveChanges();
    }
}