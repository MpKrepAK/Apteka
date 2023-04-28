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
        if (!vm.Name.IsNullOrEmpty())
        {
            vm.Types = _preporateTypeRepository.GetAll()
                .Where(x => x.Name.ToLower().Contains(vm.Name.ToLower()))
                .Select(x=>_mapper.Map<PreporateType,TypeModel>(x))
                .ToList();
        }
        else
        {
            vm.Types = _preporateTypeRepository.GetAll().Select(x=>_mapper.Map<PreporateType,TypeModel>(x)).ToList();
        }
        return View(vm);
    }
    public IActionResult Providers()
    {
        return View("AdminNav");
    }
    public IActionResult Roles(RolesSearch model)
    {
        RolesSearch vm;
        if (model==null)
            vm = new RolesSearch();
        else
            vm = model;
        if (!vm.Name.IsNullOrEmpty())
        {
            vm.Roles = _roleRepository.GetAll()
                .Where(x => x.Name.ToLower().Contains(vm.Name.ToLower()))
                .Select(x=>_mapper.Map<Role,RoleModel>(x))
                .ToList();
        }
        else
        {
            vm.Roles = _roleRepository.GetAll().Select(x=>_mapper.Map<Role,RoleModel>(x)).ToList();
        }
        return View(vm);
    }
    public IActionResult Users()
    {
        return View("AdminNav");
    }
}