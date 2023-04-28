using AutoMapper;
using BLL.Services.Interfaces.EntityAUD;
using DAL.Interfaces;
using ML.Mapper;
using ML.Models;

namespace BLL.Services.Implementations;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;

    public RoleService(IRoleRepository roleRepository,IMapper mapper)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
    }

    public async Task<bool> Add(RoleModel model)
    {
        if (model == null)
            return false;
        
        if (_roleRepository.GetAll().Where(x=>x.Name==model.Name).ToList().Count>0)
            return false;

        var mapped = _mapper.Map<RoleModel, Role>(model);
        if (mapped==null)
            return false;
        
        _roleRepository.Add(mapped);
        return true;
    }

    public async Task<bool> Update(RoleModel model)
    {
        if (model == null)
            return false;
        if (_roleRepository.GetById(model.Id) == null)
            return false;
        
        var mapped = _mapper.Map<RoleModel, Role>(model);
        _roleRepository.UpdateById(model.Id, mapped);
        return true;
    }

    public async Task<bool> Delete(int Id)
    {
        var entity = _roleRepository.GetById(Id);
        if (entity==null)
        {
            return false;
        }
        _roleRepository.DeleteById(Id);
        return true;
    }
}