using AutoMapper;
using BLL.Services.Interfaces.EntityAUD;
using DAL.Interfaces;
using ML.Mapper;
using ML.Models;

namespace BLL.Services.Implementations;

public class ProviderService : IProviderService
{
    private readonly IProviderRepository _providerRepository;
    private readonly IMapper _mapper;
    public ProviderService(IProviderRepository providerRepository, IMapper mapper)
    {
        _providerRepository = providerRepository;
        _mapper = mapper;
    }
    public async Task<bool> Add(ProviderModel model)
    {
        if (model == null)
            return false;

        if (_providerRepository.GetAll().Where(x=>x.Name==model.Name).ToList().Count>0)
            return false;
        
        var mapped = _mapper.Map<ProviderModel, Provider>(model);
        if (mapped==null)
            return false;
        
        _providerRepository.Add(mapped);
        return true;
    }

    public async Task<bool> Update(ProviderModel model)
    {
        if (model == null)
            return false;
        if (_providerRepository.GetById(model.Id) == null)
            return false;
        
        var mapped = _mapper.Map<ProviderModel, Provider>(model);
        _providerRepository.UpdateById(model.Id, mapped);
        return true;
    }

    public async Task<bool> Delete(int Id)
    {
        var entity = _providerRepository.GetById(Id);
        if (entity==null)
        {
            return false;
        }
        _providerRepository.DeleteById(Id);
        return true;
    }

    public async Task<ProviderModel> GetById(int Id)
    {
        var type = _providerRepository.GetById(Id);
        var vm = _mapper.Map<Provider, ProviderModel>(type);
        return vm;
    }
}