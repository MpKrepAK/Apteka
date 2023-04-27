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
}