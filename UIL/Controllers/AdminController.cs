using AutoMapper;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ML.Mapper;
using ML.Models;
using UIL.Models;

namespace UIL.Controllers;

[Authorize(Roles="Admin")]
public class AdminController : Controller
{
    private readonly IPreporateRepository _preporateRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPreporateTypeRepository _preporateTypeRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IProviderRepository _providerRepository;
    private readonly IMapper _mapper;
    
    public AdminController(
        IMapper mapper,
        IPreporateRepository preporateRepository, 
        IUserRepository userRepository, 
        IPreporateTypeRepository preporateTypeRepository,
        IRoleRepository roleRepository,
        IProviderRepository providerRepository)
    {
        _preporateRepository = preporateRepository;
        _userRepository = userRepository;
        _preporateTypeRepository = preporateTypeRepository;
        _roleRepository = roleRepository;
        _providerRepository = providerRepository;
        _mapper = mapper;
    }
    
    public IActionResult Index()
    {
        return View("AdminNav");
    }
    public IActionResult Preporates()
    {
        return View();
    }
    public IActionResult Types(TypesSearch model)
    {
        TypesSearch vm;
        if (model==null)
            vm = new TypesSearch();
        else
            vm = model;
        vm.Types = _preporateTypeRepository.GetAll().Select(x=>_mapper.Map<PreporateType,TypeModel>(x)).ToList();
        if (!vm.Name.IsNullOrEmpty())
        {
            vm.Types = vm.Types
                .Where(x => x.Name.ToLower().Contains(vm.Name.ToLower()))
                .ToList();
        }
        return View(vm);
    }
    public IActionResult Providers(ProvidersSearch model)
    {
        ProvidersSearch vm;
        if (model==null)
            vm = new ProvidersSearch();
        else
            vm = model;
        vm.Providers = _providerRepository.GetAll()
            .Select(x=>_mapper.Map<Provider,ProviderModel>(x))
            .ToList();
        if (!vm.Name.IsNullOrEmpty())
        {
            vm.Providers = vm.Providers
                .Where(x => x.Name.ToLower().Contains(vm.Name.ToLower()))
                .ToList();
        }
        if (!vm.EMail.IsNullOrEmpty())
        {
            vm.Providers = vm.Providers
                .Where(x => x.EMail.ToLower().Contains(vm.EMail.ToLower()))
                .ToList();
        }
        if (!vm.Adress.IsNullOrEmpty())
        {
            vm.Providers = vm.Providers
                .Where(x => x.Adress.ToLower().Contains(vm.Adress.ToLower()))
                .ToList();
        }
        return View(vm);
    }
    public IActionResult Roles(RolesSearch model)
    {
        RolesSearch vm;
        if (model==null)
            vm = new RolesSearch();
        else
            vm = model;
        vm.Roles = _roleRepository.GetAll().Select(x=>_mapper.Map<Role,RoleModel>(x)).ToList();
        if (!vm.Name.IsNullOrEmpty())
        {
            vm.Roles = vm.Roles
                .Where(x => x.Name.ToLower().Contains(vm.Name.ToLower()))
                .ToList();
        }
        return View(vm);
    }
    public IActionResult Users(UsersSearch model)
    {
        UsersSearch vm;
        if (model==null)
            vm = new UsersSearch();
        else
            vm = model;
        vm.Roles = _roleRepository.GetAll().Select(x=>_mapper.Map<Role,RoleModel>(x)).ToList();
        vm.Users = _userRepository.GetAll().Select(x=>_mapper.Map<User,UserModel>(x)).ToList();
        if (model.SelectedRoles!=null&&model.SelectedRoles.Count>0)
        {
            
            vm.Users = new List<UserModel>();
            foreach (var item in model.SelectedRoles)
            {
                vm.Users.AddRange(
                    _userRepository.GetAll().Where(x=>x.RoleId==item)
                        .Select(x=>_mapper.Map<User,UserModel>(x))
                        .ToList());
            }
        }
        if (!model.FirstName.IsNullOrEmpty())
        {
            vm.Users = vm.Users
                .Where(x => x.FirstName.ToLower().Contains(model.FirstName.ToLower()))
                .ToList();
        }
        if (!model.LastName.IsNullOrEmpty())
        {
            vm.Users = vm.Users
                .Where(x => x.LastName.ToLower().Contains(model.LastName.ToLower()))
                .ToList();
        }
        if (!model.EMail.IsNullOrEmpty())
        {
            vm.Users = vm.Users
                .Where(x => x.EMail.ToLower().Contains(model.EMail.ToLower()))
                .ToList();
        }
        if (!model.Password.IsNullOrEmpty())
        {
            vm.Users = vm.Users
                .Where(x => x.Password.ToLower().Contains(model.Password.ToLower()))
                .ToList();
        }
        return View(model);
    }
}