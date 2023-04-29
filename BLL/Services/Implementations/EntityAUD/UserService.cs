using AutoMapper;
using BLL.Services.Interfaces.EntityAUD;
using DAL.Interfaces;
using ML.Mapper;
using ML.Models;

namespace BLL.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository,IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<bool> Add(UserModel model)
    {
        if (model == null)
            return false;
        
        if (_userRepository.GetAll().Where(x=>x.EMail==model.EMail).ToList().Count>0)
            return false;

        var mapped = _mapper.Map<UserModel, User>(model);
        if (mapped==null)
            return false;
        
        _userRepository.Add(mapped);
        return true;
    }

    public async Task<bool> Update(UserModel model)
    {
        if (model == null)
            return false;
        if (_userRepository.GetById(model.Id) == null)
            return false;
        if (_userRepository.GetAll().FirstOrDefault(x=>x.EMail==model.EMail&&x.Id!=model.Id)!=null)
            return false;
        
        var mapped = _mapper.Map<UserModel, User>(model);
        _userRepository.UpdateById(model.Id, mapped);
        return true;
    }

    public async Task<bool> Delete(int Id)
    {
        var entity = _userRepository.GetById(Id);
        if (entity==null)
        {
            return false;
        }
        _userRepository.DeleteById(Id);
        return true;
    }

    public async Task<UserModel> GetById(int Id)
    {
        var role = _userRepository.GetById(Id);
        var vm = _mapper.Map<User, UserModel>(role);
        return vm;
    }
}