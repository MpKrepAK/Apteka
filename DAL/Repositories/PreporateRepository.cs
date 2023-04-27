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
}