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
}