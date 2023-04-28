using AutoMapper;
using BLL.Services.Interfaces.EntityAUD;
using DAL.Interfaces;
using ML.Mapper;
using ML.Models;

namespace BLL.Services.Implementations;

public class PreporateTypeService : IPreporateTypeService
{
    private readonly IPreporateTypeRepository _preporateTypeRepository;
    private readonly IMapper _mapper;
    public PreporateTypeService(IPreporateTypeRepository preporateTypeRepository, IMapper mapper)
    {
        _preporateTypeRepository = preporateTypeRepository;
        _mapper = mapper;
    }
    public async Task<bool> Add(TypeModel model)
    {
        if (model == null)
            return false;

        if (_preporateTypeRepository.GetAll().Where(x=>x.Name==model.Name).ToList().Count>0)
            return false;
        
        var mapped = _mapper.Map<TypeModel, PreporateType>(model);
        if (mapped==null)
            return false;
        
        _preporateTypeRepository.Add(mapped);
        return true;
    }

    public async Task<bool> Update(TypeModel model)
    {
        if (model == null)
            return false;
        if (_preporateTypeRepository.GetById(model.Id) == null)
            return false;
        
        var mapped = _mapper.Map<TypeModel, PreporateType>(model);
        _preporateTypeRepository.UpdateById(model.Id, mapped);
        return true;
    }

    public async Task<bool> Delete(int Id)
    {
        var entity = _preporateTypeRepository.GetById(Id);
        if (entity==null)
        {
            return false;
        }
        _preporateTypeRepository.DeleteById(Id);
        return true;
    }
}