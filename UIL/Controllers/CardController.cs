using System.Security.Claims;
using AutoMapper;
using BLL.Services.Interfaces.EntityAUD;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ML.Mapper;
using ML.Models;

namespace UIL.Controllers;

[Authorize(Roles="Admin")]
public class CardController : Controller
{
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    // private readonly IPreporateRepository _preporateRepository;
    // private readonly IUserRepository _userRepository;
    // private readonly IPreporateTypeRepository _preporateTypeRepository;
    // private readonly IRoleRepository _roleRepository;
    // private readonly IProviderRepository _providerRepository;
    
    private readonly IPreporateTypeService _preporateTypeService;
    private readonly IRoleService _roleService;
    
    public CardController(ILogger<CardController> logger,
        IMapper mapper,
        IPreporateRepository preporateRepository, 
        IUserRepository userRepository, 
        IPreporateTypeRepository preporateTypeRepository,
        IRoleRepository roleRepository,
        IProviderRepository providerRepository,
        IPreporateTypeService preporateTypeService,
        IRoleService roleService)
    {
        _logger = logger;
        _mapper = mapper;
        // _preporateRepository = preporateRepository;
        // _userRepository = userRepository;
        // _preporateTypeRepository = preporateTypeRepository;
        // _roleRepository = roleRepository;
        // _providerRepository = providerRepository;
        
        _preporateTypeService = preporateTypeService;
        _roleService = roleService;
    }
    
    [HttpGet]
    public IActionResult Index(int Id)
    {
        //var prep = _preporateRepository.GetById(Id);
        //return View("Preporate",prep);
        return View("Preporate");
    }
    [HttpGet]
    public IActionResult UserCard()
    {
        //var id= Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
        //User u = _userRepository.GetById(id);
        //return View("User",u);
        return View("User");
    }
    [HttpPost]
    public IActionResult UpdateUser(User u)
    {
        //_userRepository.UpdateById(u.Id,u);
        return RedirectToAction("Index", "Home");
    }
    
    
    #region Type

    [HttpGet]
    public async Task<IActionResult> TypeCard(int Id)
    {
        var type = _preporateTypeService.GetById(Id);
        await type;
        if (type.Result == null)
            return RedirectToAction("Types", "Admin");
        return View("Type",type.Result);
    }
    
    [HttpGet]
    public IActionResult TypeAdd()
    {
        return View("AddType",new TypeModel());
    }
    
    [HttpGet]
    public async Task<IActionResult> TypeDel(int Id)
    {
        var res= await _preporateTypeService.Delete(Id);
        if (res)
            _logger.LogInformation($"Тип препората с Id {Id} удален пользователем с Id {User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value}");
        return RedirectToAction("Types","Admin");
    }
    
    [HttpPost]
    public async Task<IActionResult> TypeUpdate(TypeModel type)
    {
        if (!ModelState.IsValid)
            return View("Type", type);
        var res = await _preporateTypeService.Update(type);
        if (!res)
            return View("Type", type);
        _logger.LogInformation($"Тип препората с Id {type.Id} изменен пользователем с Id {User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value}");
        return RedirectToAction("Types","Admin");
    }
    
    [HttpPost]
    public async Task<IActionResult> TypeAddSave(TypeModel type)
    {
        if (!ModelState.IsValid)
            return View("AddType", type);
        var res = await _preporateTypeService.Add(type);
        if (!res)
            return View("AddType", type);
        _logger.LogInformation($"Тип препората добавлен пользователем с Id {User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value}");
        return RedirectToAction("Types","Admin");
    }
    #endregion
    
    #region Role

    [HttpGet]
    public async Task<IActionResult> RoleCard(int Id)
    {
        var role = _roleService.GetById(Id);
        await role;
        if (role.Result == null)
            return RedirectToAction("Roles", "Admin");
        return View("Role",role.Result);
    }
    
    [HttpGet]
    public IActionResult RoleAdd()
    {
        return View("AddRole",new RoleModel());
    }
    
    [HttpGet]
    public async Task<IActionResult> RoleDel(int Id)
    {
        var res= await _roleService.Delete(Id);
        if (res)
            _logger.LogInformation($"Роль с Id {Id} удалена пользователем с Id {User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value}");
        return RedirectToAction("Roles","Admin");
    }
    
    [HttpPost]
    public async Task<IActionResult> RoleUpdate(RoleModel type)
    {
        if (!ModelState.IsValid)
            return View("Role", type);
        var res = await _roleService.Update(type);
        if (!res)
            return View("Role", type);
        _logger.LogInformation($"Роль с Id {type.Id} изменена пользователем с Id {User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value}");
        return RedirectToAction("Roles","Admin");
    }
    
    [HttpPost]
    public async Task<IActionResult> RoleAddSave(RoleModel type)
    {
        if (!ModelState.IsValid)
            return View("AddRole", type);
        var res = await _roleService.Add(type);
        if (!res)
            return View("AddRole", type);
        _logger.LogInformation($"Роль добавлена пользователем с Id {User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value}");
        return RedirectToAction("Roles","Admin");
    }
    #endregion
}